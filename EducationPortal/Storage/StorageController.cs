using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EducationPortal.Entities;

namespace EducationPortal.Storage
{
    public class StorageController
    {
        public string StorageName { get; private set; }

        public StorageController()
        {
            StorageName = typeof(StorageController).Namespace;

            if (!Directory.Exists(StorageName))
            {
                Directory.CreateDirectory(StorageName);
            }
        }

        public StorageController AddEntity<T>()
        {
            string directory = EntityPath<T>();

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return this;
        }
        
        private string RecordPath<T>(T record)
        {
            return $"{StorageName}/{typeof(T).Name}/{(record as Entity).Id}.json";
        }
        private string RecordPath<T>(Guid id)
        {
            return $"{StorageName}/{typeof(T).Name}/{id}.json";
        }

        private string EntityPath<T>()
        {
            return $"{StorageName}/{typeof(T).Name}";
        }

        public async Task AddRecord<T>(T record)
        {
            await AddRecords(new List<T>(){record});
        }

        public async Task AddRecords<T>(IEnumerable<T> records)
        {
            foreach (var record in records)
            {
                using (var file = new FileStream(RecordPath(record), FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(file, record);
                    file.Close();
                }
            }
        }
        
        public bool IsExists<T>(T record)
        {
            return File.Exists(RecordPath(record));
        }
        public bool IsExists<T>(Guid id)
        {
            return File.Exists(RecordPath<T>(id));
        }

        private Guid GetIdByFileName(string fileName)
        {
            string reversed = new string(fileName.Reverse().ToArray()).Substring(5,36);
            string result = new string(reversed.Reverse().ToArray());
            return Guid.Parse(result);
        }

        public async Task<T> GetRecordById<T>(Guid id)
        {
            if (IsExists<T>(id))
            {
                await using (var fs = new FileStream(RecordPath<T>(id), FileMode.Open))
                {
                    return await JsonSerializer.DeserializeAsync<T>(fs);
                }
            }

            return default;
        }

        public Guid FindRecordByAttribute<T>(string attribute, string value)
        {
            foreach (var file in Directory.EnumerateFiles(EntityPath<T>()))
            {
                using (var fs = new FileStream(file, FileMode.Open))
                {
                    using (var jsonDoc = JsonDocument.ParseAsync(fs))
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
    }
}
