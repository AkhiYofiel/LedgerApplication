using LedgerApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LedgerApplication.Data
{
    public class LedgerContext : DbContext
    {
        public LedgerContext(DbContextOptions<LedgerContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
