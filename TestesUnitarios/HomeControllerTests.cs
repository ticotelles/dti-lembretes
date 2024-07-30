using meu_sistema_tarefas.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using sistema_de_lembretes.Models;


namespace sistema_de_lembretes.Tests
{
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<MainController>> _mockLogger;
        private readonly MainController _controller;

        public HomeControllerTests()
        {
            _mockLogger = new Mock<ILogger<MainController>>();
            _controller = new MainController(_mockLogger.Object);
        }

        [Fact]
        public void Error_ReturnsAViewResult_WithErrorViewModel()
        {
            // Arrange
            var context = new Mock<HttpContext>();
            var traceIdentifier = "trace-id";
            context.Setup(x => x.TraceIdentifier).Returns(traceIdentifier);

            var controllerContext = new ControllerContext
            {
                HttpContext = context.Object
            };

            _controller.ControllerContext = controllerContext;

            // Act
            var result = _controller.Error();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
            Assert.Equal(traceIdentifier, model.RequestId);
        }
    }
}