using CP3.Data.AppData;
using CP3.Data.Repositories;
using CP3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace CP3.Tests
{
    public class BarcoRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly BarcoRepository _barcoRepository;

        public BarcoRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            _context = new ApplicationContext(_options);
            _barcoRepository = new BarcoRepository(_context);
        }

        [Fact]
        public void Add_ShouldAddBarco()
        {
            var barco = new Barco { Id = 1, Nome = "Barco A", Modelo = "Modelo A", Ano = 2020, Tamanho = 15.5 };

            _barcoRepository.Add(barco);
            var result = _context.Barcos.FirstOrDefault(b => b.Id == 1);

            Assert.NotNull(result);
            Assert.Equal("Barco A", result.Nome);
        }

        [Fact]
        public void GetById_ShouldReturnBarco()
        {
            var barco = new Barco { Id = 1, Nome = "Barco A", Modelo = "Modelo A", Ano = 2020, Tamanho = 15.5 };
            _context.Barcos.Add(barco);
            _context.SaveChanges();

            var result = _barcoRepository.GetById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Delete_ShouldRemoveBarco()
        {
            var barco = new Barco { Id = 1, Nome = "Barco A", Modelo = "Modelo A", Ano = 2020, Tamanho = 15.5 };
            _context.Barcos.Add(barco);
            _context.SaveChanges();

            _barcoRepository.Delete(1);
            var result = _context.Barcos.FirstOrDefault(b => b.Id == 1);

            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ShouldReturnAllBarcos()
        {
            _context.Barcos.Add(new Barco { Id = 1, Nome = "Barco A", Modelo = "Modelo A", Ano = 2020, Tamanho = 15.5 });
            _context.Barcos.Add(new Barco { Id = 2, Nome = "Barco B", Modelo = "Modelo B", Ano = 2021, Tamanho = 20.0 });
            _context.SaveChanges();

            var result = _barcoRepository.GetAll();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }
    }
}
