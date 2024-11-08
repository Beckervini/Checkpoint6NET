using CP3.Application.Dtos;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP3.Application.Services
{
    public class BarcoApplicationService : IBarcoApplicationService
    {
        private readonly IBarcoRepository _repository;

        public BarcoApplicationService(IBarcoRepository repository)
        {
            _repository = repository;
        }

        public void AddBarco(BarcoDto barcoDto)
        {
            var barco = new Barco
            {
                Id = barcoDto.Id,
                Nome = barcoDto.Nome,
                Modelo = barcoDto.Modelo,
                Ano = barcoDto.Ano,
                Tamanho = barcoDto.Tamanho
            };
            _repository.Add(barco);
        }

        public void UpdateBarco(BarcoDto barcoDto)
        {
            var barco = _repository.GetById(barcoDto.Id);
            if (barco != null)
            {
                barco.Nome = barcoDto.Nome;
                barco.Modelo = barcoDto.Modelo;
                barco.Ano = barcoDto.Ano;
                barco.Tamanho = barcoDto.Tamanho;
                _repository.Update(barco);
            }
        }

        public void DeleteBarco(int id)
        {
            _repository.Delete(id);
        }

        public BarcoDto GetBarcoById(int id)
        {
            var barco = _repository.GetById(id);
            return barco == null ? null : new BarcoDto
            {
                Id = barco.Id,
                Nome = barco.Nome,
                Modelo = barco.Modelo,
                Ano = barco.Ano,
                Tamanho = barco.Tamanho
            };
        }

        public IEnumerable<BarcoDto> GetAllBarcos()
        {
            var barcos = _repository.GetAll();
            foreach (var barco in barcos)
            {
                yield return new BarcoDto
                {
                    Id = barco.Id,
                    Nome = barco.Nome,
                    Modelo = barco.Modelo,
                    Ano = barco.Ano,
                    Tamanho = barco.Tamanho
                };
            }
        }
    }
}
