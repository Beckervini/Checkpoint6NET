using CP3.Application.Services;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace CP3.Tests
{
    public class BarcoApplicationServiceTests
    {
        private readonly Mock<IBarcoRepository> _repositoryMock;
        private readonly BarcoApplicationService _barcoService;

        public BarcoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IBarcoRepository>();
            _barcoService = new BarcoApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public void AddBarco_ShouldCallRepositoryAdd()
        {
            var barco = new Barco { Id = 1, Nome = "Barco A", Modelo = "Modelo A", Ano = 2020, Tamanho = 15.5 };

            _barcoService.AddBarco(barco);

            _repositoryMock.Verify(r => r.Add(It.Is<Barco>(b => b.Nome == barco.Nome && b.Modelo == barco.Modelo)), Times.Once);
        }

        [Fact]
        public void GetBarcoById_ShouldReturnBarco()
        {
            var barco = new Barco { Id = 1, Nome = "Barco A", Modelo = "Modelo A", Ano = 2020, Tamanho = 15.5 };
            _repositoryMock.Setup(r => r.GetById(1)).Returns(barco);

            var result = _barcoService.GetBarcoById(1);

            Assert.NotNull(result);
            Assert.Equal("Barco A", result.Nome);
        }

        [Fact]
        public void DeleteBarco_ShouldCallRepositoryDelete()
        {
            _barcoService.DeleteBarco(1);
            _repositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Fact]
        public void GetAllBarcos_ShouldReturnListOfBarcos()
        {
            var barcos = new List<Barco>
            {
                new Barco { Id = 1, Nome = "Barco A", Modelo = "Modelo A", Ano = 2020, Tamanho = 15.5 },
                new Barco { Id = 2, Nome = "Barco B", Modelo = "Modelo B", Ano = 2021, Tamanho = 20.0 }
            };
            _repositoryMock.Setup(r => r.GetAll()).Returns(barcos);

            var result = _barcoService.GetAllBarcos();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
        }
    }
}
