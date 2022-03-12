#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rocToURL.Models;

namespace rocToURL.Data
{
    public class rocToURLContext : DbContext
    {
        public rocToURLContext (DbContextOptions<rocToURLContext> options)
            : base(options)
        {
        }

        public DbSet<rocToURL.Models.URL> URL { get; set; }
    }
}
