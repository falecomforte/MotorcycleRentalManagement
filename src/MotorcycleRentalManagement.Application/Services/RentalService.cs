using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MotorcycleRentalManagement.Domain.Entities;
using MotorcycleRentalManagement.Infrastructure.MongoDb;

namespace MotorcycleRentalManagement.Application.Services
{
    public class RentalService
    {
        private readonly MotorcycleRepository _motorcycleRepository;

        public RentalService(MotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<Rental> RentMotorcycle(string motorcycleId, string renterId, DateTime rentalStart, DateTime rentalEnd)
        {
            var motorcycle = await _motorcycleRepository.GetMotorcycleById(motorcycleId);
            if (motorcycle == null || !motorcycle.IsAvailable)
            {
                throw new InvalidOperationException("Motorcycle is not available for rent.");
            }

            var rental = new Rental
            {
                MotorcycleId = motorcycleId,
                RenterId = renterId,
                RentalStart = rentalStart,
                RentalEnd = rentalEnd
            };

            motorcycle.IsAvailable = false;
            await _motorcycleRepository.UpdateMotorcycle(motorcycle);

            return rental;
        }

        public async Task ReturnMotorcycle(string motorcycleId)
        {
            var motorcycle = await _motorcycleRepository.GetMotorcycleById(motorcycleId);
            if (motorcycle == null)
            {
                throw new InvalidOperationException("Motorcycle not found.");
            }

            motorcycle.IsAvailable = true;
            await _motorcycleRepository.UpdateMotorcycle(motorcycle);
        }

        public decimal CalculateRentalCost(DateTime rentalStart, DateTime rentalEnd, decimal dailyRate)
        {
            var rentalDays = (rentalEnd - rentalStart).Days;
            return rentalDays * dailyRate;
        }
    }
}