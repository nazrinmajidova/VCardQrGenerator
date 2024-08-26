using Microsoft.EntityFrameworkCore;
using VCardQr.Models;

namespace VCardQr.Data;

public class VCardQrDbContext : DbContext
{
    public VCardQrDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<VCard> VCards { get; set; }
}
