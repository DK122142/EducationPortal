using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Storage
{
    public class Storage
    {
        public string Name { get; private set; }

        public Storage()
        {
            Name = typeof(Storage).Namespace;

            if (!Directory.Exists(Name))
            {
                try
                {
                    Directory.CreateDirectory(Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to create storage. Message{e.Message} " +
                                      $"In method: {e.TargetSite} StackTrace: {e.StackTrace}");
                    throw;
                }
            }
        }
    }
}
