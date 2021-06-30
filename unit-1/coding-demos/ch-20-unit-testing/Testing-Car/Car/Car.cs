using System;
using System.Collections.Generic;

namespace Car
{
    public class CarClass
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int GasTankSize { get; set; }
        public double GasTankLevel { get; set; }
        public double MilesPerGallon { get; set; }
        public double Odometer { get; set; } = 0;
        public int NumberOfWheels { get; set; }


        public CarClass()
        {
        }

        public CarClass(string make, string model, int gasTankSize, double milesPerGallon, int numberOfWheels)
        {
            this.Make = make;
            this.Model = model;
            this.GasTankSize = gasTankSize;
            // Gas tank level defaults to a full tank
            this.GasTankLevel = gasTankSize;
            this.MilesPerGallon = milesPerGallon;
            this.NumberOfWheels = numberOfWheels;
        }


        public double GiveMaxDistance()
        {
            double maxDistance = this.MilesPerGallon * this.GasTankLevel;

            return maxDistance;
        }
    }
}
