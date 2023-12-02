using AlkanAcademy.Core.Map;
using AlkanAcademy.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Model.Maps
{
    public class InstructorMap : CoreMap<Instructor>
    {

        public override void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(x=>x.InstructorName).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.InstructorSurname).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.BranchName).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Email).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Password).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Phone).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Price).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Adress).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Description).HasMaxLength(100).IsRequired(true);
        }
    }
}
