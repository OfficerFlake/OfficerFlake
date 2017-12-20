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
	public interface IDimensionH<T>
	{
		T H { get; set; }
	}
	public interface IDimensionP<T>
	{
		T P { get; set; }
	}
	public interface IDimensionB<T>
	{
		T B { get; set; }
	}

	public interface IPoint1 : IDimensionX<IDistance>
	{
	}
	public interface IPoint2 : IDimensionX<IDistance>, IDimensionY<IDistance>
	{
	}
	public interface IPoint3 : IDimensionX<IDistance>, IDimensionY<IDistance>, IDimensionZ<IDistance>
	{
	}

	public interface IVector1 : IDimensionX<IDistance>
	{
	}
	public interface IVector2 : IDimensionX<IDistance>, IDimensionY<IDistance>
	{
	}
	public interface IVector3 : IDimensionX<IDistance>, IDimensionY<IDistance>, IDimensionZ<IDistance>
	{
	}

	public interface IOrientation1 : IDimensionH<IAngle>
	{
	}
	public interface IOrientation2 : IDimensionH<IAngle>, IDimensionP<IAngle>
	{
	}
	public interface IOrientation3 : IDimensionH<IAngle>, IDimensionP<IAngle>, IDimensionB<IAngle>
	{
	}

}
