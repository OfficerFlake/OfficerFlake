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

	public interface IDuration : IUnitOfMeasurement
	{
	}
	public interface ISecond : IDuration
	{
	}
	public interface IMinute : IDuration
	{
	}
	public interface IHour : IDuration
	{
	}
	public interface IDay : IDuration
	{
	}
	public interface IWeek : IDuration
	{
	}
	public interface IMonth : IDuration
	{
	}
	public interface IYear : IDuration
	{
	}

	public interface IDate
	{
		IYear Year { get; set; }
		IMonth Month { get; set; }
		IDay Day { get; set; }

		DateTime ToDateTime();
	}
	public interface ITime
	{
		IHour Hour { get; set; }
		IMinute Minute { get; set; }
		ISecond Second { get; set; }

		DateTime ToDateTime();
	}
	public interface IDateTime
	{
		IYear Year { get; set; }
		IMonth Month { get; set; }
		IDay Day { get; set; }
		IHour Hour { get; set; }
		IMinute Minute { get; set; }
		ISecond Second { get; set; }

		DateTime ToDateTime();
	}
	public interface ITimeSpan
	{
		IYear Years { get; set; }
		IMonth Months { get; set; }
		IWeek Weeks { get; set; }
		IDay Days { get; set; }
		IHour Hours { get; set; }
		IMinute Minutes { get; set; }
		ISecond Seconds { get; set; }

		IYear TotalYears();
		IMonth TotalMonths();
		IWeek TotalWeeks();
		IDay TotalDays();
		IHour TotalHours();
		IMinute TotalMinutes();
		ISecond TotalSeconds();

		TimeSpan ToTimeSpan();
	}
}
