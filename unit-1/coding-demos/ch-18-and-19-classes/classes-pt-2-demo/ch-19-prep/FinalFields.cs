using System;
namespace ch_19_prep
{
    public class FinalFields
    {
        public readonly int intValue = 42;

        public readonly double doubleValue;

        public const double constDoubleValue = 2.9;

        public readonly FortyTwo objectValue = new FortyTwo();

        public FinalFields()
        {}

        public FinalFields(double double1, double double2)
        {
            // I am able to do this beacause the field is readonly 
            this.doubleValue = double1;

            // I am not able to do this because the field is a constant
            //this.constDoubleValue = double2;
        }

        public void SetDoublesValue()
        {
            // I am unable to do this because the field is readonly which means it value can only be set in the constructor
            //this.doubleValue = 77.7;
        }
    }
}
