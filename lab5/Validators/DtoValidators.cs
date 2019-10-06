using System;
using System.Threading.Tasks;
using Sdayu.Api.Validators;
using Sdayu.DAL.Contracts.DTO;
using Xunit;

namespace Sdayu.DAL.Tests.Validators
{
    public class DtoValidators
    {
        BookingValidator _bookingValidator = new BookingValidator();
        DepositValidator _depositValidator = new DepositValidator();
        UserDataValidator _userDataValidator = new UserDataValidator();
        UserValidator _userValidator = new UserValidator();

        [Fact]
        public async Task UserDataValidator_ValidUserDataDto_ValidResultReturned()
        {
            // Arrange
            var userData = GetUserDataDTO(true);

            // Act
            var result = await _userDataValidator.ValidateAsync(userData);

            // Verify
            Assert.True(result.IsValid);
        }
        
        [Fact]
        public async Task UserDataValidator_ValidUserDataDto_NotValidResultReturned()
        {
            // Arrange
            var userDataDTO = GetUserDataDTO(false);

            // Act
            var result = await _userDataValidator.ValidateAsync(userDataDTO);

            // Verify
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task UserValidator_ValidUserDto_ValidResultReturned()
        {
            // Arrange
            var user = GetUserDTO(true);

            // Act
            var result = await _userValidator.ValidateAsync(user);

            // Verify
            Assert.True(result.IsValid);
        }
        
        [Fact]
        public async Task UserValidator_ValidUserDto_NotValidResultReturned()
        {
            // Arrange
            var user = GetUserDTO(false);

            // Act
            var result = await _userValidator.ValidateAsync(user);

            // Verify
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task DepositValidator_ValidDepositDto_ValidResultReturned()
        {
            // Arrange
            var depositDTO = GetDepositDTO(true);

            // Act
            var result = await _depositValidator.ValidateAsync(depositDTO);

            // Verify
            Assert.True(result.IsValid);
        }
        
        [Fact]
        public async Task DepositValidator_ValidDepositDto_NotValidResultReturned()
        {
            // Arrange
            var deposit = GetDepositDTO(false);

            // Act
            var result = await _depositValidator.ValidateAsync(deposit);

            // Verify
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task BookingValidator_ValidBookingDto_ValidResultReturned()
        {
            // Arrange
            var booking = GetBookingDTO(true);

            // Act
            var result = await _bookingValidator.ValidateAsync(booking);

            // Verify
            Assert.True(result.IsValid);
        }
        
        [Fact]
        public async Task BookingValidator_ValidBookingDto_NotValidResultReturned()
        {
            // Arrange
            var booking = GetBookingDTO(false);

            // Act
            var result = await _bookingValidator.ValidateAsync(booking);

            // Verify
            Assert.False(result.IsValid);
        }
        
        private UserDTO GetUserDTO(bool isValid)
        {
            return isValid
                ? new UserDTO
                {
                    UserName = "Lol",
                    Password = "password"
                }
                : new UserDTO
                {
                    UserName = "Kek",
                    Password = ""
                };
        }

        private UserDataDTO GetUserDataDTO(bool isValid)
        {
            return isValid
                ? new UserDataDTO
                {
                    UserName = "Lol",
                    Password = "password"
                }
                : new UserDataDTO
                {
                    UserName = "Kek",
                    Password = ""
                };
        }
        
        private DepositDTO GetDepositDTO(bool isValid)
        {
            return isValid
                ? new DepositDTO
                {
                    CardId = Guid.NewGuid(),
                    Amount = 10000.0
                }
                : new DepositDTO
                {
                    CardId = new Guid(),
                    Amount = 1110
                };
        }
        
        private BookingDTO GetBookingDTO(bool isValid)
        {
            return isValid
                ? new BookingDTO
                {
                    RoomId = Guid.NewGuid(),
                    DateFromUtc = DateTime.Now.AddDays(1),
                    DateToUtc = DateTime.Now.AddDays(10),
                }
                : new BookingDTO
                {
                    RoomId = new Guid(),
                    DateFromUtc = DateTime.Now.AddDays(2),
                    DateToUtc = DateTime.Now.AddDays(1),
                };
        }
    }
}