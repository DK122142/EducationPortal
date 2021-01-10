using System;
using EducationPortal.Entities;

namespace EducationPortal.Storage
{
    public static class Service
    {
        public static string RowPath<T>(Storage storage, T record)
        {
            return $"{storage.Name}/{typeof(T).Name}/{(record as Entity).Id}.json";
        }
        public static string RowPath<T>(Storage storage, Guid id)
        {
            return $"{storage.Name}/{typeof(T).Name}/{id}.json";
        }

        public static string TablePath<T>(Storage storage)
        {
            return $"{storage.Name}/{typeof(T).Name}";
        }
    }
}
