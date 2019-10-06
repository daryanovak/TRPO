//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Sdayu.Api.Controllers;
//using Sdayu.DAL.Contracts.DTO;
//using Sdayu.DAL.Contracts.Services;
//using Xunit;
//using Assert = Xunit.Assert;

//namespace Sdayu.DAL.Tests.Controllers
//{
//    public class HotelController
//    {
//        private Guid firstHotelId = new Guid();
//        private Guid secondHotelId = new Guid();
//        private Guid thirdHotelId = new Guid();


//        [Fact]
//        public async Task Hotels_GetById_OkStatusWithValidHotelDtoModelReturned()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            var hotelDTO = GetHotelDTO();
//            hotelsServiceMock.Setup(repo => repo.GetAsync(firstHotelId)).ReturnsAsync(hotelDTO);
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            var result = await hotelsController.GetAsync(firstHotelId);

//            // Assert
//            var viewResult = Assert.IsType<OkObjectResult>(result);
//            Assert.Equal(viewResult.Value, hotelDTO);
//        }

//        [Fact]
//        public async Task Hotels_GetById_NotFoundResultReturned()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            hotelsServiceMock.Setup(repo => repo.GetAsync(It.IsAny<Guid>())).ReturnsAsync((HotelDTO) null);
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            var result = await hotelsController.GetAsync(It.IsAny<Guid>());

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }

//        [Fact]
//        public async Task Hotels_GetById_HotelServiceGetAsyncTimesOnce()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            hotelsServiceMock.Setup(repo => repo.GetAsync(It.IsAny<Guid>())).ReturnsAsync((HotelDTO) null);
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            await hotelsController.GetAsync(It.IsAny<Guid>());

//            // Verify
//            hotelsServiceMock.Verify(service => service.GetAsync(It.IsAny<Guid>()), Times.Once());
//        }

//        [Fact]
//        public async Task Hotels_GetAll_OkStatusWithValidHotelDtoModelsReturned()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            var hotelDTOs = GetHotelDTOs();
//            hotelsServiceMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(hotelDTOs);
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            var result = await hotelsController.GetAllAsync();

//            // Assert
//            var viewResult = Assert.IsType<OkObjectResult>(result);
//            Assert.Equal(viewResult.Value, hotelDTOs);
//        }

//        [Fact]
//        public async Task Hotels_GetById_HotelServiceGetAllAsyncTimesOnce()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            hotelsServiceMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(It.IsAny<ICollection<HotelDTO>>());
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            await hotelsController.GetAllAsync();

//            // Verify
//            hotelsServiceMock.Verify(service => service.GetAllAsync(), Times.Once());
//        }
        
//        [Fact]
//        public async Task Hotels_DeleteById_OkObjectResultReturned()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            hotelsServiceMock.Setup(repo => repo.DeleteAsync(firstHotelId)).ReturnsAsync(true);
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            var result = await hotelsController.DeleteAsync(firstHotelId);

//            // Assert
//            Assert.IsType<OkResult>(result);
//        }
        
//        [Fact]
//        public async Task Hotels_DeleteById_NotFoundObjectResultReturned()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            hotelsServiceMock.Setup(repo => repo.DeleteAsync(firstHotelId)).ReturnsAsync(false);
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            var result = await hotelsController.DeleteAsync(firstHotelId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }
        
//        [Fact]
//        public async Task Hotels_GetWithFilter_OkResultReturned()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            var filter = GetFilterDTO();
//            var hotelDTOs = GetHotelDTOs();
//            hotelsServiceMock.Setup(repo => repo.GetFilteredAsync(filter)).ReturnsAsync(hotelDTOs);
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            var result = await hotelsController.GetFilteredAsync(filter);

//            // Assert
//            var viewModel = Assert.IsType<OkObjectResult>(result);
//            Assert.Equal(viewModel.Value, hotelDTOs);
//        }

//        [Fact]
//        public async Task Hotels_DeleteById_HotelServiceDeleteAsyncTimesOnce()
//        {
//            // Arrange
//            var hotelsServiceMock = new Mock<IHotelService>();
//            hotelsServiceMock.Setup(repo => repo.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(It.IsAny<bool>());
//            var hotelsController = new HotelsController(hotelsServiceMock.Object);

//            // Act
//            await hotelsController.DeleteAsync(It.IsAny<Guid>());

//            // Verify
//            hotelsServiceMock.Verify(service => service.DeleteAsync(It.IsAny<Guid>()), Times.Once());
//        }

//        private FilterDTO GetFilterDTO()
//        {
//            return new FilterDTO
//            {
//                RoomsCount = 2,
//                Adults = 1,
//                Children = 2,
//                City = "Minsk",
//                DateFromUtc = new DateTime(),
//                DateToUtc = new DateTime().AddDays(5)
//            };
//        }

//        private List<HotelDTO> GetHotelDTOs()
//        {
//            return new List<HotelDTO>
//            {
//                new HotelDTO
//                {
//                    Description = "Good hotel",
//                    Id = firstHotelId,
//                    AzureImages = new List<AzureImageDTO>
//                    {
//                        new AzureImageDTO
//                        {
//                            Id = new Guid(),
//                            Url = "url1"
//                        },
//                        new AzureImageDTO
//                        {
//                            Id = new Guid(),
//                            Url = "url2"
//                        }
//                    },
//                    Rating = 5,
//                    Title = "first hotel",
//                    AddressCode = "223554",
//                    HotelType = "Hostel",
//                    MinPrice = 50
//                },
//                new HotelDTO
//                {
//                    Description = "Good hotel second",
//                    Id = secondHotelId,
//                    AzureImages = new List<AzureImageDTO>
//                    {
//                        new AzureImageDTO
//                        {
//                            Id = new Guid(),
//                            Url = "url1"
//                        },
//                        new AzureImageDTO
//                        {
//                            Id = new Guid(),
//                            Url = "url2"
//                        }
//                    },
//                    Rating = 4,
//                    Title = "second hotel",
//                    AddressCode = "223524",
//                    HotelType = "Hostel 2",
//                    MinPrice = 100
//                },
//            };
//        }

//        private HotelDTO GetHotelDTO()
//        {
//            return new HotelDTO
//            {
//                Description = "Good hotel",
//                Id = firstHotelId,
//                AzureImages = new List<AzureImageDTO>
//                {
//                    new AzureImageDTO
//                    {
//                        Id = new Guid(),
//                        Url = "url1"
//                    },
//                    new AzureImageDTO
//                    {
//                        Id = new Guid(),
//                        Url = "url2"
//                    }
//                },
//                Rating = 5,
//                Title = "first hotel",
//                AddressCode = "223554",
//                HotelType = "Hostel",
//                MinPrice = 50
//            };
//        }
//    }
//}