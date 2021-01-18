using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using static EducationPortal.Storage.Service;

namespace EducationPortal.Storage
{
    public class StorageController : IStorageController
    {
        public IStorage Storage { get; }

        public StorageController(IStorage storage)
        {
            this.Storage = storage;
        }

        public IStorageController CreateTable<T>()
        {
            string directory = TablePath<T>(Storage);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return this;
        }

        public IStorageController DeleteTable<T>()
        {
            string directory = TablePath<T>(Storage);

            if (Directory.Exists(directory))
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to delete table(directory). Message: {e.Message} " +
                                      $"In method: {e.TargetSite} StackTrace: {e.StackTrace}");
                    throw;
                }
            }

            return this;
        }

        public async Task InsertInto<T>(T row)
        {
            await InsertInto<T>(new List<T>(1) {row});
        }

        public async Task InsertInto<T>(IEnumerable<T> rows)
        {
            foreach (var record in rows)
            {
                using (var fileStream = new FileStream(RowPath(Storage, record), FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fileStream, record);
                    fileStream.Close();
                }
            }
        }

        public void Delete<T>(T row)
        {
            Delete<T>(new List<T>(1){row});
        }

        public void Delete<T>(IEnumerable<T> rows)
        {
            foreach (var row in rows)
            {
                if (Exists(Storage, row))
                {
                    File.Delete(RowPath(Storage, row));
                }
            }
        }

        public async Task Update<T>(Guid id, T updatedRow)
        {
            if (Exists<T>(Storage, id))
            {
                using (var fileStream = new FileStream(RowPath<T>(Storage, id), FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fileStream, updatedRow);
                    fileStream.Close();
                }
            }
        }
    }
}
