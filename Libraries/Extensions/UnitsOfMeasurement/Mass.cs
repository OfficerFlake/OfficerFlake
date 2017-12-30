using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class MassExtensions
	{
		#region Carats
		public static ICarat Carats(this Byte input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this SByte input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this UInt16 input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this Int16 input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this UInt32 input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this Int32 input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this UInt64 input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this Int64 input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this Single input) => ObjectFactory.CreateCarat(input);
		public static ICarat Carats(this Double input) => ObjectFactory.CreateCarat(input);
		#endregion
		#region CentiGrams
		public static ICentiGram CentiGrams(this Byte input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this SByte input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this UInt16 input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this Int16 input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this UInt32 input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this Int32 input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this UInt64 input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this Int64 input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this Single input) => ObjectFactory.CreateCentiGram(input);
		public static ICentiGram CentiGrams(this Double input) => ObjectFactory.CreateCentiGram(input);
		#endregion
		#region DecaGrams
		public static IDecaGram DecaGrams(this Byte input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this SByte input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this UInt16 input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this Int16 input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this UInt32 input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this Int32 input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this UInt64 input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this Int64 input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this Single input) => ObjectFactory.CreateDecaGram(input);
		public static IDecaGram DecaGrams(this Double input) => ObjectFactory.CreateDecaGram(input);
		#endregion
		#region DeciGrams
		public static IDeciGram DeciGrams(this Byte input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this SByte input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this UInt16 input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this Int16 input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this UInt32 input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this Int32 input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this UInt64 input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this Int64 input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this Single input) => ObjectFactory.CreateDeciGram(input);
		public static IDeciGram DeciGrams(this Double input) => ObjectFactory.CreateDeciGram(input);
		#endregion
		#region Grams
		public static IGram Grams(this Byte input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this SByte input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this UInt16 input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this Int16 input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this UInt32 input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this Int32 input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this UInt64 input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this Int64 input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this Single input) => ObjectFactory.CreateGram(input);
		public static IGram Grams(this Double input) => ObjectFactory.CreateGram(input);
		#endregion
		#region HectoGrams
		public static IHectoGram HectoGrams(this Byte input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this SByte input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this UInt16 input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this Int16 input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this UInt32 input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this Int32 input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this UInt64 input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this Int64 input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this Single input) => ObjectFactory.CreateHectoGram(input);
		public static IHectoGram HectoGrams(this Double input) => ObjectFactory.CreateHectoGram(input);
		#endregion
		#region KiloGrams
		public static IKiloGram KiloGrams(this Byte input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this SByte input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this UInt16 input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this Int16 input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this UInt32 input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this Int32 input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this UInt64 input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this Int64 input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this Single input) => ObjectFactory.CreateKiloGram(input);
		public static IKiloGram KiloGrams(this Double input) => ObjectFactory.CreateKiloGram(input);
		#endregion
		#region MetricTonnes
		public static IMetricTonne MetricTonnes(this Byte input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this SByte input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this UInt16 input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this Int16 input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this UInt32 input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this Int32 input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this UInt64 input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this Int64 input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this Single input) => ObjectFactory.CreateMetricTonne(input);
		public static IMetricTonne MetricTonnes(this Double input) => ObjectFactory.CreateMetricTonne(input);
		#endregion
		#region MilliGrams
		public static IMilliGram MilliGrams(this Byte input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this SByte input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this UInt16 input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this Int16 input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this UInt32 input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this Int32 input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this UInt64 input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this Int64 input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this Single input) => ObjectFactory.CreateMilliGram(input);
		public static IMilliGram MilliGrams(this Double input) => ObjectFactory.CreateMilliGram(input);
		#endregion
		#region Ounces
		public static IOunce Ounces(this Byte input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this SByte input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this UInt16 input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this Int16 input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this UInt32 input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this Int32 input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this UInt64 input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this Int64 input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this Single input) => ObjectFactory.CreateOunce(input);
		public static IOunce Ounces(this Double input) => ObjectFactory.CreateOunce(input);
		#endregion
		#region Pounds
		public static IPound Pounds(this Byte input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this SByte input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this UInt16 input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this Int16 input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this UInt32 input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this Int32 input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this UInt64 input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this Int64 input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this Single input) => ObjectFactory.CreatePound(input);
		public static IPound Pounds(this Double input) => ObjectFactory.CreatePound(input);
		#endregion
		#region Stones
		public static IStone Stones(this Byte input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this SByte input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this UInt16 input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this Int16 input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this UInt32 input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this Int32 input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this UInt64 input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this Int64 input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this Single input) => ObjectFactory.CreateStone(input);
		public static IStone Stones(this Double input) => ObjectFactory.CreateStone(input);
		#endregion
		#region UKLongTons
		public static IUKLongTon UKLongTons(this Byte input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this SByte input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this UInt16 input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this Int16 input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this UInt32 input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this Int32 input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this UInt64 input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this Int64 input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this Single input) => ObjectFactory.CreateUKLongTon(input);
		public static IUKLongTon UKLongTons(this Double input) => ObjectFactory.CreateUKLongTon(input);
		#endregion
		#region USShortTons
		public static IUSShortTon USShortTons(this Byte input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this SByte input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this UInt16 input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this Int16 input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this UInt32 input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this Int32 input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this UInt64 input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this Int64 input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this Single input) => ObjectFactory.CreateUSShortTon(input);
		public static IUSShortTon USShortTons(this Double input) => ObjectFactory.CreateUSShortTon(input);
		#endregion
	}
}