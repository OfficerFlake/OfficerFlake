using System;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
    public static class VolumeExtensions
	{
		#region FluidOunces
		public static IFluidOunce FluidOunces(this Byte input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this SByte input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this UInt16 input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this Int16 input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this UInt32 input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this Int32 input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this UInt64 input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this Int64 input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this Single input) => ObjectFactory.CreateFluidOunce(input);
		public static IFluidOunce FluidOunces(this Double input) => ObjectFactory.CreateFluidOunce(input);
		#endregion
		#region UKGallons
		public static IUKGallon UKGallons(this Byte input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this SByte input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this UInt16 input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this Int16 input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this UInt32 input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this Int32 input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this UInt64 input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this Int64 input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this Single input) => ObjectFactory.CreateUKGallon(input);
		public static IUKGallon UKGallons(this Double input) => ObjectFactory.CreateUKGallon(input);
		#endregion
		#region UKPints
		public static IUKPint UKPints(this Byte input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this SByte input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this UInt16 input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this Int16 input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this UInt32 input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this Int32 input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this UInt64 input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this Int64 input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this Single input) => ObjectFactory.CreateUKPint(input);
		public static IUKPint UKPints(this Double input) => ObjectFactory.CreateUKPint(input);
		#endregion
		#region UKQuarts
		public static IUKQuart UKQuarts(this Byte input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this SByte input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this UInt16 input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this Int16 input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this UInt32 input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this Int32 input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this UInt64 input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this Int64 input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this Single input) => ObjectFactory.CreateUKQuart(input);
		public static IUKQuart UKQuarts(this Double input) => ObjectFactory.CreateUKQuart(input);
		#endregion
		#region UKTableSpoons
		public static IUKTableSpoon UKTableSpoons(this Byte input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this SByte input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this UInt16 input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this Int16 input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this UInt32 input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this Int32 input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this UInt64 input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this Int64 input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this Single input) => ObjectFactory.CreateUKTableSpoon(input);
		public static IUKTableSpoon UKTableSpoons(this Double input) => ObjectFactory.CreateUKTableSpoon(input);
		#endregion
		#region UKTeaSpoons
		public static IUKTeaSpoon UKTeaSpoons(this Byte input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this SByte input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this UInt16 input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this Int16 input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this UInt32 input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this Int32 input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this UInt64 input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this Int64 input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this Single input) => ObjectFactory.CreateUKTeaSpoon(input);
		public static IUKTeaSpoon UKTeaSpoons(this Double input) => ObjectFactory.CreateUKTeaSpoon(input);
		#endregion

		#region Cups
		public static ICup Cups(this Byte input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this SByte input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this UInt16 input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this Int16 input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this UInt32 input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this Int32 input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this UInt64 input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this Int64 input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this Single input) => ObjectFactory.CreateCup(input);
		public static ICup Cups(this Double input) => ObjectFactory.CreateCup(input);
		#endregion
		#region USGallons
		public static IUSGallon USGallons(this Byte input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this SByte input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this UInt16 input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this Int16 input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this UInt32 input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this Int32 input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this UInt64 input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this Int64 input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this Single input) => ObjectFactory.CreateUSGallon(input);
		public static IUSGallon USGallons(this Double input) => ObjectFactory.CreateUSGallon(input);
		#endregion
		#region USPints
		public static IUSPint USPints(this Byte input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this SByte input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this UInt16 input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this Int16 input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this UInt32 input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this Int32 input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this UInt64 input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this Int64 input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this Single input) => ObjectFactory.CreateUSPint(input);
		public static IUSPint USPints(this Double input) => ObjectFactory.CreateUSPint(input);
		#endregion
		#region USQuarts
		public static IUSQuart USQuarts(this Byte input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this SByte input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this UInt16 input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this Int16 input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this UInt32 input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this Int32 input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this UInt64 input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this Int64 input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this Single input) => ObjectFactory.CreateUSQuart(input);
		public static IUSQuart USQuarts(this Double input) => ObjectFactory.CreateUSQuart(input);
		#endregion
		#region USTableSpoons
		public static IUSTableSpoon USTableSpoons(this Byte input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this SByte input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this UInt16 input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this Int16 input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this UInt32 input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this Int32 input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this UInt64 input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this Int64 input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this Single input) => ObjectFactory.CreateUSTableSpoon(input);
		public static IUSTableSpoon USTableSpoons(this Double input) => ObjectFactory.CreateUSTableSpoon(input);
		#endregion
		#region USTeaSpoons
		public static IUSTeaSpoon USTeaSpoons(this Byte input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this SByte input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this UInt16 input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this Int16 input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this UInt32 input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this Int32 input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this UInt64 input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this Int64 input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this Single input) => ObjectFactory.CreateUSTeaSpoon(input);
		public static IUSTeaSpoon USTeaSpoons(this Double input) => ObjectFactory.CreateUSTeaSpoon(input);
		#endregion

		#region CubicCentiMeters
		public static ICubicCentiMeter CubicCentiMeters(this Byte input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this SByte input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this UInt16 input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this Int16 input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this UInt32 input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this Int32 input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this UInt64 input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this Int64 input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this Single input) => ObjectFactory.CreateCubicCentiMeter(input);
		public static ICubicCentiMeter CubicCentiMeters(this Double input) => ObjectFactory.CreateCubicCentiMeter(input);
		#endregion
		#region CubicFeet
		public static ICubicFoot CubicFeet(this Byte input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this SByte input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this UInt16 input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this Int16 input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this UInt32 input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this Int32 input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this UInt64 input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this Int64 input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this Single input) => ObjectFactory.CreateCubicFoot(input);
		public static ICubicFoot CubicFeet(this Double input) => ObjectFactory.CreateCubicFoot(input);
		#endregion
		#region CubicInches
		public static ICubicInch CubicInches(this Byte input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this SByte input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this UInt16 input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this Int16 input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this UInt32 input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this Int32 input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this UInt64 input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this Int64 input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this Single input) => ObjectFactory.CreateCubicInch(input);
		public static ICubicInch CubicInches(this Double input) => ObjectFactory.CreateCubicInch(input);
		#endregion
		#region CubicMeters
		public static ICubicMeter CubicMeters(this Byte input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this SByte input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this UInt16 input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this Int16 input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this UInt32 input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this Int32 input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this UInt64 input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this Int64 input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this Single input) => ObjectFactory.CreateCubicMeter(input);
		public static ICubicMeter CubicMeters(this Double input) => ObjectFactory.CreateCubicMeter(input);
		#endregion
		#region CubicYards
		public static ICubicYard CubicYards(this Byte input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this SByte input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this UInt16 input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this Int16 input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this UInt32 input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this Int32 input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this UInt64 input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this Int64 input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this Single input) => ObjectFactory.CreateCubicYard(input);
		public static ICubicYard CubicYards(this Double input) => ObjectFactory.CreateCubicYard(input);
		#endregion
		#region Litres
		public static ILitre Litres(this Byte input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this SByte input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this UInt16 input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this Int16 input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this UInt32 input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this Int32 input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this UInt64 input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this Int64 input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this Single input) => ObjectFactory.CreateLitre(input);
		public static ILitre Litres(this Double input) => ObjectFactory.CreateLitre(input);
		#endregion
		#region MilliLitres
		public static IMilliLitre MilliLitres(this Byte input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this SByte input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this UInt16 input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this Int16 input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this UInt32 input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this Int32 input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this UInt64 input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this Int64 input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this Single input) => ObjectFactory.CreateMilliLitre(input);
		public static IMilliLitre MilliLitres(this Double input) => ObjectFactory.CreateMilliLitre(input);
		#endregion
	}
}