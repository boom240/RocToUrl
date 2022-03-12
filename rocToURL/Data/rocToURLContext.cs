#nullable disable
using Microsoft.EntityFrameworkCore;

namespace rocToURL.Data
{
    public class rocToURLContext : DbContext
    {
        public rocToURLContext (DbContextOptions<rocToURLContext> options)
            : base(options)
        {
        }

        public DbSet<rocToURL.Entities.Models.URL> URL { get; set; }
    }
}
