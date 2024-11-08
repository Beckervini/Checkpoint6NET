using CP3.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Campo obrigatório
        public string Modelo { get; set; } // Campo obrigatório
        public int Ano { get; set; }
        public double Tamanho { get; set; }

        public void Validate()
        {
            var validator = new BarcoDtoValidation();
            validator.ValidateAndThrow(this);
        }
    }

    internal class BarcoDtoValidation : AbstractValidator<BarcoDto>
    {
        public BarcoDtoValidation()
        {
            RuleFor(barco => barco.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.");

            RuleFor(barco => barco.Modelo)
                .NotEmpty()
                .WithMessage("O modelo é obrigatório.");

            RuleFor(barco => barco.Ano)
                .GreaterThan(0)
                .WithMessage("O ano deve ser maior que zero.");

            RuleFor(barco => barco.Tamanho)
                .GreaterThan(0)
                .WithMessage("O tamanho deve ser maior que zero.");
        }
    }
}
