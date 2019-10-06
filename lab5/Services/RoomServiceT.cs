using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using Sdayu.Api.Automapper;
using Sdayu.DAL.Contracts;
using Sdayu.DAL.Contracts.DTO;
using Sdayu.DAL.Contracts.Repositories;
using Sdayu.DAL.Tests.Factories;
using Sdayu.DAL.Types.Domain;
using Sdayu.DAL.Types.Services;
using Xunit;

namespace Sdayu.DAL.Tests.Services
{
    public class RoomService
    {
        private readonly Hotel _hotel;
        private readonly HotelType _hotelType;
        private readonly Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();
        private readonly Mock<IRepository<Hotel, Guid>> unitOfWorkHotelRepository = new Mock<IRepository<Hotel, Guid>>();
        private readonly Mock<IRepository<City, Guid>> unitOfWorkCityRepository = new Mock<IRepository<City, Guid>>();
        private readonly Mock<IRepository<HotelType, Guid>> unitOfWorkHotelTypeRepository = new Mock<IRepository<HotelType, Guid>>();
        private readonly Mock<IRepository<HotelImage, Guid>> unitOfWorkHotelImageRepository = new Mock<IRepository<HotelImage, Guid>>();
        private readonly Mock<IOptions<AzureStorageSettings>> azureStorageSettings = new Mock<IOptions<AzureStorageSettings>>();
        
        public RoomService()
        {
            _hotelType = new HotelType {Id = new Guid(), Title = "Test hotel type"};
            _hotel = HotelFactory.Create()
                .WithTitle("Test hotel")
                .WithCity()
                .WithComments()
                .WithDescription("Test hotel description")
                .WithRating(5.0)
                .WithRooms(new List<Room>{RoomFactory.Create()
                            .WithDescription("Description")
                            .WithPrice(1222)
                            .WithRooms("rooms description")
                            .WithTitle("title")
                            .WithPeopleCount(5)
                            .WithRoomType(new RoomType{ Title = "title"})
                            //ToDo .WithImageRoomId(Guid.NewGuid())
                            .WithRoomTypeId(Guid.NewGuid())})
                .WithHotelType(_hotelType)
                .WithHotelTypeId(_hotelType.Id)
                .WithImageHotelId();
        }

        [Fact]
        public async Task RoomService_GetAllAsync_EmptyCollectionReturned()
        {
            // Arrange
            var hotelRepository = new Mock<IRepository<Hotel, Guid>>();

            var unitOfWork = new Mock<IUnitOfWork>();
            hotelRepository.Setup(r => r.GetQueryable(true)).Returns(new List<Hotel>().AsQueryable());

            var hotelService = new HotelService(unitOfWork.Object,
                unitOfWorkHotelRepository.Object,
                unitOfWorkCityRepository.Object,
                unitOfWorkHotelTypeRepository.Object,
                unitOfWorkHotelImageRepository.Object,
                azureStorageSettings.Object);
            
            // Act

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await hotelService.GetAllAsync());
        }
        
//        public HotelService(IUnitOfWork unitOfWork, IRepository<Hotel, Guid> hotelRepository,
//            IRepository<City, Guid> cityRepository, IRepository<HotelType, Guid> hotelTypeRepository,
//            IRepository<HotelImage, Guid> hotelImageRepository, IOptions<AzureStorageSettings> azureStorageSettings)

        [Fact]
        public async Task RoomService_GetAsync_EmptyCollectionReturned()
        {
            // Arrange
            var hotelRepository = new Mock<IRepository<Hotel, Guid>>();
            var m = new Mock<IQueryable<HotelDTO>>();
            
            hotelRepository.Setup(r => r.GetQueryable(true)).Returns(new List<Hotel>().AsQueryable());
            var hotelService = new HotelService(unitOfWork.Object,
                unitOfWorkHotelRepository.Object,
                unitOfWorkCityRepository.Object,
                unitOfWorkHotelTypeRepository.Object,
                unitOfWorkHotelImageRepository.Object,
                azureStorageSettings.Object);
            // Act

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await hotelService.GetAsync(_hotel.Id));
        }

        [Fact]
        public async Task RoomService_DeleteAsync_EmptyCollectionReturned()
        {
            // Arrange
            var hotelRepository = new Mock<IRepository<Hotel, Guid>>();
            var m = new Mock<IQueryable<HotelDTO>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            hotelRepository.Setup(r => r.GetQueryable(true)).Returns(new List<Hotel>().AsQueryable());
            var hotelService = new HotelService(unitOfWork.Object,
                unitOfWorkHotelRepository.Object,
                unitOfWorkCityRepository.Object,
                unitOfWorkHotelTypeRepository.Object,
                unitOfWorkHotelImageRepository.Object,
                azureStorageSettings.Object);
            // Act

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await hotelService.DeleteAsync(_hotel.Id));
        }

        [Fact]
        public async Task RoomService_DeleteAllAsync_EmptyCollectionReturned()
        {
            // Arrange
            var hotelRepository = new Mock<IRepository<Hotel, Guid>>();

            var unitOfWork = new Mock<IUnitOfWork>();

            hotelRepository.Setup(r => r.GetQueryable(true)).Returns(new List<Hotel> {_hotel}.AsQueryable());

//            hotelRepository.Setup(r =>
//                    r.GetQueryable(true)
//                        .FirstOrDefaultAsync(It.IsAny<Expression<Func<Hotel, bool>>>(), CancellationToken.None))
//                .ReturnsAsync(_hotel);
            
            var hotelService = new HotelService(unitOfWork.Object,
                unitOfWorkHotelRepository.Object,
                unitOfWorkCityRepository.Object,
                unitOfWorkHotelTypeRepository.Object,
                unitOfWorkHotelImageRepository.Object,
                azureStorageSettings.Object);
            
            // Act

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await hotelService.DeleteAsync(_hotel.Id));
        }

        [Fact]
        public async Task RoomService_GetFilteredAsync_EmptyCollectionReturned()
        {
            // Arrange
            var hotelRepository = new Mock<IRepository<Hotel, Guid>>();
            var m = new Mock<IQueryable<HotelDTO>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            hotelRepository.Setup(r => r.GetQueryable(true)).Returns(new List<Hotel>().AsQueryable());
            var hotelService = new HotelService(unitOfWork.Object,
                unitOfWorkHotelRepository.Object,
                unitOfWorkCityRepository.Object,
                unitOfWorkHotelTypeRepository.Object,
                unitOfWorkHotelImageRepository.Object,
                azureStorageSettings.Object);
            // Act

            // Assert
            var filterDto = new FilterDTO
            {
                City = "Minsk",
                RoomsCount = _hotel.Rooms.Count,
                DateToUtc = DateTime.Now.AddDays(10),
                DateFromUtc = DateTime.Now.AddDays(5),
                Adults = 2,
                Children = 3
            };
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await hotelService.GetFilteredAsync(filterDto));
        }
    }
}