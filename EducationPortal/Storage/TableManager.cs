using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EducationPortal.Storage
{
    public class TableManager : ITableManager
    {
        public IStorageController StorageController { get; set; }

        public TableManager(IStorageController storageController)
        {
            StorageController = storageController;
        }

        public List<Guid> Where<T>(string attribute, string value)
        {
            var result = new List<Guid>();

            foreach (var file in Directory.EnumerateFiles(Service.TablePath<T>(StorageController.Storage)))
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
                                    result.Add(Service.GetIdByFileName(file));
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool AnyEqual<T>(string attribute, string value)
        {
            return Where<T>(attribute, value).FirstOrDefault() != Guid.Empty;
        }

        public async Task<T> WhereId<T>(Guid id)
        {
            if (Service.Exists<T>(StorageController.Storage, id))
            {
                await using (var fileStream = new FileStream(Service.RowPath<T>(StorageController.Storage, id), FileMode.Open))
                {
                    return await JsonSerializer.DeserializeAsync<T>(fileStream);
                }
            }

            return default;
        }
    }
}
