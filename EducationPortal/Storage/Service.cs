using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Entities;

namespace EducationPortal.Storage
{
    public static class Service
    {
        public static string RecordPath<T>(Storage storage, T record)
        {
            return $"{storage.Name}/{typeof(T).Name}/{(record as Entity).Id}.json";
        }
        public static string RecordPath<T>(Storage storage, Guid id)
        {
            return $"{storage.Name}/{typeof(T).Name}/{id}.json";
        }

        public static string EntityPath<T>(Storage storage)
        {
            return $"{storage.Name}/{typeof(T).Name}";
        }
    }
}
