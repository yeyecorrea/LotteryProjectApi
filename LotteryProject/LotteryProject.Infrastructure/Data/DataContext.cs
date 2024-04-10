using LotteryProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryProject.Infrastructure.Data;

/// <summary>
/// Clase que contiene el contexto o la instancia a la base de datos
/// </summary>
public class DataContext : DbContext
{
    public DataContext(){}
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

	public DbSet<Lottery> lotteries { get; set; }
	public DbSet<Chance> chances { get; set; }
	public DbSet<Raffle> raffles { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		optionsBuilder.UseSqlServer("Data Source=DESKTOP-8AODM1Q\\SQLEXPRESS;Initial Catalog=Lottery;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		base.OnConfiguring(optionsBuilder);
    }

    // Configuraciones al modelo antes de crearlo
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Chance>()
	   .HasOne(c => c.Lottery)
	   .WithOne(l => l.Chance)
	   .HasForeignKey<Chance>(c => c.LotteryId)
	   .OnDelete(DeleteBehavior.Cascade);
	}


}
