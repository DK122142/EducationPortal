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
        public Storage storage { get; private set; }

        public StorageController()
        {
            storage = new Storage();
        }

        public StorageController AddEntity<T>()
        {
            string directory = Service.EntityPath<T>(storage);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return this;
        }

        public async Task AddRecord<T>(T record)
        {
            await AddRecords(new List<T> {record});
        }

        public async Task AddRecords<T>(IEnumerable<T> records)
        {
            foreach (var record in records)
            {
                using (var file = new FileStream(Service.RecordPath(storage, record), FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(file, record);
                    file.Close();
                }
            }
        }
        
        public bool Exists<T>(T record)
        {
            return File.Exists(Service.RecordPath(storage, record));
        }
        public bool Exists<T>(Guid id)
        {
            return File.Exists(Service.RecordPath<T>(storage, id));
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
                await using (var fs = new FileStream(Service.RecordPath<T>(storage, id), FileMode.Open))
                {
                    return await JsonSerializer.DeserializeAsync<T>(fs);
                }
            }

            return default;
        }

        public Guid FindRecordByAttribute<T>(string attribute, string value)
        {
            foreach (var file in Directory.EnumerateFiles(Service.EntityPath<T>(storage)))
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
