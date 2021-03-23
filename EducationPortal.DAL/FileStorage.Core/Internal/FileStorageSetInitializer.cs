using System.Linq;
using System.Reflection;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core.Internal
{
    public class FileStorageSetInitializer : IFileStorageSetInitializer
    {
        public void InitializeSets(FSContext context)
        {
            var sets = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsSubclassOf(context.GetType().BaseType))
                .SelectMany(type => type.GetProperties())
                .SelectMany(property => property.PropertyType.GetGenericArguments());
            
            // Be sure string "sets" equal to string "sets" in Storage
            var setsField = context.GetType().BaseType.GetField("sets", BindingFlags.NonPublic | BindingFlags.Instance);
            
            setsField?.SetValue(context, sets);
        }
    }
}
