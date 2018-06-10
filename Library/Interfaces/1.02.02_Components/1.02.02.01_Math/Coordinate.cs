namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IDimensionX<T>
	{
		T X { get; set; }
	}
	public interface IDimensionY<T>
	{
		T Y { get; set; }
	}
	public interface IDimensionZ<T>
	{
		T Z { get; set; }
	}
	public interface IDimensionH
	{
		IAngle H { get; set; }
	}
	public interface IDimensionP
	{
		IAngle P { get; set; }
	}
	public interface IDimensionB
	{
		IAngle B { get; set; }
	}

	public interface IPoint2<T> : IDimensionX<T>, IDimensionY<T>
	{
	}
	public interface IPoint3<T> : IDimensionX<T>, IDimensionY<T>, IDimensionZ<T>
	{
	}

	public interface IVector2<T> : IDimensionX<T>, IDimensionY<T>
	{
	}
	public interface IVector3<T> : IDimensionX<T>, IDimensionY<T>, IDimensionZ<T>
	{
	}

	public interface ICoordinate2 : IDimensionX<IDistance>, IDimensionY<IDistance>
	{
	}
	public interface ICoordinate3 : IDimensionX<IDistance>, IDimensionY<IDistance>, IDimensionZ<IDistance>
	{
	}

	public interface IOrientation2 : IDimensionH, IDimensionP
	{
	}
	public interface IOrientation3 : IDimensionH, IDimensionP, IDimensionB
	{
	}

}
