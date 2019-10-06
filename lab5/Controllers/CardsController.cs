using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sdayu.Api.Controllers;
using Sdayu.DAL.Contracts.DTO;
using Sdayu.DAL.Contracts.Services;
using Xunit;

namespace Sdayu.DAL.Tests.Controllers
{
    public class CardsController2
    {
        [Fact]
        public async Task Card_GetAsync_OkStatusReturned()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cardDto = new CardDTO
            {
                Id = id,
                CardNumber = "Card number"
            };
            var cardServiceMock = new Mock<ICardService>();
            var accessor = new Mock<IHttpContextAccessor>();

            cardServiceMock.Setup(repo => repo.GetAsync(id)).ReturnsAsync(cardDto);
            var cardController = new CardsController(accessor.Object, cardServiceMock.Object);

            // Act
            var result = await cardController.GetAsync(id);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(viewResult.Value, cardDto);
        }

        [Fact]
        public async Task Card_GetAsync_NotFoundStatusResultReturned()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cardServiceMock = new Mock<ICardService>();
            var accessor = new Mock<IHttpContextAccessor>();

            cardServiceMock.Setup(repo => repo.GetAsync(id)).ReturnsAsync((CardDTO) null);
            var cardController = new CardsController(accessor.Object, cardServiceMock.Object);

            // Act
            var result = await cardController.GetAsync(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        
        [Fact]
        public async Task Card_DeleteAsync_OkStatusReturned()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cardServiceMock = new Mock<ICardService>();
            var accessor = new Mock<IHttpContextAccessor>();

            cardServiceMock.Setup(repo => repo.DeleteAsync(id)).ReturnsAsync(true);
            var cardController = new CardsController(accessor.Object, cardServiceMock.Object);

            // Act
            var result = await cardController.DeleteAsync(id);

            // Assert
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async Task Card_DeleteAsync_NotFoundStatusResultReturned()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cardServiceMock = new Mock<ICardService>();
            var accessor = new Mock<IHttpContextAccessor>();

            cardServiceMock.Setup(repo => repo.DeleteAsync(id)).ReturnsAsync(false);
            var cardController = new CardsController(accessor.Object, cardServiceMock.Object);

            // Act
            var result = await cardController.DeleteAsync(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
