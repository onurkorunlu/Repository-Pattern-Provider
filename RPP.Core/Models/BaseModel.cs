using System;
using System.Collections.Generic;
using System.Text;

namespace RPP.Core.Models
{
    public class BaseModel
    {
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public BaseModel()
        {
            CreateDate = DateTime.Now;
        }
    }
}
