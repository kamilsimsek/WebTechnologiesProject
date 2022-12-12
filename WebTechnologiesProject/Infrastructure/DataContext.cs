using Microsoft.EntityFrameworkCore;

namespace WebTechnologiesProject.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
