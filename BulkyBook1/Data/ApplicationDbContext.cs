using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BulkyBook1.Data
{
    public class ApplicationDbContext : DbContext
    {
        //pass that configuration to DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
    }
}
