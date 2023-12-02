using AlkanAcademy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Model.Entities
{
    public class Instructor : CoreEntity
    {
        public string InstructorName { get; set; }
        public string InstructorSurname { get; set; }
        public string BranchName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}
