using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swift.BBS.Model.Models;

namespace Swift.BBS.Repositories.EfContext
{
    public class SwiftCodeBbsContext:DbContext
    {
        public SwiftCodeBbsContext()
        {

        }
        public SwiftCodeBbsContext(DbContextOptions<SwiftCodeBbsContext> options)
            : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 文章
            var articleCfg = modelBuilder.Entity<Article>();
            articleCfg.Property(p => p.Title).HasMaxLength(128);
            articleCfg.Property(p => p.Content).HasMaxLength(2048);
            articleCfg.Property(p => p.Tag).HasMaxLength(128);
            articleCfg.Property(p => p.CreateTime).HasColumnType("datetime2");
            articleCfg.HasOne(p => p.CreateUser).WithMany().HasForeignKey(p => p.CreateUserId).OnDelete(DeleteBehavior.Restrict); ;
            //  articleCfg.HasMany(p =>p.CollectionArticles).WithOne().HasForeignKey(p => p.ArticleId).OnDelete(DeleteBehavior.Cascade);
            //  articleCfg.HasMany(p => p.ArticleComments).WithOne(p => p.Article).HasForeignKey(p => p.ArticleId).OnDelete(DeleteBehavior.Cascade);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                // .UseSqlServer(@"Server=.; Database=SwiftCodeBbs; Trusted_Connection=True; Connection Timeout=600;MultipleActiveResultSets=true;")
                .UseSqlServer(@"Data Source=127.0.0.1;Initial Catalog=SwiftCodeBbs5;User ID=sa;Password=qwer1234...")

                .LogTo(Console.WriteLine, LogLevel.Information);
        }
        
    }
}