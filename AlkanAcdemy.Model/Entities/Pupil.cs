using AlkanAcademy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Model.Entities
{
    public class Pupil : CoreEntity
    {

        public string PupilName { get; set; }
        public string PupilSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        
    }
}
