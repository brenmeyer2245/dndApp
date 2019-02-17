namespace DnDApp.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DnDApp.Models;

    public partial class DnDAppDbContext : DbContext
    {
        public DnDAppDbContext()
            : base("name=DnDAppDbContext_New")
        {
        }

        public virtual DbSet<AudioPlayer> AudioPlayer { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<PartyMember> PartyMembers { get; set; }
        public virtual DbSet<PlayerEpisode> PlayerEpisodes { get; set; }
        public virtual DbSet<PlayerStat> PlayerStats { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioPlayer>()
                .Property(e => e.audioUrl)
                .IsUnicode(false);

            modelBuilder.Entity<AudioPlayer>()
                .Property(e => e.episodeTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.BookName)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Series)
                .IsUnicode(false);

            modelBuilder.Entity<Episode>()
                .Property(e => e.EpisodeName)
                .IsUnicode(false);

            modelBuilder.Entity<Episode>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Episode>()
                .Property(e => e.EpisodeAudio)
                .IsUnicode(false);

            modelBuilder.Entity<Episode>()
                .Property(e => e.EpisodePhoto)
                .IsUnicode(false);

            modelBuilder.Entity<PartyMember>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PartyMember>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<PartyMember>()
                .Property(e => e.Headshot)
                .IsUnicode(false);

            modelBuilder.Entity<PartyMember>()
                .HasMany(e => e.PlayerEpisodes)
                .WithOptional(e => e.PartyMember)
                .HasForeignKey(e => e.PlayerId);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
