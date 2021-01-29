using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Infrastructure
{
    public class OperationDetails
    {
        public bool Succeded { get; private set; }

        public string Message { get; private set; }

        public string Property { get; private set; }

        public OperationDetails(bool succedeed, string message, string prop)
        {
            this.Succeded = succedeed;
            this.Message = message;
            this.Property = prop;
        }
    }
}
