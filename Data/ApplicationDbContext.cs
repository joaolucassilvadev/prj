using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using prj.Models;

namespace prj.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
            
        }


        public DbSet <SimuladorModels> Simulador { get; set;}

        public DbSet <EmprestimoModel> Emprestimo { get; set;}   
    }
}
