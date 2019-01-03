using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.YSFlight.Types
{
    public class AircraftCategory : IYSTypeAircraftCategory
    {
        public string[] Values { get; set; }

		public AircraftCategory(string[] values)
        {
            Values = values;
        }
		
        public override string ToString()
        {
            return (string.Join(" ", Values)).Trim();
        }
    }
}
