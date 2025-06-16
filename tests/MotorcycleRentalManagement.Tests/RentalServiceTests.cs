using Xunit;
using Moq;
using MotorcycleRentalManagement.Application.Services;
using MotorcycleRentalManagement.Domain.Entities;
using MotorcycleRentalManagement.Infrastructure.MongoDb;
using System.Collections.Generic;

namespace MotorcycleRentalManagement.Tests
{
    public class RentalServiceTests
    {
        private readonly RentalService _rentalService;
        private readonly Mock<IMotorcycleRepository> _mockRepository;

        public RentalServiceTests()
        {
            _mockRepository = new Mock<IMotorcycleRepository>();
            _rentalService = new RentalService(_mockRepository.Object);
        }

        [Fact]
        public void RentMotorcycle_ShouldRentMotorcycle_WhenValidMotorcycleId()
        {
            // Arrange
            var motorcycleId = "valid-id";
            var motorcycle = new Motorcycle { Id = motorcycleId, IsRented = false };
            _mockRepository.Setup(repo => repo.GetMotorcycleById(motorcycleId)).Returns(motorcycle);

            // Act
            var result = _rentalService.RentMotorcycle(motorcycleId);

            // Assert
            Assert.True(result);
            Assert.True(motorcycle.IsRented);
        }

        [Fact]
        public void ReturnMotorcycle_ShouldReturnMotorcycle_WhenValidMotorcycleId()
        {
            // Arrange
            var motorcycleId = "valid-id";
            var motorcycle = new Motorcycle { Id = motorcycleId, IsRented = true };
            _mockRepository.Setup(repo => repo.GetMotorcycleById(motorcycleId)).Returns(motorcycle);

            // Act
            var result = _rentalService.ReturnMotorcycle(motorcycleId);

            // Assert
            Assert.True(result);
            Assert.False(motorcycle.IsRented);
        }

        [Fact]
        public void CalculateRentalCost_ShouldReturnCorrectCost_WhenValidInput()
        {
            // Arrange
            var rentalDays = 5;
            var expectedCost = 100; // Assuming a cost of 20 per day

            // Act
            var result = _rentalService.CalculateRentalCost(rentalDays);

            // Assert
            Assert.Equal(expectedCost, result);
        }
    }
}