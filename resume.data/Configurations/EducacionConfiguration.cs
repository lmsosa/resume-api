using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Domain.Entities;

namespace Resume.Data.Configurations
{
    public class EducacionConfiguration : IEntityTypeConfiguration<Educacion>
    {
        public void Configure(EntityTypeBuilder<Educacion> builder)
        {
            var nivelEducacionConverter = new EnumToStringConverter<EducacionNivel>();
            builder
                .Property(x => x.Nivel)
                .HasConversion(nivelEducacionConverter);
        }
    }
}
