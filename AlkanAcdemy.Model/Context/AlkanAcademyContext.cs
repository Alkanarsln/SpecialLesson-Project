using AlkanAcademy.Model.Entities;
using AlkanAcademy.Model.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Model.Context
{
    public class AlkanAcademyContext : DbContext
    {
        public AlkanAcademyContext(DbContextOptions<AlkanAcademyContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new InstructorMap());
            modelBuilder.ApplyConfiguration(new PupilMap());
            modelBuilder.ApplyConfiguration(new BranchMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
