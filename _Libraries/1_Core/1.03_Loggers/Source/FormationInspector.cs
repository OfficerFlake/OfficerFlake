using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Logger
{
    internal class DefaultFormationInspector : IFormationInspector
    {
        public void UpdateClientFormationHost(int formationPositionNumber, string username, int? flightId)
        {
            System.Diagnostics.Debug.WriteLine("Formation Position " + formationPositionNumber + " updated client details: Username:" + (username ?? "<Not Connected>") + ", FlightID:" + (flightId?.ToString() ?? "-----"));
            return;
        }

        public void UpdateClientFormationPosition(int formationPositionNumber, int? targetPositionNumber, double? xPosition, double? yPosition, double? zPosition)
        {
            System.Diagnostics.Debug.WriteLine("Formation Position " + formationPositionNumber + " updated position details: TargetID:" + (targetPositionNumber?.ToString() ?? "--") + ", xPos:" + (xPosition?.ToString() ?? "-----") + ", yPos:" + (yPosition?.ToString() ?? "-----") + ", zPos:" + (zPosition?.ToString() ?? "-----"));
            return;
        }
    }
	public static class FormationInspector
	{
		private static IFormationInspector _formationInspector = new DefaultFormationInspector();

		public static void LinkFormationInspector(IFormationInspector formationInspector)
		{
			if (formationInspector != null) _formationInspector = formationInspector;
		}

		public static void UpdateClientFormationHost(int formationPositionNumber, string username, int? flightId) => _formationInspector.UpdateClientFormationHost(formationPositionNumber, username, flightId);
		public static void UpdateClientFormationPosition(int formationPositionNumber, int? targetPositionNumber, double? xPosition, double? yPosition, double? zPosition) => _formationInspector.UpdateClientFormationPosition(formationPositionNumber, targetPositionNumber, xPosition, yPosition, zPosition);
	}
}
