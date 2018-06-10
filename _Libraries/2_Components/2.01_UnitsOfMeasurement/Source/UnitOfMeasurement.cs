using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public abstract class UnitOfMeasurement : IUnitOfMeasurement
        {
	        public double RawValue { get; set; }
	        public double ConversionRatio { get; set; }

			protected UnitOfMeasurement(double value, double conversionRatio)
	        {
		        RawValue = value;
		        ConversionRatio = conversionRatio;
	        }

			public double ConvertToBase() => RawValue * ConversionRatio;
			
			public override string ToString()
            {
                return RawValue.ToString();
            }
        }
    }
}
