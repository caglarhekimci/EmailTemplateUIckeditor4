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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmailTemplates;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("templates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailHtml).HasColumnName("emailHTML");

                entity.Property(e => e.ErrorMessage).HasColumnName("message");

                entity.Property(e => e.PreviewTemplate).HasColumnName("previewTemplate");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .HasColumnName("templateName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
