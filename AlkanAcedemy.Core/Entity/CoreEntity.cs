using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Core.Entity
{
    public class CoreEntity 
    {
        public int ID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
