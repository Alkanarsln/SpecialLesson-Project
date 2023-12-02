using AlkanAcademy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Model.Entities
{
    public class Branch : CoreEntity
    {
        public string InstructorName { get; set; }
        public string InstructorSurname { get; set; }
        public string BranchName { get; set; }
        public string PupilName { get; set; }
        public string PupilSurname { get; set; }
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        public int PupilID { get; set; } 
        public Pupil Pupil { get; set; }
    }
}
