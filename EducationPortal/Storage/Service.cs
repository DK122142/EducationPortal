using System;
using System.IO;
using System.Linq;

namespace EducationPortal.Storage
{
    public static class Service
    {
        public static string RowPath<T>(IStorage storage, T record)
        {
            return $"{storage.Name}/{typeof(T).Name}/{(record as IStorageEntity).Id}.json";
        }
        public static string RowPath<T>(IStorage storage, Guid id)
        {
            return $"{storage.Name}/{typeof(T).Name}/{id}.json";
        }

        public static string TablePath<T>(IStorage storage)
        {
            return $"{storage.Name}/{typeof(T).Name}";
        }

        public static Guid GetIdByFileName(string fileName)
        {
            string reversed = new string(fileName.Reverse().ToArray()).Substring(5,36);
            string result = new string(reversed.Reverse().ToArray());
            return Guid.Parse(result);
        }
        
        public static bool Exists<T>(IStorage storage, T record)
        {
            return File.Exists(RowPath(storage, record));
        }

        public static bool Exists<T>(IStorage storage, Guid id)
        {
            return File.Exists(RowPath<T>(storage, id));
        }

    }
}
