using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Temperature : ITemperature
    {
		public double Value { get; set; }
		#region CTOR
		protected Temperature(double value)
		{
			Value = value;
		}
        #endregion
		#region Operators
        public static Temperature operator +(Temperature firstMeasurement, Temperature secondMeasurement)
        {
            return new Temperature((firstMeasurement.ToDegreesCelsius().Value + secondMeasurement.ToDegreesCelsius().Value));
        }
        public static Temperature operator -(Temperature firstMeasurement, Temperature secondMeasurement)
        {
            return new Temperature((firstMeasurement.ToDegreesCelsius().Value - secondMeasurement.ToDegreesCelsius().Value));
        }
        public static Temperature operator *(Temperature firstMeasurement, Temperature secondMeasurement)
        {
            return new Temperature((firstMeasurement.ToDegreesCelsius().Value * secondMeasurement.ToDegreesCelsius().Value));
        }
        public static Temperature operator /(Temperature firstMeasurement, Temperature secondMeasurement)
        {
            return new Temperature((firstMeasurement.ToDegreesCelsius().Value / secondMeasurement.ToDegreesCelsius().Value));
        }

        public static implicit operator string(Temperature thisTemperature) => thisTemperature.ToString();
	    public override string ToString()
	    {
		    return base.ToString() + CurrentSuffixes[0];
	    }
		#endregion
	    #region Suffix
	    protected struct Suffixes
	    {
		    public static readonly string[] DegreeCelcius = new[] { "CELCIUS", "*C", "C" };
		    public static readonly string[] DegreeFahrenheit = new[] { "FAHRENHEIT", "*F", "F" };
		    public static readonly string[] DegreeKelvin = new[] { "KELVIN", "*K", "K" };
	    }
	    private static readonly string[] DefaultSuffixes = Suffixes.DegreeCelcius;
	    private readonly string[] CurrentSuffixes = DefaultSuffixes;
	    #endregion

		#region Conversion ...
		public static bool TryParse(string input, out ITemperature output)
	    {
		    #region Prepare Variables
		    string capInput = input.ToUpperInvariant();
		    string extraction = input.ExtractNumberComponentFromMeasurementString();
		    double conversion = 0;
		    #endregion

		    #region Convert To Double
		    bool failed = !double.TryParse(extraction, out conversion);
		    if (failed)
		    {
			    Logger.AddDebugMessage("Measurement Input not successfully converted.");
			    Logger.AddDebugMessage("----" + capInput);
			    output = new Temperatures.DegreeCelsius(0);
			    return false;
		    }
			#endregion
			#endregion
			#region Convert To Temperature
			if (capInput.EndsWithAny(Suffixes.DegreeCelcius))
		    {

			    output = new Temperatures.DegreeCelsius(conversion);
			    return true;
		    }
		    if (capInput.EndsWithAny(Suffixes.DegreeKelvin))
		    {

			    output = new Temperatures.DegreeKelvin(conversion);
			    return true;
		    }
		    if (capInput.EndsWithAny(Suffixes.DegreeFahrenheit))
		    {

			    output = new Temperatures.DegreeFahrenheit(conversion);
			    return true;
		    }
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Logger.AddDebugMessage("No Type for input Temperature conversion. Break here for details...");
		    Logger.AddDebugMessage("----" + capInput);
		    output = new Temperatures.DegreeCelsius(0);
		    return false;
		    #endregion

	    }
		#endregion

		#region Convert To Subobjects
		public IDegreeCelsius ToDegreesCelsius()
	    {
		    return new Temperatures.DegreeCelsius(Value);
	    }
	    public IDegreeFahrenheit ToDegreesFahrenheit()
	    {
		    return new Temperatures.DegreeFahrenheit(Value*9/5+32);
	    }
	    public IDegreeKelvin ToDegreesKelvin()
	    {
		    return new Temperatures.DegreeKelvin(Value+273.15);
	    }
		#endregion
	}
}
