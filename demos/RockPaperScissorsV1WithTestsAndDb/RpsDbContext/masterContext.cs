using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RpsDbContext
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<RpsRound> RpsRounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__Game__PlayerId__1A34DF26");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerAddress)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PlayerFname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PlayerLname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<RpsRound>(entity =>
            {
                entity.HasKey(e => e.RoundId)
                    .HasName("PK__RpsRound__94D84DFA83FDFEFA");

                entity.ToTable("RpsRound");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.RpsRounds)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__RpsRound__GameId__1D114BD1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
