namespace Com.OfficerFlake.Libraries.Interfaces
{
	//UnitsOfMeasurement
	public enum BuildEnvironmentType
	{
		Debug,
		Release,
	}

	public static class BuildEnvironment
	{
		private static BuildEnvironmentType buildEnvironment
		{
			get
			{
				#if DEBUG
				return BuildEnvironmentType.Debug;
				#endif
				#if !DEBUG
				return BuildEnvironmentType.Release;
				#endif
			}
		}

		public static bool Debug => (buildEnvironment == BuildEnvironmentType.Debug);
		public static bool Release => (buildEnvironment == BuildEnvironmentType.Release);
	}
}
