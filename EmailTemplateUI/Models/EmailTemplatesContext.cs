using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmailTemplateUI.Models
{
    public partial class EmailTemplatesContext : DbContext
    {
        public EmailTemplatesContext()
        {
        }

        public EmailTemplatesContext(DbContextOptions<EmailTemplatesContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Template> Templates { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("templates");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrorMessage).HasColumnName("message");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
