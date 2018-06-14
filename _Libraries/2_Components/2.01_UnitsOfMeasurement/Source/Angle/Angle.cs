using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries.UnitsOfMeasurement
{
    public class Angle : UnitOfMeasurement, IAngle
    {
		#region CTOR
		protected Angle(double value, double conversionRatio, string[] unitSuffixes)
            : base(value, conversionRatio)
		{
			CurrentSuffixes = unitSuffixes;
		}
        #endregion
		#region Operators
        public static Angle operator +(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase() + secondMeasurement.ConvertToBase()), 1, Angle.DefaultSuffixes);
        }
        public static Angle operator -(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase() - secondMeasurement.ConvertToBase()), 1, Angle.DefaultSuffixes);
        }
        public static Angle operator *(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase() * secondMeasurement.ConvertToBase()), 1, Angle.DefaultSuffixes);
        }
        public static Angle operator /(Angle firstMeasurement, Angle secondMeasurement)
        {
            return new Angle((firstMeasurement.ConvertToBase() / secondMeasurement.ConvertToBase()), 1, Angle.DefaultSuffixes);
        }

        public static implicit operator string(Angle thisAngle) => thisAngle.ToString();
	    public override string ToString()
	    {
		    return base.ToString() + CurrentSuffixes[0];
	    }
		#endregion
	    #region Suffix
	    protected struct Suffixes
	    {
		    public static readonly string[] Radian = new[] { "RADIANS", "RADIAN", "RAD" };
		    public static readonly string[] Degree = new[] { "DEGREES", "DEGREE", "DEG" };
		    public static readonly string[] Gradian = new[] { "GRADIANS", "GRADIAN", "GRAD" };
	    }
	    private static readonly string[] DefaultSuffixes = Suffixes.Radian;
	    private readonly string[] CurrentSuffixes = DefaultSuffixes;
	    #endregion

		#region Conversion ...
		protected struct Conversion
        {
            public const double Radian = 1.00d;
            public const double Degree = 0.017453d;
            public const double Gradian = 0.015708d;
        }
	    public static bool TryParse(string input, out IAngle output)
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
			    Debug.AddDetailMessage("Measurement Input not successfully converted.");
			    Debug.AddDetailMessage("----" + capInput);
			    output = new Angles.Degree(0);
			    return false;
		    }
			#endregion
			#endregion
			#region Convert To Angle
			if (capInput.EndsWithAny(Suffixes.Degree))
		    {

			    output = new Angles.Degree(conversion);
			    return true;
		    }
		    if (capInput.EndsWithAny(Suffixes.Gradian))
		    {

			    output = new Angles.Gradian(conversion);
			    return true;
		    }
		    if (capInput.EndsWithAny(Suffixes.Radian))
		    {

			    output = new Angles.Radian(conversion);
			    return true;
		    }
			#endregion
		#region ... Conversion
			#region Type Unrecognised
			Debug.AddDetailMessage("No Type for input angle conversion. Break here for details...");
		    Debug.AddDetailMessage("----" + capInput);
		    output = new Angles.Degree(0);
		    return false;
		    #endregion

	    }
		#endregion

		#region Convert To Subobjects
		public IDegree ToDegrees()
	    {
		    return new Angles.Degree(ConvertToBase() / Conversion.Degree);
	    }
	    public IGradian ToGradians()
	    {
		    return new Angles.Gradian(ConvertToBase() / Conversion.Gradian);
	    }
	    public IRadian ToRadians()
	    {
		    return new Angles.Radian(ConvertToBase() / Conversion.Radian);
	    }
		#endregion
	}
}
