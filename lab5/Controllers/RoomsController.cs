//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Sdayu.Api.Controllers;
//using Sdayu.DAL.Contracts.DTO;
//using Sdayu.DAL.Contracts.Services;
//using Xunit;

//namespace Sdayu.DAL.Tests.Controllers
//{
//    public class RoomsControllerTests
//    {
//        private Guid firstRoomId = new Guid();
//        private Guid hotelId = new Guid();
//        private Guid secondRoomId = new Guid();


//        [Fact]
//        public async Task Rooms_GetById_OkStatusWithValidRoomDtoModelReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            var roomDTO = GetRoomDTO();
//            roomsServiceMock.Setup(repo => repo.GetAsync(firstRoomId)).ReturnsAsync(roomDTO);
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.GetAsync(firstRoomId);

//            // Assert
//            var viewResult = Assert.IsType<OkObjectResult>(result);
//            Assert.Equal(viewResult.Value, roomDTO);
//        }

//        [Fact]
//        public async Task Rooms_GetById_NotFoundResultReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.GetAsync(It.IsAny<Guid>())).ReturnsAsync((RoomDTO) null);
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.GetAsync(It.IsAny<Guid>());

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }

//        [Fact]
//        public async Task Rooms_GetById_RoomServiceGetAsyncTimesOnce()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            roomsServiceMock.Setup(repo => repo.GetAsync(It.IsAny<Guid>())).ReturnsAsync((RoomDTO) null);
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            await roomsController.GetAsync(It.IsAny<Guid>());

//            // Verify
//            roomsServiceMock.Verify(service => service.GetAsync(It.IsAny<Guid>()), Times.Once());
//        }

//        [Fact]
//        public async Task Rooms_GetAll_OkStatusWithValidRoomDtoModelsReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var roomDtOs = GetRoomDTOs();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(roomDtOs);
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.GetAllAsync();

//            // Assert
//            var viewResult = Assert.IsType<OkObjectResult>(result);
//            Assert.Equal(viewResult.Value, roomDtOs);
//        }

//        [Fact]
//        public async Task Rooms_GetById_RoomServiceGetAllAsyncTimesOnce()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(It.IsAny<ICollection<RoomDTO>>());
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            await roomsController.GetAllAsync();

//            // Verify
//            roomsServiceMock.Verify(service => service.GetAllAsync(), Times.Once());
//        }

//        [Fact]
//        public async Task Rooms_DeleteById_OkObjectResultReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.DeleteAsync(firstRoomId)).ReturnsAsync(true);
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.DeleteAsync(firstRoomId);

//            // Assert
//            Assert.IsType<OkResult>(result);
//        }

//        [Fact]
//        public async Task Rooms_DeleteById_NotFoundObjectResultReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.DeleteAsync(firstRoomId)).ReturnsAsync(false);
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.DeleteAsync(firstRoomId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }

//        [Fact]
//        public async Task Rooms_DeleteById_RoomServiceDeleteAsyncTimesOnce()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(It.IsAny<bool>());
//            var RoomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            await RoomsController.DeleteAsync(It.IsAny<Guid>());

//            // Verify
//            roomsServiceMock.Verify(service => service.DeleteAsync(It.IsAny<Guid>()), Times.Once());
//        }
        
//        [Fact]
//        public async Task Rooms_BookAsync_BadRequestReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.BookAsync("Id", getBookingDtos(true).ToList())).ReturnsAsync(new List<RoomDTO>());
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.DeleteAsync(firstRoomId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }

//        [Fact]
//        public async Task Rooms_DeleteById_NotFoundResultReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var filterDto = GetFilterDTO();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.DeleteAsync(firstRoomId)).ReturnsAsync(false);
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.DeleteAsync(firstRoomId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }
        
//        [Fact]
//        public async Task Rooms_DeleteById_CreatedResultReturned()
//        {
//            // Arrange
//            var roomsServiceMock = new Mock<IRoomService>();
//            var httpContextAccessor = new Mock<IHttpContextAccessor>();
//            roomsServiceMock.Setup(repo => repo.DeleteAsync(firstRoomId)).ReturnsAsync(false);
//            var roomsController = new RoomsController(httpContextAccessor.Object, roomsServiceMock.Object);

//            // Act
//            var result = await roomsController.DeleteAsync(firstRoomId);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }

//        private IEnumerable<BookingDTO> getBookingDtos(bool isValid)
//        {
//            return isValid ? 
//                new List<BookingDTO>
//                {
//                    new BookingDTO
//                    {
//                        DateToUtc = DateTime.Now.AddDays(5),
//                        DateFromUtc = DateTime.Now.AddDays(3),
//                        Adults = 2,
//                        Children = 3,
//                        RoomId = Guid.NewGuid()
//                    },
//                    new BookingDTO
//                    {
//                        DateToUtc = DateTime.Now.AddDays(6),
//                        DateFromUtc = DateTime.Now.AddDays(3),
//                        Adults = 3,
//                        Children = 2,
//                        RoomId = Guid.NewGuid()
//                    }
//                }: null;
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

//        private List<RoomDTO> GetRoomDTOs()
//        {
//            return new List<RoomDTO>
//            {
//                new RoomDTO
//                {
//                    Description = "Good Room",
//                    Id = firstRoomId,
//                    Price = 199,
//                    Title = "Title",
//                    HotelId = hotelId,
//                    BedDescription = "Bed description",
//                    PeopleCount = 3,
//                    RoomType = "Lux",
//                    Images = new List<AzureImageDTO>
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
//                    }
//                },

//                new RoomDTO
//                {
//                    Description = "Good Room",
//                    Id = secondRoomId,
//                    Price = 199,
//                    Title = "Title",
//                    HotelId = hotelId,
//                    BedDescription = "Bed description",
//                    PeopleCount = 3,
//                    RoomType = "Lux",
//                    Images = new List<AzureImageDTO>
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
//                },
//            };
//        }

//        private RoomDTO GetRoomDTO()
//        {
//            return new RoomDTO
//            {
//                Description = "Good Room",
//                Id = firstRoomId,
//                Price = 199,
//                Title = "Title",
//                HotelId = hotelId,
//                BedDescription = "Bed description",
//                PeopleCount = 3,
//                RoomType = "Lux",
//                Images = new List<AzureImageDTO>
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
//            };
//        }
//    }
//}