using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LCIClassification.Models
{
    public partial class LCIDataClassificationContext : DbContext
    {
        public LCIDataClassificationContext()
        {
        }

        public LCIDataClassificationContext(DbContextOptions<LCIDataClassificationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LciCategory> LciCategory { get; set; }
        public virtual DbSet<LciSubcategory> LciSubcategory { get; set; }
        public virtual DbSet<LciTweetCount> LciTweetCount { get; set; }
        public virtual DbSet<LciTweets> LciTweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=LCIDataClassification;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<LciCategory>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("PK__LCI_Cate__23CDE590ADFA8F5A");

                entity.Property(e => e.Categoryid).ValueGeneratedNever();

                entity.Property(e => e.Categoryname).IsUnicode(false);
            });

            modelBuilder.Entity<LciSubcategory>(entity =>
            {
                entity.HasKey(e => e.Subcategoryid)
                    .HasName("PK__LCI_Subc__E3EBECCD5DE889C0");

                entity.Property(e => e.Subcategoryid).ValueGeneratedNever();

                entity.Property(e => e.Subcategoryname).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.LciSubcategory)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__LCI_Subca__categ__30F848ED");
            });

            modelBuilder.Entity<LciTweetCount>(entity =>
            {
                entity.HasKey(e => e.Tweetcountid)
                    .HasName("PK__LCI_Twee__CB25B29498DB5218");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.LciTweetCount)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__LCI_Tweet__categ__49C3F6B7");
            });

            modelBuilder.Entity<LciTweets>(entity =>
            {
                entity.HasKey(e => e.Tweetid)
                    .HasName("PK__LCI_Twee__CF40D2C5041C13EA");

                entity.Property(e => e.Tweettext).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.LciTweets)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__LCI_Tweet__categ__33D4B598");
            });
        }
    }
}
