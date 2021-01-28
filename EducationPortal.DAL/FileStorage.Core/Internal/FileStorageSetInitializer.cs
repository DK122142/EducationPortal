using System;
using System.Linq;
using System.Reflection;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core.Internal
{
    public class FileStorageSetInitializer : IFileStorageSetInitializer
    {
        public virtual void InitializeSets(FSContext context)
        {
            var sets = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(type => type.IsSubclassOf(context.GetType())).SelectMany(type => type.GetProperties())
                .SelectMany(property => property.PropertyType.GetGenericArguments());

            var setsField = context.GetType().GetField("_sets", BindingFlags.NonPublic | BindingFlags.Instance);
            
            setsField?.SetValue(context, sets.ToList());
        }
    }
}
