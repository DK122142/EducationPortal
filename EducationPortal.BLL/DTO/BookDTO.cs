using System;
using System.Collections.Generic;
using EducationPortal.BLL.DTO;

namespace EducationPortal.DAL.Entities
{
    public class BookDTO : MaterialDTO
    {
        public int Pages { get; set; }
        
        public DateTime Published { get; set; }

        public List<string> Authors { get; set; }
    }
}
