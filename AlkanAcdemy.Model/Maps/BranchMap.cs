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
    public class BranchMap : CoreMap<Branch>
    {
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(x => x.InstructorName).HasMaxLength(30).IsRequired(true);            
            builder.Property(x => x.InstructorSurname).HasMaxLength(30).IsRequired(true);            
            builder.Property(x => x.BranchName).HasMaxLength(30).IsRequired(true);            
            builder.Property(x => x.PupilName).HasMaxLength(30).IsRequired(true);            
            builder.Property(x => x.PupilSurname).HasMaxLength(30).IsRequired(true);            
        }
    }
}
