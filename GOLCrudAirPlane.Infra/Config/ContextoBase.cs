using GOLCrudAirplane.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GOLCrudAirplane.Infra.Config
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConnectionConfig());
            }

        }

        public DbSet<Airplane> Airplane { get; set; }

        private string StringConnectionConfig()
        {
            string stringConnect = "Data Source=(local)\\SQLEXPRESS;Database=AirplaneDB;Trusted_Connection=True;Integrated Security=True;MultipleActiveResultSets=True;";

            return stringConnect;
        }
    }
}
