using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.BLL.Infrastructure
{
    public class OperationDetails
    {
        public bool Succeeded { get; private set; }

        public string Message { get; private set; }

        public string Property { get; private set; }

        public OperationDetails(bool succeeded, string message, string prop)
        {
            this.Succeeded = succeeded;
            this.Message = message;
            this.Property = prop;
        }
    }
}
