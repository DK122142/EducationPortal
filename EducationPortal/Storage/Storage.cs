using System;
using System.IO;

namespace EducationPortal.Storage
{
    public class Storage : IStorage
    {
        public string Name { get; }

        public Storage()
        {
            this.Name = typeof(Storage).Namespace;

            if (!Directory.Exists(this.Name))
            {
                try
                {
                    Directory.CreateDirectory(this.Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to create storage. Message: {e.Message} " +
                                      $"In method: {e.TargetSite} StackTrace: {e.StackTrace}");
                    throw;
                }
            }
        }
    }
}
