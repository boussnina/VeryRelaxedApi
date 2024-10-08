using Microsoft.EntityFrameworkCore;
using System.Xml;
using VeryRelaxedApi.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Footballer> Footballers { get; set; }

    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Referee> Referees { get; set; }
}
