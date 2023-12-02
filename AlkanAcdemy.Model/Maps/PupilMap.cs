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
    public class PupilMap : CoreMap<Pupil>
    {
        public override void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder.Property(x=>x.PupilName).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.PupilSurname).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Email).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Password).HasMaxLength(30).IsRequired(true);
            builder.Property(x=>x.Gender).HasMaxLength(30).IsRequired(true);
        }
    }
}
