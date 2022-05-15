using Microsoft.EntityFrameworkCore;
using Taksimeter.DataAccess.Models;

namespace Taksimeter.DataAccess
{
    public class TaksimeterDBContext : DbContext
    {
        public DbSet<TaksimeterInfoModel> TaksimeterInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseOracle(@"User Id = cw; Password = cw; Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA =(SERVICE_NAME = xe) (SERVER = DEDICATED)));");
        }
    }
}
