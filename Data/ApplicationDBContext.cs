using bascicASP.Models;
using Microsoft.EntityFrameworkCore;

namespace bascicASP.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){ 

        }
        //model Student create a database table name Students by reference the column from Student model properties and store in StudentDB
        //represent Students table in DB
        public DbSet<Student> Students { get; set; } 
    }
}
