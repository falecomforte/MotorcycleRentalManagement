using System;

namespace MotorcycleRentalManagement.Domain.Entities
{
    public class Motorcycle
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public Motorcycle(Guid id, int year, string model, string licensePlate)
        {
            Id = id;
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }

        public bool IsValid()
        {
            return Year > 0 && !string.IsNullOrWhiteSpace(Model) && !string.IsNullOrWhiteSpace(LicensePlate);
        }
    }
}