using Backend.Models;
using Microsoft.EntityFrameworkCore;
﻿using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /*public ApplicationDbContext()
        {
            
        }
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetSection("ConnectionStrings")["Default"], new MySqlServerVersion(new Version(8, 0, 36)));
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public DbSet<Journalist> Journalists { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<ArticleError> ArticleErrors { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentReport> CommentReports { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Administator> Administators { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MarketingTeamMember> MarketingTeamMembers { get; set; }
        public DbSet<NewsReport> NewsReports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure your model relationships and constraints here
            // For example:
            builder.Entity<Vote>()
                .HasKey(v => new { v.Id, v.CommentId, v.RegisteredUserId });

            builder.Entity<Vote>()
                .HasOne(v => v.Comment)
                .WithMany(c => c.Votes)
                .HasForeignKey(v => v.CommentId);

            builder.Entity<Vote>()
                .HasOne(v => v.RegisteredUser)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.RegisteredUserId);
        }
    }

}