using System;
namespace CarClass
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int GasTankSize { get; set; }
        public double GasTankLevel { get; set; }
        public double MilesPerGallon { get; set; }
        public double Odometer { get; set; } = 0;

        public Car()
        {}

        public Car(string make, string model, int gasTankSize, double milesPerGallon)
        {
            Make = make;
            Model = model;
            GasTankSize = gasTankSize;
            // Gas tank level defaults to a full tank
            GasTankLevel = gasTankSize;
            MilesPerGallon = milesPerGallon;
        }


        public string Vroom()
        {
            string vroom = "vroom vroom";
            return vroom;
        }


        /**
         * Drive the car an amount of miles. If not enough fuel, drive as far as fuel allows.
         * Adjust fuel levels based on amount needed to drive the distance requested.
         * Add miles to odometer.
         */
        public void Drive(double miles)
        {
            //adjust fuel based on mpg and miles requested to drive
            double maxDistance = MilesPerGallon * GasTankLevel;
            /**the double below uses some syntax called the ternary operator.
                * if the value of miles is greater than the value of maxDistance,
                * then milesAbleToTravel = maxDistance.
                * otherwise, if miles is not greater than maxDistance,
                * then milesAbleToTravel = miles
                */
            // this is a ternary opertaor
            double milesAbleToTravel = miles > maxDistance ? maxDistance : miles;
            // the ? = if
            // the : = else
            // We are checking to see if miles > maxDistance
                // (if true ?) set the value of milesAbleToTravel = maxDistance
                // (else :) set the value of  milesAbleToTravel = miles

            if(miles > maxDistance)
            {
                milesAbleToTravel = maxDistance;
            }
            else if (true)
             {

            }
            else
            {
                milesAbleToTravel = miles;
            }


            double gallonsUsed = milesAbleToTravel / MilesPerGallon;
            GasTankLevel -= gallonsUsed;
            Odometer += milesAbleToTravel;
        }


    }
}
