using Microsoft.EntityFrameworkCore;

namespace Reservations.Persistence;

public class ReservationsDbContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public ReservationsDbContext()
    {
    }
}
