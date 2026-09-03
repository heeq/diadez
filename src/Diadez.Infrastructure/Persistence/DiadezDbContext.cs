using Diadez.Domain.Imoveis;
using Microsoft.EntityFrameworkCore;

namespace Diadez.Infrastructure.Persistence;

public class DiadezDbContext : DbContext
{
	public DiadezDbContext(DbContextOptions<DiadezDbContext> options) : base(options)
	{
	}

	public DbSet<Imovel> Imoveis => Set<Imovel>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Imovel>(entity =>
		{
			entity.ToTable("imoveis");

			entity.HasKey(i => i.Id);

			entity.Property(i => i.Endereco)
				.IsRequired()
				.HasMaxLength(255);

			entity.Property(i => i.Complemento)
				.HasMaxLength(100);

			entity.Property(i => i.QuantidadeQuartos)
				.IsRequired();

			entity.Property(i => i.CriadoEm)
				.IsRequired();
		});

		base.OnModelCreating(modelBuilder);
	}
}