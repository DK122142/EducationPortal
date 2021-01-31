using System;
using System.Collections.Generic;
using EducationPortal.DAL.FileStorage.Core.Infrastructure;
using EducationPortal.DAL.FileStorage.Core.Internal;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core
{
    public class FSContext
    {
        private IEnumerable<Type> _sets; 
        private Storage _storage;

        private IFileStorageSetInitializer _setInitializer;

        public virtual Storage Storage
        {
            get
            {
                return this._storage ??= new Storage(this);
            }
        }

        public FSContext(IFileStorageSetInitializer fileStorageSetInitializer = null)
        {
            this._setInitializer = new FileStorageSetInitializer();

            this._setInitializer.InitializeSets(this);

            this.Storage.EnsureCreated();
        }
    }
}
