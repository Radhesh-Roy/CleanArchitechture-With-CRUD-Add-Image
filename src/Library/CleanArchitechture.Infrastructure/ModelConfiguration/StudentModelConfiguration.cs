using CleanArchitechture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitechture.Infrastructure.ModelConfiguration;

internal class StudentModelConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student));
        builder.HasKey(x => x.Id);  
        builder.Property(x=>x.Name).HasMaxLength(128);
        builder.Property(x=>x.Address).HasMaxLength(128);
        builder.Property(x=>x.Phone).HasMaxLength(128);
        builder.Property(x=>x.Email).HasMaxLength(128);
    }
}
