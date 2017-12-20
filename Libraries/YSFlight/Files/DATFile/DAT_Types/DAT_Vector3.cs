using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
		public class DAT_Vector3 : CommandFile.Line, IPoint3
		{
			public IDistance X
			{
				get
				{
					Distance output = 0.Meters();
					Distance.TryParse(GetParameter(0), out output);
					return output;
				}
				set
				{
					SetParameter(0, value.ToString());
				}
			}
			public IDistance Y
			{
				get
				{
					Distance output = 0.Meters();
					Distance.TryParse(GetParameter(1), out output);
					return output;
				}
				set
				{
					SetParameter(1, value.ToString());
				}
			}
			public IDistance Z
			{
				get
				{
					Distance output = 0.Meters();
					Distance.TryParse(GetParameter(2), out output);
					return output;
				}
				set
				{
					SetParameter(2, value.ToString());
				}
			}

			protected DAT_Vector3(string Command, IPoint3 Point) : base(Command + " " + Point.X + " " + Point.Y + " " + Point.Z)
			{
				this.Command = Command;
				this.X = Point.X;
				this.Y = Point.Y;
				this.Z = Point.Z;
			}
		}
    }
}