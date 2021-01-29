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
        private readonly FSContext _context;
        private readonly string _name;

        public Storage(FSContext context)
        {
            this._context = context;
            this._name = typeof(Storage).Namespace;
            // this._name = Assembly.GetExecutingAssembly().FullName;

            // this.EnsureCreated();
        }

        // true if created, false if it already existed
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
                    Console.WriteLine($"Failed to create storage. Message: {e.Message} " +
                                      $"In method: {e.TargetSite} StackTrace: {e.StackTrace}");
                    throw;
                }
            }

            return false;
        }

        // Create storage(directory)
        public void Create()
        {
            Directory.CreateDirectory(this._name);
        }

        public void CreateTables()
        {
            var setsField = this._context.GetType().BaseType.GetField("_sets", BindingFlags.NonPublic | BindingFlags.Instance);

            var sets = (List<Type>)setsField?.GetValue(this._context);

            if (sets != null)
            {
                foreach (var fileStorageSet in sets)
                {
                    Directory.CreateDirectory($"{this._name}/{fileStorageSet.Name}");
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

        public void Delete() => Directory.Delete(this._name, true);

        public bool Exists() => Directory.Exists(this._name);


        public IEnumerable<T> GetAll<T>()
        {
            foreach (var file in Directory.EnumerateFiles(DirectoryPath<T>()))
            {
                yield return Get<T>(IdByFileName(file));
            }
        }

        public T Get<T>(Guid id)
        {
            if (FileExists<T>(id))
            {
                using (var fileStream = File.OpenRead(FilePathById<T>(id)))
                {
                    return JsonSerializer.DeserializeAsync<T>(fileStream).Result;
                }
            }

            Console.WriteLine($"File with id: {id} do not exists");

            return default;
        }

        public IEnumerable<T> Find<T>(Func<T, bool> predicate)
        {
            return GetAll<T>().Where(predicate);
        }

        public async Task CreateAsync<T>(T item)
        {
            using (var fileStream = new FileStream(FilePathFor(item), FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fileStream, item);
                fileStream.Close();
            }
        }

        public async Task UpdateAsync<T>(Guid oldItemId, T newItem)
        {
            if (FileExists<T>(oldItemId))
            {
                using (var fileStream = new FileStream(FilePathById<T>(oldItemId), FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fileStream, newItem);
                    fileStream.Close();
                }
            }
        }
        
        public void Delete<T>(Guid id)
        {
            if (FileExists<T>(id))
            {
                File.Delete(FilePathById<T>(id));
            }
        }

        public string FilePathFor<T>(T entity) => $"{this._name}/{typeof(T).Name}/{(entity as Entity).Id}.json";
        
        public string FilePathById<T>(Guid id) => $"{this._name}/{typeof(T).Name}/{id}.json";

        public bool FileExists<T>(Guid id) => File.Exists(FilePathById<T>(id));

        public string DirectoryPath<T>() => $"{this._name}/{typeof(T).Name}";

        public static Guid IdByFileName(string fileName)
        {
            string reversed = new string(fileName.Reverse().ToArray()).Substring(5,36);
            string result = new string(reversed.Reverse().ToArray());

            return Guid.Parse(result);
        }
    }
}
