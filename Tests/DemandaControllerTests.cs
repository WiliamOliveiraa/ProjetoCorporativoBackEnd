using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCorporativo.Controllers;
using ProjetoCorporativo.Data;
using ProjetoCorporativo.Models;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoCorporativo.Tests
{
    public class DemandaControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly DemandaController _controller;

        public DemandaControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _controller = new DemandaController(_context);
        }

        [Fact]
        public async Task PostDemanda_AddsDemanda()
        {
            // Arrange
            var demanda = new Demanda
            {
                Titulo = "Test Demanda",
                Descricao = "Descrição de teste",
                Status = "Aberta",
                Prazo = System.DateTime.Now.AddDays(5)
            };

            // Act
            var result = await _controller.PostDemanda(demanda);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Demanda>(createdAtActionResult.Value);
            Assert.Equal("Test Demanda", returnValue.Titulo);
        }

    }
}
