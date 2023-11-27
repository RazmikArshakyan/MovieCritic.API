using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCritic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        ///  Here all this stuff was written for using package manager console
        ///  and adding migration to database by Dbset's type which is 
        ///  ReqTable, and create RequestsTable table in our DB, and then using 
        ///  it through our application
        /// </summary>
        public DbSet<Entities.ReqTable> RequestsTable { get; set; }
    }
}
