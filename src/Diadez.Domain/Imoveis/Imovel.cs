namespace Diadez.Domain.Imoveis;

public class Imovel
{
	public Guid Id { get; private set; }
	public string Endereco { get; private set; } = string.Empty;
	public string? Complemento { get; private set; }
	public int QuantidadeQuartos { get; private set; }
	public DateTime CriadoEm { get; private set; }

	// EF Core exige um construtor sem parâmetros (mesmo privado) para materializar objetos vindos do banco
	private Imovel() { }

	public Imovel(string endereco, int quantidadeQuartos, string? complemento = null)
	{
		if (string.IsNullOrWhiteSpace(endereco))
			throw new ArgumentException("Endereço é obrigatório", nameof(endereco));

		Id = Guid.NewGuid();
		Endereco = endereco;
		Complemento = complemento;
		QuantidadeQuartos = quantidadeQuartos;
		CriadoEm = DateTime.UtcNow;
	}
}