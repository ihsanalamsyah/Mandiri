using Mandiri.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace JIWA.DataAccess
{
    public class PGDBContext : DbContext
    {

        public PGDBContext(DbContextOptions<PGDBContext> options) : base(options)
        {
        }


        #region Additional

        public DbSet<Instructor> Instructors { get; set; }

        #endregion

       
    }
}