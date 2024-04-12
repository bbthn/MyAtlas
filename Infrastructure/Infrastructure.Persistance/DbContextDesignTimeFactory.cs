using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistance
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<DataContext>
    {
         private readonly string ConnectionString = "Data Source=DESKTOP-QSHBLNM\\MSSQLSERVER2022;Initial Catalog=MyAtlas;Integrated Security=true;TrustServerCertificate=true";
        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(ConnectionString);
            return new DataContext(builder.Options);
        }
    }
}
