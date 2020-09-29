using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Seamless.Model.Models
{
    public partial class SeamlessContext : DbContext
    {
        public SeamlessContext()
        {
        }

        public SeamlessContext(DbContextOptions<SeamlessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AClaim> AClaim { get; set; }
        public virtual DbSet<AConnections> AConnections { get; set; }
        public virtual DbSet<ARole> ARole { get; set; }
        public virtual DbSet<ARoleClaim> ARoleClaim { get; set; }
        public virtual DbSet<AUser> AUser { get; set; }
        public virtual DbSet<AUserClaim> AUserClaim { get; set; }
        public virtual DbSet<AUserRole> AUserRole { get; set; }
        public virtual DbSet<SActivityLog> SActivityLog { get; set; }
        public virtual DbSet<SAppParameter> SAppParameter { get; set; }
        public virtual DbSet<SAssignment> SAssignment { get; set; }
        public virtual DbSet<SCategory> SCategory { get; set; }
        public virtual DbSet<SFaq> SFaq { get; set; }
        public virtual DbSet<SMessage> SMessage { get; set; }
        public virtual DbSet<SNote> SNote { get; set; }
        public virtual DbSet<SNoteType> SNoteType { get; set; }
        public virtual DbSet<SPermission> SPermission { get; set; }
        public virtual DbSet<SPriority> SPriority { get; set; }
        public virtual DbSet<STicket> STicket { get; set; }
        public virtual DbSet<STicketField> STicketField { get; set; }
        public virtual DbSet<STicketStatus> STicketStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Seamless;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AClaim>(entity =>
            {
                entity.ToTable("A_Claim");

                entity.HasIndex(e => e.Name)
                    .HasName("Uk_A_Claim")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AConnections>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("A_Connections");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<ARole>(entity =>
            {
                entity.ToTable("A_Role");

                entity.HasIndex(e => e.Name)
                    .HasName("Uk_A_Role")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ARoleClaim>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.ClaimId })
                    .HasName("Pk_A_RoleClaim");

                entity.ToTable("A_RoleClaim");

                entity.Property(e => e.ClaimValue)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.ARoleClaim)
                    .HasForeignKey(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_A_RoleClaim_Claim");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ARoleClaim)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_A_RoleClaim_Role");
            });

            modelBuilder.Entity<AUser>(entity =>
            {
                entity.ToTable("A_User");

                entity.HasIndex(e => e.Email)
                    .HasName("UK_A_User")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Token).HasMaxLength(200);
            });

            modelBuilder.Entity<AUserClaim>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ClaimId })
                    .HasName("Pk_A_UserClaim");

                entity.ToTable("A_UserClaim");

                entity.Property(e => e.ClaimValue)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.AUserClaim)
                    .HasForeignKey(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_A_UserClaim_Claim");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AUserClaim)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_A_UserClaim_User");
            });

            modelBuilder.Entity<AUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("Pk_A_UserRole");

                entity.ToTable("A_UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AUserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_A_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AUserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_A_UserRole_User");
            });

            modelBuilder.Entity<SActivityLog>(entity =>
            {
                entity.ToTable("S_ActivityLog");

                entity.HasIndex(e => e.Action)
                    .HasName("UK_A_ActivityLog")
                    .IsUnique();

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Libelle).IsRequired();

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");
            });

            modelBuilder.Entity<SAppParameter>(entity =>
            {
                entity.ToTable("S_AppParameter");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DefaultValue).IsRequired();

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ParameterName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TypeParameter).HasMaxLength(50);
            });

            modelBuilder.Entity<SAssignment>(entity =>
            {
                entity.ToTable("S_Assignment");

                entity.Property(e => e.ClosedDate).HasColumnType("datetime");

                entity.Property(e => e.ClosedUserId).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");
            });

            modelBuilder.Entity<SCategory>(entity =>
            {
                entity.ToTable("S_Category");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SFaq>(entity =>
            {
                entity.ToTable("S_Faq");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SMessage>(entity =>
            {
                entity.ToTable("S_Message");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<SNote>(entity =>
            {
                entity.ToTable("S_Note");

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Note).IsRequired();
            });

            modelBuilder.Entity<SNoteType>(entity =>
            {
                entity.ToTable("S_NoteType");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SPermission>(entity =>
            {
                entity.ToTable("S_Permission");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SPriority>(entity =>
            {
                entity.ToTable("S_Priority");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<STicket>(entity =>
            {
                entity.ToTable("S_Ticket");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.File).HasMaxLength(510);

                entity.Property(e => e.State).HasMaxLength(500);

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Object)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<STicketField>(entity =>
            {
                entity.ToTable("S_TicketField");

                entity.Property(e => e.ChoiceList)
                    .HasColumnName("choiceList")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.IsRequired).HasColumnName("isRequired");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<STicketStatus>(entity =>
            {
                entity.ToTable("S_TicketStatus");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
