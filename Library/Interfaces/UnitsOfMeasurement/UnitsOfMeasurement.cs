using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	//UnitsOfMeasurement
	public interface IUnitOfMeasurement
	{
		double RawValue { get; set; }
		double ConversionRatio { get; set; }
		double ConvertToBase();

		string ToString();
	}
	public interface IAngle : IUnitOfMeasurement
	{
	}
	public interface IArea : IUnitOfMeasurement
	{
	}
	public interface ITime : IUnitOfMeasurement
	{
	}
	public interface ITimeSpan : IUnitOfMeasurement
	{
	}
	public interface IDate : IUnitOfMeasurement
	{
	}
	public interface IDateTime : IUnitOfMeasurement
	{
	}
	public interface IDistance : IUnitOfMeasurement
	{
	}
	public interface IEnergy : IUnitOfMeasurement
	{
	}
	public interface IMass : IUnitOfMeasurement
	{
	}
	public interface IPower : IUnitOfMeasurement
	{
	}
	public interface IPressure : IUnitOfMeasurement
	{
	}
	public interface ISpeed : IUnitOfMeasurement
	{
	}
	public interface ITemperature : IUnitOfMeasurement
	{
	}
	public interface IVolume : IUnitOfMeasurement
	{
	}

	public static class UnitsOfMeasurementExtentions
	{
		public static T ConvertToBase<T>(this T measurment) where T : IUnitOfMeasurement, new()
		{
			T output = new T()
			{
				RawValue = measurment.RawValue / measurment.ConversionRatio,
				ConversionRatio = 1,
			};
			return output;
		}
	}
}
