using GeradorCartao.Models;
using Microsoft.EntityFrameworkCore;

namespace GeradorCartao.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cartao> Cartoes { get; set; }
    }
}