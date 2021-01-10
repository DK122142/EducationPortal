using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static EducationPortal.Storage.Service;

namespace EducationPortal.Storage
{
    public class StorageController
    {
        public Storage Storage { get; private set; }

        public StorageController()
        {
            Storage = new Storage();
        }

        public StorageController AddTable<T>()
        {
            string directory = TablePath<T>(Storage);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return this;
        }

        public StorageController DeleteTable<T>()
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

        public async Task AddRow<T>(T row)
        {
            await AddRows(new List<T>(1) {row});
        }

        public async Task AddRows<T>(IEnumerable<T> rows)
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

        public void DeleteRow<T>(T row)
        {
            DeleteRows(new List<T>(1){row});
        }

        public void DeleteRows<T>(IEnumerable<T> rows)
        {
            foreach (var row in rows)
            {
                if (Exists(row))
                {
                    File.Delete(RowPath(Storage, row));
                }
            }
        }

        public async Task UpdateRow<T>(Guid id, T updatedRow)
        {
            if (Exists<T>(id))
            {
                using (var fileStream = new FileStream(RowPath<T>(Storage, id), FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fileStream, updatedRow);
                    fileStream.Close();
                }
            }
        }
        
        public bool Exists<T>(T record)
        {
            return File.Exists(RowPath(Storage, record));
        }
        public bool Exists<T>(Guid id)
        {
            return File.Exists(RowPath<T>(Storage, id));
        }

        private Guid GetIdByFileName(string fileName)
        {
            string reversed = new string(fileName.Reverse().ToArray()).Substring(5,36);
            string result = new string(reversed.Reverse().ToArray());
            return Guid.Parse(result);
        }

        public async Task<T> GetRecordById<T>(Guid id)
        {
            if (Exists<T>(id))
            {
                await using (var fileStream = new FileStream(RowPath<T>(Storage, id), FileMode.Open))
                {
                    return await JsonSerializer.DeserializeAsync<T>(fileStream);
                }
            }

            return default;
        }

        public Guid FindRecordByAttribute<T>(string attribute, string value)
        {
            foreach (var file in Directory.EnumerateFiles(TablePath<T>(Storage)))
            {
                using (var fileStream = new FileStream(file, FileMode.Open))
                {
                    using (var jsonDoc = JsonDocument.ParseAsync(fileStream))
                    {
                        string json = jsonDoc.Result.RootElement.ToString();
                        var jsonSplit = json.Replace("{", "")
                            .Replace("}", "")
                            .Replace("\"","")
                            .Replace(",", ":")
                            .Split(":");

                        for (int i = 0; i < jsonSplit.Length; i++)
                        {
                            if (jsonSplit[i].ToLower().Equals(attribute.ToLower()))
                            {
                                if (jsonSplit[i + 1].ToLower().Equals(value.ToLower()))
                                {
                                    return GetIdByFileName(file);
                                }
                            }
                        }
                    }
                }
            }

            return default;
        }

        public bool IsRowWithValueExists<T>(string attribute, string value)
        {
            return FindRecordByAttribute<T>(attribute, value) != Guid.Empty;
        }

    }
}
