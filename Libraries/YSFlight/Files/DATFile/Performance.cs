using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

using Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Performance
{
    public partial class SpiderGraph
    {
        public File File { get; }

        public static class Statistics
        {
            public struct Names
            {
                public static readonly string ThrustToWeightRatio = "ThrustToWeightRatio";
                public static readonly string MaxCruiseSpeed = "MaxCruiseSpeed";
                public static readonly string MaxCornerRate = "MaxCornerRate";
                public static readonly string MaxStrength = "MaxStrength";
                public static readonly string MaxWeaponLoadout = "MaxWeaponLoadout";
                public static readonly string MaxStealth = "MaxStealth";
            }

            public static IStatistic ThrustToWeightRatio = ObjectFactory.CreateStatsticTracker(Names.ThrustToWeightRatio);
            public static IStatistic MaxCruiseSpeed = ObjectFactory.CreateStatsticTracker(Names.MaxCruiseSpeed);
            public static IStatistic MaxCornerRate = ObjectFactory.CreateStatsticTracker(Names.MaxCornerRate);
            public static IStatistic MaxStrength = ObjectFactory.CreateStatsticTracker(Names.MaxStrength);
            public static IStatistic MaxWeaponLoadout = ObjectFactory.CreateStatsticTracker(Names.MaxWeaponLoadout);
            public static IStatistic MaxStealth = ObjectFactory.CreateStatsticTracker(Names.MaxStealth);

            public static void Update(SpiderGraph Graph)
            {
                ThrustToWeightRatio.Samples.Add(Graph.CalculateThrustToWeightRatio());

                ThrustToWeightRatio.Samples.Add(Graph.CalculateThrustToWeightRatio());
                MaxCruiseSpeed.Samples.Add(Graph.CalculateMaxCruiseSpeed());
                MaxCornerRate.Samples.Add(Graph.CalculateMaxTurnRate());
                MaxStrength.Samples.Add(Graph.CalculateMaxStrength());
                MaxWeaponLoadout.Samples.Add(Graph.CalculateWeaponScore());
                MaxStealth.Samples.Add(Graph.CalculateStealth());
            }
            public static void Clear()
            {
                ThrustToWeightRatio.Samples.Clear();
                MaxCruiseSpeed.Samples.Clear();
                MaxCornerRate.Samples.Clear();
                MaxStrength.Samples.Clear();
                MaxWeaponLoadout.Samples.Clear();
                MaxStealth.Samples.Clear();
            }
        }

        public SpiderGraph(File _file)
        {
            File = _file;
        }

        #region ThrustToWeight

        private IMass GetMaxThrust()
        {
            var magicnumber_propellorpower = 0.0053333333333333d;
            var input = new List<IMass>
            {
                File.Contents.OfType<THRAFTBN>().Max(z => z.Value),
                File.Contents.OfType<THRMILIT>().Max(z => z.Value),
                File.Contents.OfType<PROPELLR>().Max(z => (z.Value.ConversionRatio*magicnumber_propellorpower).KiloGrams().ToMetricTonnes())

            };
            var output = (input.All(y => y == null)) ? 0.MetricTonnes() : input.Where(y => y != null).OrderByDescending(x => x).First();

            return output;
        }
        private IMass GetMinWeight()
        {
            var input = new List<IMass>
            {
                File.Contents.OfType<WEIGHCLN>().Min(z => z.Value)
            };
            var output = (input.All(y => y == null)) ? 0.MetricTonnes() : input.Where(y => y != null).OrderByDescending(x => x).Last();
            return output;
        }
        private IMass GetOperatingWeight()
        {
            var weightClean = new List<IMass>
            {
                File.Contents.OfType<WEIGHCLN>().Min(z => z.Value)
            };
            var weightFuel50Percent = new List<IMass>
            {
                File.Contents.OfType<WEIGFUEL>().Min(z => z.Value)
            };
	        var weightCleanOut = weightClean.All(y => y == null)
		        ? 0.MetricTonnes()
		        : weightClean.Where(y => y != null).OrderByDescending(x => x).Last();

	        var weightFuel50PercentOut = (0.5 *
	                                     ((weightClean.All(y => y == null))
		                                     ? 0.MetricTonnes().RawValue
		                                     : weightClean.Where(y => y != null).OrderByDescending(x => x)
												.Last().ToMetricTonnes().RawValue
										 )).MetricTonnes();
            return (weightCleanOut.ToKiloGrams().RawValue + weightFuel50PercentOut.ToKiloGrams().RawValue).KiloGrams();
        }
        public double CalculateThrustToWeightRatio()
        {
	        double numerator = GetMaxThrust().ToMetricTonnes().RawValue;
	        double denominator = GetOperatingWeight().ToMetricTonnes().RawValue;
            if (denominator == 0) return double.MaxValue;
	        double output = numerator / denominator;
            return output;
        }

        #endregion
        #region CruiseSpeed

        private ISpeed GetCruiseSpeed()
        {
            var input = new List<ISpeed>
            {
                File.Contents.OfType<REFVCRUS>().Max(z => z.Value),

            };
            var output = (input.All(y => y == null)) ? 0.Knots() : input.Where(y => y != null).OrderByDescending(x => x).First();

            return output;
        }
        private float GetCruiseThrottle()
        {
            var input = new List<float>
            {
                File.Contents.OfType<REFTCRUS>().Max(z => z.Value),
            };
            var output = input.OrderByDescending(x => x).First();

            return output;
        }
        public double CalculateMaxCruiseSpeed()
        {
	        double numerator = GetCruiseSpeed().ToMetersPerSecond().RawValue;
	        double denominator = GetCruiseThrottle();
            if (denominator == 0) return 0;
	        double output = numerator / denominator;
            return output;
        }

        #endregion
        #region MaxTurnRate

        private IAngle GetMaxInputAoA()
        {
            var ListOfMXIPTAOA = new List<IAngle>
            {
                File.Contents.OfType<MXIPTAOA>().Max(z => z.Value),
            };
            var MXIPTAOA = (ListOfMXIPTAOA.All(y => y == null)) ? 0.Degrees() : ListOfMXIPTAOA.Where(y => y != null).OrderByDescending(x => x).First();

            return MXIPTAOA;
        }
        private IAngle GetPSTMAoA()
        {
            var ListOfPSTMPTCH = new List<IAngle>
            {
                File.Contents.OfType<PSTMPTCH>().Max(z => z.Value),
            };
            var PSTMPTCH = (ListOfPSTMPTCH.All(y => y == null)) ? 0.Degrees() : ListOfPSTMPTCH.Where(y => y != null).OrderByDescending(x => x).First();

            return PSTMPTCH;
        }
        public double CalculateMaxTurnRate()
        {
            return (GetMaxInputAoA().ToRadians().RawValue + GetPSTMAoA().ToRadians().RawValue).Radians().ToDegrees().RawValue;
        }

        #endregion
        #region Strength

        public double CalculateMaxStrength()
        {
            var STRENGTH = (File.Contents.OfType<STRENGTH>().Any())
                ? new List<float>
                {
                    File.Contents.OfType<STRENGTH>().Max(z => z.Value)
                }
                : new List<float>
                {
                    1
                };
            var output = STRENGTH.OrderByDescending(x => x).First();

            return output;
        }

        #endregion
        #region Weapons

        private int GetNumberOfGuns()
        {
            var numberOfGuns =
                File.Contents.OfType<MACHNGUN>().Count() +
                File.Contents.OfType<MACHNGN2>().Count() +
                File.Contents.OfType<MACHNGN3>().Count() +
                File.Contents.OfType<MACHNGN4>().Count() +
                File.Contents.OfType<MACHNGN5>().Count() +
                File.Contents.OfType<MACHNGN6>().Count() +
                File.Contents.OfType<MACHNGN7>().Count() +
                File.Contents.OfType<MACHNGN8>().Count();
            return numberOfGuns;
        }

        private int GetAmmoOfGuns()
        {
            var input = (File.Contents.OfType<INITIGUN>().Any())
                ? new List<uint>
                {
                    File.Contents.OfType<INITIGUN>().Max(z => z.Value)
                }
                : new List<uint>
                {
                    0
                };

            var output = input.OrderByDescending(x => x).First();

            return (int)output;
        }
        private float GetPowerOfGuns()
        {
            var input = (File.Contents.OfType<GUNPOWER>().Any())
                ? new List<float>
                {
                    File.Contents.OfType<GUNPOWER>().Max(z => z.Value)
                }
                : new List<float>
                {
                    File.Contents.OfType<INITIGUN>().Any() ? 1 : 0
                };

            var output = input.OrderByDescending(x => x).First();

            return output;
        }
        private ISecond GetSpeedOfGuns()
        {
            var gunIntvls = File.Contents.OfType<GUNINTVL>().ToArray();
            var fastestSpeed = gunIntvls.Length > 0 ? gunIntvls.Select(x => x.Value).Min() : 1.Seconds();

            return (fastestSpeed.ToSeconds().RawValue > 0) ? fastestSpeed.ToSeconds() : 1.Seconds();
        }

        private double GetMaxGunDamagePerSecond()
        {
            return ((GetNumberOfGuns() * GetPowerOfGuns()) / GetSpeedOfGuns().ToSeconds().RawValue);
        }

        private int GetNumberOfWeapon(IYSTypeWeaponCategory Weapon)
        {
            var numberOnHardPoint = File.Contents
                .OfType<HRDPOINT>().ToArray()
                .Select(x => (int)x.GetWeaponQuantity(Weapon))
                .Sum();

            var numberOfSlot = 0;
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.AIM9.ToString()) numberOfSlot = File.Contents
                    .OfType<AAMSLOT_>()
                    .Count();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.AGM.ToString()) numberOfSlot = File.Contents
                    .OfType<AGMSLOT_>()
                    .Count();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.B500.ToString()) numberOfSlot = File.Contents
                    .OfType<BOMBSLOT>()
                    .Count();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.RKT.ToString()) numberOfSlot = File.Contents
                    .OfType<RKTSLOT_>()
                    .Count();

            uint numberOfInit = 0;
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.AIM9.ToString())
                numberOfInit = File.Contents
                    .OfType<INITIAAM>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.AGM.ToString())
                numberOfInit = File.Contents
                    .OfType<INITIAGM>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.AIM9X.ToString())
                numberOfInit = File.Contents
                    .OfType<INITAAMM>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.B250.ToString())
                numberOfInit = File.Contents
                    .OfType<INITBOMB>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.B500.ToString())
                numberOfInit = File.Contents
                    .OfType<INITBOMB>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == Extensions.YSFlight.WeaponCategories.RKT.ToString())
                numberOfInit = File.Contents
                    .OfType<INITRCKT>()
                    .Select(x => x.Value)
                    .LastOrDefault()/19;

            var maxQtyWeapon = new int[]
            {
                numberOnHardPoint,
                numberOfSlot,
                (int)numberOfInit
            }.Max();

            return maxQtyWeapon;
        }
        public double CalculateWeaponScore()
        {
            var AAM = GetNumberOfWeapon(Extensions.YSFlight.WeaponCategories.AIM9);
            var A_AAM = GetNumberOfWeapon(Extensions.YSFlight.WeaponCategories.AIM9X);
            var AGM = GetNumberOfWeapon(Extensions.YSFlight.WeaponCategories.AGM);
            var RKT = GetNumberOfWeapon(Extensions.YSFlight.WeaponCategories.RKT);
            var B250 = GetNumberOfWeapon(Extensions.YSFlight.WeaponCategories.B250);
            var B500 = GetNumberOfWeapon(Extensions.YSFlight.WeaponCategories.B500);
            var B500HD = GetNumberOfWeapon(Extensions.YSFlight.WeaponCategories.B500HD);
            var GUN = GetMaxGunDamagePerSecond() * (GetAmmoOfGuns()/3000d);

			//TODO: SOLVE SLOT LOADING  (PRIOTITY=0)
			//TODO: SOLVE SCORE BALANCE  (PRIOTITY=0)
			var score =
                (AAM * 1.0d) +
                (A_AAM * 1.2d) +
                (AGM * 0.9d) +
                (RKT * 0.75d) +
                (B250 * 0.5d) +
                (B500 * 0.6d) +
                (B500HD * 0.5d) +
                (GUN * 0.07d);

            return score;
        }

        #endregion
        #region Stealth

        public double CalculateStealth()
        {
            var RADARCRS = (File.Contents.OfType<RADARCRS>().Any())
                ? new List<float>
                {
                    File.Contents.OfType<RADARCRS>().Max(z => z.Value)
                }
                : new List<float>
                {
                    1
                };
            var BMBAYRCS = (File.Contents.OfType<BMBAYRCS>().Any())
                ? new List<float>
                {
                    File.Contents.OfType<BMBAYRCS>().Max(z => z.Value)
                }
                : new List<float>
                {
                    1
                };
            var RADARCRSMin = RADARCRS.OrderByDescending(x => x).First();
            var BMBAYRCSMin = BMBAYRCS.OrderByDescending(x => x).First();

            var output = (RADARCRSMin < BMBAYRCSMin) ? RADARCRSMin : BMBAYRCSMin;

            return output;
        }

        #endregion

        public float GetScore(IQuadraticEquation EQ, double Value)
        {
            float score = (float)EQ.SolveForResult(Value);
            if (score < 0) score = 0;
            if (score > 10) score = 10;
            return score;
        }

        public void ShowDebug()
        {
	        var ThrustToWeightRatio = ObjectFactory.CreateStatisticsCurve(0, 0.5, 2);
            Debug.AddSummaryMessage("----====----ThrustToWeightRatio: " + GetScore(ThrustToWeightRatio, CalculateThrustToWeightRatio()));

            var MaxCruiseSpeed = ObjectFactory.CreateStatisticsCurve(0, 350, 1000);
			Debug.AddSummaryMessage("----====----MaxCruiseSpeed: " + GetScore(MaxCruiseSpeed, CalculateMaxCruiseSpeed()));

            var MaxTurnRate = ObjectFactory.CreateStatisticsCurve(0, 0.0075, 0.05);
			Debug.AddSummaryMessage("----====----MaxTurnRate: " + GetScore(MaxTurnRate, CalculateMaxTurnRate()));

            var MaxStrength = ObjectFactory.CreateStatisticsCurve(0, 10, 100);
			Debug.AddSummaryMessage("----====----MaxStrength: " + GetScore(MaxStrength, CalculateMaxStrength()));

            var WeaponScore = ObjectFactory.CreateStatisticsCurve(0, 10, 100);
			Debug.AddSummaryMessage("----====----WeaponScore: " + GetScore(WeaponScore, CalculateWeaponScore()));

            var Stealth = ObjectFactory.CreateStatisticsCurve(1, 0.5, 0);
			Debug.AddSummaryMessage("----====----Stealth: " + GetScore(Stealth, CalculateStealth()));
        }
    }
}
