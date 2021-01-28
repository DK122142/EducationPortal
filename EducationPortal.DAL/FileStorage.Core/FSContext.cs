using System;
using System.Collections.Generic;
using EducationPortal.DAL.FileStorage.Core.Infrastructure;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core
{
    public class FSContext
    {
        private IEnumerable<Type> _sets; 
        private Storage _storage;

        private IFileStorageSetInitializer _setInitializer;

        public FSContext(IFileStorageSetInitializer fileStorageSetInitializer)
        {
            this._setInitializer = fileStorageSetInitializer;

            this._setInitializer.InitializeSets(this);

            this.Storage.EnsureCreated();
        }

        public virtual Storage Storage
        {
            get
            {
                return this._storage ??= new Storage(this);
            }
        }

        public void test()
        {
            foreach (var type in _sets)
            {
                Console.WriteLine(type.Name);
            }
        }
    }
}
