using Microsoft.EntityFrameworkCore;

namespace EFCoreTphException
{
  internal class TestContext : DbContext
  {
    public TestContext()
    {
    }

    public TestContext(DbContextOptions opts) : base(opts)
    {
    }

    public DbSet<LogicalParent> LogicalParents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TestDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<EntityBase>().HasKey(x => x.Id);

      modelBuilder.Entity<LogicalParent>().HasDiscriminator<string>("Type")
        .HasValue<EntityA>("A")
        .HasValue<EntityB>("B");

      modelBuilder.Entity<EntityA>().HasBaseType<LogicalParent>();
      modelBuilder.Entity<EntityB>().HasBaseType<LogicalParent>();
    }
  }
}