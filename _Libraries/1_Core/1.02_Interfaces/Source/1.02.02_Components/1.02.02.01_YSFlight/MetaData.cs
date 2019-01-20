namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IMetaDataVehicle
	{
		string Path_0_PropertiesFile { get; set; }
		string Path_1_ModelFile { get; set; }
		string Path_2_CollisionFile { get; set; }
		string Path_3_CockpitFile { get; set; }
		string Path_4_CoarseFile { get; set; }

		string Identify { get; set; }
	}
	public interface IMetaDataAircraft : IMetaDataVehicle, IListFileLine
	{
	    IDATFile LoadDATFile();
	}
	public interface IMetaDataGround : IMetaDataVehicle, IListFileLine
	{
	}

	public interface IMetaDataScenery : IListFileLine
	{
		string Path_1_FieldFile { get; set; }
		string Path_2_StartPositionFile { get; set; }
		string Path_3_YFSFile { get; set; }

		string Identify { get; set; }
	}
}
