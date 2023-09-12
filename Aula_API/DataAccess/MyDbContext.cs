using Microsoft.EntityFrameworkCore;

namespace Aula_API.DataAccess;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    // Add DbSet properties for other entities as needed

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Funcionario table
        modelBuilder.Entity<Funcionario>()
            .ToTable("Funcionario"); // Set the table name
        modelBuilder.Entity<Funcionario>()
            .Property(f => f.Grupo)
            .HasColumnType("tinyint"); // Set the data type for Grupo property

        // Configure Cliente table
        modelBuilder.Entity<Cliente>()
            .ToTable("Cliente"); // Set the table name
        modelBuilder.Entity<Cliente>()
            .Property(c => c.CompraFiado)
            .HasColumnType("int"); // Set the data type for CompraFiado property
        modelBuilder.Entity<Cliente>()
            .Property(c => c.DiaFiado)
            .HasColumnType("tinyint"); // Set the data type for DiaFiado property

        // Configure Produto table
        modelBuilder.Entity<Produto>()
            .ToTable("Produto"); // Set the table name
        modelBuilder.Entity<Produto>()
            .Property(p => p.ValorUnitario)
            .HasColumnType("decimal(18, 2)"); // Set the data type for ValorUnitario property

        // Add any additional configurations, such as indexes or relationships, here
    }

}