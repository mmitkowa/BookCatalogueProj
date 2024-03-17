using Microsoft.EntityFrameworkCore;
using BookwormsHaven.Models;
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books {set; get;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Genre).IsRequired();
    }

}