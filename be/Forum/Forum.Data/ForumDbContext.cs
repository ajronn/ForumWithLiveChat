using Forum.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Data
{
    public class ForumDbContext : IdentityDbContext<User>
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subsection> Subsections { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BuildSectionMapping(modelBuilder.Entity<Section>());
            BuildSubsectionMapping(modelBuilder.Entity<Subsection>());
            BuildThreadMapping(modelBuilder.Entity<Thread>());
            BuildPostMapping(modelBuilder.Entity<Post>());
            BuildUserMapping(modelBuilder.Entity<User>());
            BuildMessageMapping(modelBuilder.Entity<Message>());
        }


        private static void BuildSectionMapping(EntityTypeBuilder<Section> builder)
        {
            builder
                .HasMany(p => p.Subsections)
                .WithOne(b => b.Section)
                .HasForeignKey(z => z.SectionId);

            builder.HasKey(x => x.SectionId);
        }

        private static void BuildSubsectionMapping(EntityTypeBuilder<Subsection> builder)
        {
            builder
                .HasMany(p => p.Threads)
                .WithOne(b => b.Subsection)
                .HasForeignKey(z => z.SubsectionId);

            builder.HasKey(x => x.SubsectionId);
        }

        private static void BuildThreadMapping(EntityTypeBuilder<Thread> builder)
        {
            builder
                .HasMany(p => p.Posts)
                .WithOne(b => b.Thread)
                .HasForeignKey(z => z.ThreadId);

            builder.HasKey(x => x.ThreadId);
        }

        private static void BuildPostMapping(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasOne(x => x.Thread)
                .WithMany(y => y.Posts)
                .HasForeignKey(x => x.ThreadId);

            builder
                .HasOne(x => x.User)
                .WithMany(y => y.Posts)
                .HasForeignKey(x => x.UserId);

            builder.HasKey(x => x.PostId);
        }

        private static void BuildUserMapping(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(p => p.Posts)
                .WithOne(b => b.User)
                .HasForeignKey(z => z.UserId);

            builder
                .HasMany(p => p.Messages)
                .WithOne(b => b.User)
                .HasForeignKey(z => z.UserId);

            builder.HasKey(x => x.Id);
        }

        private static void BuildMessageMapping(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(y => y.Messages)
                .HasForeignKey(x => x.UserId);

            builder.HasKey(x => x.MessageId);
        }
    }
}