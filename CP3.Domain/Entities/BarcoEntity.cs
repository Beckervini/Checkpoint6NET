using System.ComponentModel.DataAnnotations;

public class BarcoEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public double Tamanho { get; set; }
}
