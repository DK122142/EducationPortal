using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Storage
{
    public interface IStorageEntity<T>
    {
        T Id { get; }
    }
}
