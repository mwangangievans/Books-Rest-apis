
using BookApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Data
{
    public class apiDbContent : DbContext
    {
        public DbSet<Book>Books { get; set; }
        public apiDbContent(DbContextOptions<apiDbContent> options) : base(options)
        {

        }
    }
}
