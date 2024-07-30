using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeLembretes.Models;
using SistemaDeNotas.Controllers;

namespace TestesUnitarios
{
 

    public class LembreteControllerTests
    {
        private readonly DbContextOptions<ContextoDB> _dbContextOptions;

        public LembreteControllerTests() => _dbContextOptions = new DbContextOptionsBuilder<ContextoDB>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

        [Fact]
        public async Task GetLembretes_ReturnsOkResult_WithListOfLembretes()
        {
            // Arrange
            using (var context = new ContextoDB(_dbContextOptions))
            {
                context.Lembretes.Add(new Lembrete { Id = 1, Nome = "Test Lembrete 1" });
                context.Lembretes.Add(new Lembrete { Id = 2, Nome = "Test Lembrete 2" });
                context.SaveChanges();
            }

            using (var context = new ContextoDB(_dbContextOptions))
            {
                var controller = new NotaController(context);

                // Act
                var result = await controller.GetNotas();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<Lembrete>>(okResult.Value);
                Assert.Equal(2, returnValue.Count);
            }
        }

        [Fact]
        public async Task AddLembrete_ReturnsCreatedAtActionResult_WithLembrete()
        {
            // Arrange
            using (var context = new ContextoDB(_dbContextOptions))
            {
                var controller = new NotaController(context);
                var newLembrete = new Lembrete { Id = 3, Nome = "Test Lembrete 3" };

                // Act
                var result = await controller.AddNota(newLembrete);

                // Assert
                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
                var returnValue = Assert.IsType<Lembrete>(createdAtActionResult.Value);
                Assert.Equal(newLembrete.Id, returnValue.Id);
            }
        }

        [Fact]
        public async Task DeleteLembrete_ReturnsNoContentResult_WhenLembreteIsDeleted()
        {
            // Arrange
            using (var context = new ContextoDB(_dbContextOptions))
            {
                context.Lembretes.Add(new Lembrete { Id = 4, Nome = "Test Lembrete 4" });
                context.SaveChanges();
            }

            using (var context = new ContextoDB(_dbContextOptions))
            {
                var controller = new NotaController(context);

                // Act
                var result = await controller.DeleteNota(4);

                // Assert
                Assert.IsType<NoContentResult>(result.Result);
            }
        }

        [Fact]
        public async Task DeleteLembrete_ReturnsNotFoundResult_WhenLembreteDoesNotExist()
        {
            // Arrange
            using (var context = new ContextoDB(_dbContextOptions))
            {
                var controller = new NotaController(context);

                // Act
                var result = await controller.DeleteNota(5);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }
    }
}