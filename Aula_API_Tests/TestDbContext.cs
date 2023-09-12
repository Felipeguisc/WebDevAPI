using Microsoft.EntityFrameworkCore;
using Aula_API.DataAccess; // Replace with your application's entity classes

namespace Aula_API_Tests.Tests
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entity classes
        public DbSet<Funcionario> Funcionarios { get; set; }
        // Add other DbSet properties for other entities as needed
    }
}
