using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static partial class YSFlight
	{
		public static class AircraftCategories
		{
			public static IYSTypeAircraftCategory BLANK => ObjectFactory.CreateYSTypeAircraftCategory(new[] { "" });

			public static IYSTypeAircraftCategory FIGHTER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"FIGHTER"});
			public static IYSTypeAircraftCategory NORMAL => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"NORMAL"});
			public static IYSTypeAircraftCategory BOMBER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"BOMBER"});
			public static IYSTypeAircraftCategory HEAVYBOMBER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"HEAVYBOMBER"});
			public static IYSTypeAircraftCategory WW2FIGHTER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"WW2FIGHTER"});
			public static IYSTypeAircraftCategory WW2ATTACKER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"WW2ATTACKER"});
			public static IYSTypeAircraftCategory WW2BOMBER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"WW2BOMBER"});
			public static IYSTypeAircraftCategory WW2DIVEBOMBER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"WW2DIVEBOMBER"});
			public static IYSTypeAircraftCategory ATTACKER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"ATTACKER"});
			public static IYSTypeAircraftCategory UTILITY => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"UTILITY"});
			public static IYSTypeAircraftCategory AEROBATIC => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"AEROBATIC"});
			public static IYSTypeAircraftCategory TRAINER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"TRAINER"});
			public static IYSTypeAircraftCategory HELICOPTER => ObjectFactory.CreateYSTypeAircraftCategory(new[] {"HELICOPTER"});

			public static IYSTypeAircraftCategory[] CATEGORIES => 
				new[]
				{
					FIGHTER,
					NORMAL,
					BOMBER,
					HEAVYBOMBER,
					WW2FIGHTER,
					WW2ATTACKER,
					WW2BOMBER,
					WW2DIVEBOMBER,
					ATTACKER,
					UTILITY,
					AEROBATIC,
					TRAINER,
					HELICOPTER,
				};

			public static IYSTypeAircraftCategory GetCategoryFromStringOrBlank(string input, string input2 = null)
			{
				var List = CATEGORIES.Where(x => (x != null && x.Values.Contains(input)));
				var ysTypeAircraftCategories = List as IYSTypeAircraftCategory[] ?? List.ToArray();
				return ysTypeAircraftCategories.Any() ? ysTypeAircraftCategories.First() : BLANK;
			}
		}
		public static class WeaponCategories
		{
			public static IYSTypeWeaponCategory BLANK => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "NON", "NONE", "NULL", "BLANK" });

			public static IYSTypeWeaponCategory GUN => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "GUN" });
			public static IYSTypeWeaponCategory AIM9 => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "AIM9" });
			public static IYSTypeWeaponCategory AIM9X => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "AIM9X" });
			public static IYSTypeWeaponCategory AIM120 => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "AIM120" });
			public static IYSTypeWeaponCategory AGM => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "AGM65" });
			public static IYSTypeWeaponCategory RKT => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "RKT" });
			public static IYSTypeWeaponCategory B250 => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "B250" });
			public static IYSTypeWeaponCategory B500 => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "BOMB" });
			public static IYSTypeWeaponCategory B500HD => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "B500HD" });
			public static IYSTypeWeaponCategory SMK => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "SMK" });
			public static IYSTypeWeaponCategory FLR => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "FLR", "IFLR" });
			public static IYSTypeWeaponCategory FUEL => ObjectFactory.CreateYSTypeWeaponCategory(new[]{ "FUEL" });


			public static IYSTypeWeaponCategory[] CATEGORIES => new[]
			{
				BLANK,
				GUN,
				AIM9,
				AIM9X,
				AIM120,
				AGM,
				RKT,
				B250,
				B500,
				B500HD,
				SMK,
				FLR,
				FUEL,
			};

			public static IYSTypeWeaponCategory GetCategoryFromStringOrBlank(string input, bool debug = false)
			{
				var List = CATEGORIES.Where(x => x != null && x.Values.Contains(input)).ToList();
				return List.Any() ? List[0] : BLANK;
			}
		}
		public static class WeaponTypes
		{
			public static IYSTypeWeaponType AGM65 => ObjectFactory.CreateYSTypeWeaponType(new []{ "AGM65" });
			public static IYSTypeWeaponType AIM9 => ObjectFactory.CreateYSTypeWeaponType(new []{ "AIM9" });
			public static IYSTypeWeaponType AIM9X => ObjectFactory.CreateYSTypeWeaponType(new []{ "AIM9X" });
			public static IYSTypeWeaponType AIM120 => ObjectFactory.CreateYSTypeWeaponType(new []{ "AIM120" });
			public static IYSTypeWeaponType B250 => ObjectFactory.CreateYSTypeWeaponType(new []{ "B250" });
			public static IYSTypeWeaponType B500 => ObjectFactory.CreateYSTypeWeaponType(new []{ "B500" });
			public static IYSTypeWeaponType B500HD => ObjectFactory.CreateYSTypeWeaponType(new []{ "B500HD" });
			public static IYSTypeWeaponType RKT => ObjectFactory.CreateYSTypeWeaponType(new []{ "RKT" });
			public static IYSTypeWeaponType FLR => ObjectFactory.CreateYSTypeWeaponType(new []{ "FLR", "IFLR" });
			public static IYSTypeWeaponType FUEL => ObjectFactory.CreateYSTypeWeaponType(new []{ "FUEL" });
			public static IYSTypeWeaponType SMK => ObjectFactory.CreateYSTypeWeaponType(new []{ "SMK" });
			public static IYSTypeWeaponType GUN => ObjectFactory.CreateYSTypeWeaponType(new []{ "GUN" });
			public static IYSTypeWeaponType BLANK => ObjectFactory.CreateYSTypeWeaponType(new []{ "" });

			public static IYSTypeWeaponType[] CATEGORIES => new[]
			{
				AGM65,
				AIM9,
				AIM9X,
				AIM120,
				B250,
				B500,
				B500HD,
				RKT,
				FLR,
				FUEL,
				SMK,
				GUN,
			};

			public static IYSTypeWeaponType GetCategoryFromStringOrBlank(string input, bool debug = false)
			{
				var List = CATEGORIES.Where(x => x != null && x.Values.Contains(input)).ToList();
				return List.Any() ? List[0] : BLANK;
			}
		}

		public static class CommentMarkers
		{
			public static readonly string[] StartOfLineMarkers = { "REM", "//", "#", ";", };
			public static readonly string[] MidLineMarkers = { "//", "#", ";", };
		}
	}
}
