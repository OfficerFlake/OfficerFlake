using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties;
using Com.OfficerFlake.Libraries.Logger;

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

            public static Statistic ThrustToWeightRatio = new Statistic(Names.ThrustToWeightRatio);
            public static Statistic MaxCruiseSpeed = new Statistic(Names.MaxCruiseSpeed);
            public static Statistic MaxCornerRate = new Statistic(Names.MaxCornerRate);
            public static Statistic MaxStrength = new Statistic(Names.MaxStrength);
            public static Statistic MaxWeaponLoadout = new Statistic(Names.MaxWeaponLoadout);
            public static Statistic MaxStealth = new Statistic(Names.MaxStealth);

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

            public static void ShowDebug()
            {
                ThrustToWeightRatio.DebugShowStatistics();
                MaxCruiseSpeed.DebugShowStatistics();
                MaxCornerRate.DebugShowStatistics();
                MaxStrength.DebugShowStatistics();
                MaxWeaponLoadout.DebugShowStatistics();
                MaxStealth.DebugShowStatistics();
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
                File.Properties.OfType<THRAFTBN>().Max(z => z.Value),
                File.Properties.OfType<THRMILIT>().Max(z => z.Value),
                File.Properties.OfType<PROPELLR>().Max(z => (z.Value.ConversionRatio*magicnumber_propellorpower).Kilograms().ToMetricTonnes())

            };
            var output = (input.All(y => y == null)) ? 0.MetricTonnes() : input.Where(y => y != null).OrderByDescending(x => x).First();

            return output;
        }
        private IMass GetMinWeight()
        {
            var input = new List<IMass>
            {
                File.Properties.OfType<WEIGHCLN>().Min(z => z.Value)
            };
            var output = (input.All(y => y == null)) ? 0.MetricTonnes() : input.Where(y => y != null).OrderByDescending(x => x).Last();
            return output;
        }
        private Mass GetOperatingWeight()
        {
            var weightClean = new List<IMass>
            {
                File.Properties.OfType<WEIGHCLN>().Min(z => z.Value)
            };
            var weightFuel50Percent = new List<IMass>
            {
                File.Properties.OfType<WEIGFUEL>().Min(z => z.Value)
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
            return (weightCleanOut.ToKilograms().RawValue + weightFuel50PercentOut.ToKilograms().RawValue).Kilograms();
        }
        public double CalculateThrustToWeightRatio()
        {
	        double numerator = GetMaxThrust().ToMetricTonnes().RawValue;
	        double denominator = GetOperatingWeight().ConvertToBase();
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
                File.Properties.OfType<REFVCRUS>().Max(z => z.Value),

            };
            var output = (input.All(y => y == null)) ? 0.Knots() : input.Where(y => y != null).OrderByDescending(x => x).First();

            return output;
        }
        private float GetCruiseThrottle()
        {
            var input = new List<float>
            {
                File.Properties.OfType<REFTCRUS>().Max(z => z.Value),
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
                File.Properties.OfType<MXIPTAOA>().Max(z => z.Value),
            };
            var MXIPTAOA = (ListOfMXIPTAOA.All(y => y == null)) ? 0.Degrees() : ListOfMXIPTAOA.Where(y => y != null).OrderByDescending(x => x).First();

            return MXIPTAOA;
        }
        private IAngle GetPSTMAoA()
        {
            var ListOfPSTMPTCH = new List<IAngle>
            {
                File.Properties.OfType<PSTMPTCH>().Max(z => z.Value),
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
            var STRENGTH = (File.Properties.OfType<STRENGTH>().Any())
                ? new List<float>
                {
                    File.Properties.OfType<STRENGTH>().Max(z => z.Value)
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
                File.Properties.OfType<MACHNGUN>().Count() +
                File.Properties.OfType<MACHNGN2>().Count() +
                File.Properties.OfType<MACHNGN3>().Count() +
                File.Properties.OfType<MACHNGN4>().Count() +
                File.Properties.OfType<MACHNGN5>().Count() +
                File.Properties.OfType<MACHNGN6>().Count() +
                File.Properties.OfType<MACHNGN7>().Count() +
                File.Properties.OfType<MACHNGN8>().Count();
            return numberOfGuns;
        }

        private int GetAmmoOfGuns()
        {
            var input = (File.Properties.OfType<INITIGUN>().Any())
                ? new List<uint>
                {
                    File.Properties.OfType<INITIGUN>().Max(z => z.Value)
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
            var input = (File.Properties.OfType<GUNPOWER>().Any())
                ? new List<float>
                {
                    File.Properties.OfType<GUNPOWER>().Max(z => z.Value)
                }
                : new List<float>
                {
                    File.Properties.OfType<INITIGUN>().Any() ? 1 : 0
                };

            var output = input.OrderByDescending(x => x).First();

            return output;
        }
        private float GetSpeedOfGuns()
        {
            var gunIntvls = File.Properties.OfType<GUNINTVL>().ToArray();
            var fastestSpeed = gunIntvls.Length > 0 ? gunIntvls.Select(x => x.Value).Min() : 1;

            return fastestSpeed > 0 ? fastestSpeed : 1;
        }

        private double GetMaxGunDamagePerSecond()
        {
            return ((GetNumberOfGuns() * GetPowerOfGuns()) / GetSpeedOfGuns());
        }

        private int GetNumberOfWeapon(WeaponCategory Weapon)
        {
            var numberOnHardPoint = File.Properties
                .OfType<HRDPOINT>().ToArray()
                .Select(x => x.GetWeaponQuantity(Weapon))
                .Sum();

            var numberOfSlot = 0;
            if (Weapon.ToString() == WeaponCategory.AIM9.ToString()) numberOfSlot = File.Properties
                    .OfType<AAMSLOT_>()
                    .Count();
            if (Weapon.ToString() == WeaponCategory.AGM.ToString()) numberOfSlot = File.Properties
                    .OfType<AGMSLOT_>()
                    .Count();
            if (Weapon.ToString() == WeaponCategory.B500.ToString()) numberOfSlot = File.Properties
                    .OfType<BOMBSLOT>()
                    .Count();
            if (Weapon.ToString() == WeaponCategory.RKT.ToString()) numberOfSlot = File.Properties
                    .OfType<RKTSLOT_>()
                    .Count();

            uint numberOfInit = 0;
            if (Weapon.ToString() == WeaponCategory.AIM9.ToString())
                numberOfInit = File.Properties
                    .OfType<INITIAAM>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == WeaponCategory.AGM.ToString())
                numberOfInit = File.Properties
                    .OfType<INITIAGM>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == WeaponCategory.AIM9X.ToString())
                numberOfInit = File.Properties
                    .OfType<INITAAMM>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == WeaponCategory.B250.ToString())
                numberOfInit = File.Properties
                    .OfType<INITBOMB>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == WeaponCategory.B500.ToString())
                numberOfInit = File.Properties
                    .OfType<INITBOMB>()
                    .Select(x => x.Value)
                    .LastOrDefault();
            if (Weapon.ToString() == WeaponCategory.RKT.ToString())
                numberOfInit = File.Properties
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
            var AAM = GetNumberOfWeapon(WeaponCategory.AIM9);
            var A_AAM = GetNumberOfWeapon(WeaponCategory.AIM9X);
            var AGM = GetNumberOfWeapon(WeaponCategory.AGM);
            var RKT = GetNumberOfWeapon(WeaponCategory.RKT);
            var B250 = GetNumberOfWeapon(WeaponCategory.B250);
            var B500 = GetNumberOfWeapon(WeaponCategory.B500);
            var B500HD = GetNumberOfWeapon(WeaponCategory.B500HD);
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
            var RADARCRS = (File.Properties.OfType<RADARCRS>().Any())
                ? new List<float>
                {
                    File.Properties.OfType<RADARCRS>().Max(z => z.Value)
                }
                : new List<float>
                {
                    1
                };
            var BMBAYRCS = (File.Properties.OfType<BMBAYRCS>().Any())
                ? new List<float>
                {
                    File.Properties.OfType<BMBAYRCS>().Max(z => z.Value)
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

        public float GetScore(Equations.Quadratic EQ, double Value)
        {
            float score = (float)EQ.SolveForResult(Value);
            if (score < 0) score = 0;
            if (score > 10) score = 10;
            return score;
        }

        public void ShowDebug()
        {
	        var ThrustToWeightRatio = Equations.Quadratic.StatisticCurve(0, 0.5, 2);
            Debug.AddSummaryMessage("----====----ThrustToWeightRatio: " + GetScore(ThrustToWeightRatio, CalculateThrustToWeightRatio()));

            var MaxCruiseSpeed = Equations.Quadratic.StatisticCurve(0, 350, 1000);
			Debug.AddSummaryMessage("----====----MaxCruiseSpeed: " + GetScore(MaxCruiseSpeed, CalculateMaxCruiseSpeed()));

            var MaxTurnRate = Equations.Quadratic.StatisticCurve(0, 0.0075, 0.05);
			Debug.AddSummaryMessage("----====----MaxTurnRate: " + GetScore(MaxTurnRate, CalculateMaxTurnRate()));

            var MaxStrength = Equations.Quadratic.StatisticCurve(0, 10, 100);
			Debug.AddSummaryMessage("----====----MaxStrength: " + GetScore(MaxStrength, CalculateMaxStrength()));

            var WeaponScore = Equations.Quadratic.StatisticCurve(0, 10, 100);
			Debug.AddSummaryMessage("----====----WeaponScore: " + GetScore(WeaponScore, CalculateWeaponScore()));

            var Stealth = Equations.Quadratic.StatisticCurve(1, 0.5, 0);
			Debug.AddSummaryMessage("----====----Stealth: " + GetScore(Stealth, CalculateStealth()));
        }
    }
}
