using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistencia.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            
            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.UserName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.UserPassword)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.UserEmail)
            .IsRequired()
            .HasMaxLength(100);


            builder.HasMany(p => p.Rols)
            .WithMany(r => r.Users)
            .UsingEntity<UserRol>(
                
                j => j.HasOne(pt => pt.Rol)
                .WithMany(t => t.UserRols)
                .HasForeignKey(ut => ut.IdRolFk),

                j => j.HasOne(et => et.User)
                .WithMany(et => et.UserRols)
                .HasForeignKey(h => h.IdUserFk),

                j => 
                {
                    j.ToTable("userRols");
                    j.HasKey(t => new { t.IdUserFk, t.IdRolFk });
                }
            );

            builder.HasMany(p => p.RefreshTokens)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}