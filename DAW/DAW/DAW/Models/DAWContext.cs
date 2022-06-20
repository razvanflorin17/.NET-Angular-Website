using DAW.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models
{
    public class DAWContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DAWContext(DbContextOptions options) : base(options) { }

        public DbSet<Are> Are { get; set; }
        public DbSet<Componente> Componente { get; set; }
        public DbSet<Configuratie> Configuratie { get; set; }
        public DbSet<PC> PC { get; set; }
        public DbSet<UserAddress> UserAdress { get; set; }


        public DbSet<SessionToken> SessionTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });

            // One to Many

            builder.Entity<User>()
                .HasOne(a => a.PC)
                .WithMany(b => b.Client);

            // One to One

            builder.Entity<User>()
                .HasOne(a => a.Componente)
                .WithOne(b => b.Client);

            builder.Entity<User>()
                .HasOne(a => a.Adresa)
                .WithOne(b => b.User);

            // Many to Many
            builder.Entity<Are>().HasKey(arp => new { arp.Id_PC, arp.Id_Configuratie });

            builder.Entity<Are>()
                .HasOne(arp => arp.PC)
                .WithMany(a => a.Are)
                .HasForeignKey(arp => arp.Id_PC);

            builder.Entity<Are>()
                .HasOne(arp => arp.Configuratie)
                .WithMany(rp => rp.Are)
                .HasForeignKey(arp => arp.Id_Configuratie);
        }
    }
}
