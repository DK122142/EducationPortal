using System;
using System.Linq;
using System.Reflection;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core.Internal
{
    public class FileStorageSetInitializer : IFileStorageSetInitializer
    {
        public void InitializeSets(FSContext context)
        {
            var test = Assembly.GetExecutingAssembly();

            var sets = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsSubclassOf(context.GetType().BaseType))
                .SelectMany(type => type.GetProperties())
                .SelectMany(property => property.PropertyType.GetGenericArguments());

            var setsField = context.GetType().BaseType.GetField("_sets", BindingFlags.NonPublic | BindingFlags.Instance);
            
            setsField?.SetValue(context, sets.ToList());
        }
    }
}
