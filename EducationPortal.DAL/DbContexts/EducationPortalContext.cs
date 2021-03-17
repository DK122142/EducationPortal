using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using EducationPortal.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EducationPortal.DAL.DbContexts
{
    public class EducationPortalContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public DbSet<Profile> Profiles { get; set; }
        
        public DbSet<Material> Materials { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public EducationPortalContext(DbContextOptions<EducationPortalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .Property(b => b.Authors)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<IEnumerable<string>>(v, null),
                    new ValueComparer<IEnumerable<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode()))
                    )
                );

            builder.Entity<Course>()
                .HasOne<Profile>(c => c.Creator)
                .WithMany(p => p.CreatedCourses);

            builder.Entity<Course>()
                .HasMany<Profile>(c => c.JoinedProfiles)
                .WithMany(p => p.JoinedCourses);

            builder.Entity<Course>()
                .HasMany<Profile>(c => c.CompletedProfiles)
                .WithMany(p => p.CompletedCourses);

            builder.Entity<ProfileSkill>()
                .HasKey(ps => new { ps.ProfileId, Id = ps.SkillId });
            
            builder.Entity<ProfileSkill>()
                .HasOne(ps => ps.Profile)
                .WithMany(p => p.ProfileSkills)
                .HasForeignKey(ps => ps.ProfileId);

            builder.Entity<ProfileSkill>()
                .HasOne(ps => ps.Skill)
                .WithMany(s => s.ProfileSkills)
                .HasForeignKey(ps => ps.SkillId);

            builder.Entity<Profile>()
                .HasMany<Material>(p => p.AddedMaterials)
                .WithOne(m => m.AddedBy);
            
            builder.Entity<Profile>()
                .HasMany<Material>(p => p.PassedMaterials)
                .WithMany(m => m.PassedByUsers);
        }
    }
}
