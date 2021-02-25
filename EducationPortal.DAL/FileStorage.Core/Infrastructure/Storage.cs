using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core.Infrastructure.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core.Infrastructure
{
    public class Storage : IDatabase
    {
        private readonly FSContext context;
        private readonly string name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storageName">Directory name of Storage</param>
        public Storage(FSContext context, string storageName = null)
        {
            this.context = context;

            if (!string.IsNullOrEmpty(storageName))
            {
                this.name = storageName;
            }
            else
            {
                this.name = typeof(Storage).Namespace;
            }
        }

        /// <summary>
        /// If Storage not exist, it will be created and returns true
        /// If Storage already exists, returns false
        /// </summary>
        /// <returns></returns>
        public virtual bool EnsureCreated()
        {
            if (!this.Exists())
            {
                try
                {
                    this.Create();
                    this.CreateTables();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to create Storage. Message: {e.Message} " +
                                      $"In method: {e.TargetSite} StackTrace: {e.StackTrace}");
                    throw;
                }
            }

            return false;
        }

        /// <summary>
        /// Create Storage(directory)
        /// </summary>
        public void Create()
        {
            Directory.CreateDirectory(this.name);
        }

        public void CreateTables()
        {
            // Be sure string "sets" equal to string "sets" in FileStorageSetInitializer
            var setsField = this.context.GetType().BaseType.GetField("sets", BindingFlags.NonPublic | BindingFlags.Instance);

            var sets = (IEnumerable<Type>)setsField?.GetValue(this.context);

            if (sets != null)
            {
                foreach (var fileStorageSet in sets)
                {
                    Directory.CreateDirectory($"{this.name}/{fileStorageSet.Name}");
                }
            }
        }

        public virtual bool EnsureDeleted()
        {
            if (this.Exists())
            {
                this.Delete();
                return true;
            }

            return false;
        }

        public void Delete() => Directory.Delete(this.name, true);

        public bool Exists() => Directory.Exists(this.name);


        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            foreach (var file in Directory.EnumerateFiles(this.DirectoryPath<T>()))
            {
                yield return Get<T>(this.IdByFileName(file));
            }
        }

        public T Get<T>(Guid id) where T : Entity
        {
            if (this.FileExists<T>(id))
            {
                using (var fileStream = File.OpenRead(this.FilePathById<T>(id)))
                {
                    return JsonSerializer.DeserializeAsync<T>(fileStream).Result;
                }
            }

            Console.WriteLine($"File with id: {id} do not exists");

            return default;
        }

        public IEnumerable<T> Find<T>(Func<T, bool> predicate) where T : Entity
        {
            return this.GetAll<T>().Where(predicate);
        }

        public async Task CreateAsync<T>(T item) where T : Entity
        {
            using (var fileStream = new FileStream(this.FilePathFor(item), FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fileStream, item);
                fileStream.Close();
            }
        }

        public async Task UpdateAsync<T>(T updatedItem) where T : Entity
        {
            if (this.FileExists<T>((updatedItem as Entity).Id))
            {
                using (var fileStream = new FileStream(this.FilePathById<T>((updatedItem as Entity).Id), FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fileStream, updatedItem);
                    fileStream.Close();
                }
            }
        }
        
        public void Delete<T>(Guid id) where T : Entity
        {
            if (this.FileExists<T>(id))
            {
                File.Delete(this.FilePathById<T>(id));
            }
        }

        public bool Any<T>(Func<T, bool> predicate) where T : Entity
        {
            return this.Find(predicate).Any();
        }

        public string FilePathFor<T>(T entity) where T : Entity =>
            $"{this.name}/{typeof(T).Name}/{(entity as Entity).Id}.json";

        public string FilePathById<T>(Guid id) where T : Entity => $"{this.name}/{typeof(T).Name}/{id}.json";

        public bool FileExists<T>(Guid id) where T : Entity => File.Exists(this.FilePathById<T>(id));

        public string DirectoryPath<T>() where T : Entity => $"{this.name}/{typeof(T).Name}";

        public Guid IdByFileName(string fileName)
        {
            string reversed = new string(fileName.Reverse().ToArray()).Substring(5,36);
            string result = new string(reversed.Reverse().ToArray());

            return Guid.Parse(result);
        }
    }
}
