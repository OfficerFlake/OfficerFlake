using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Com.OfficerFlake.Libraries.Math;
using Com.OfficerFlake.Libraries.Math.CoordinateSystems;
using Com.OfficerFlake.Libraries.Math.Statistics;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;
using Com.OfficerFlake.Libraries.YSFlight.Types;
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

            public static Statistic ThrustToWeightRatio = new Statistic(Names.ThrustToWeightRatio);
            public static Statistic MaxCruiseSpeed = new Statistic(Names.MaxCruiseSpeed);
            public static Statistic MaxCornerRate = new Statistic(Names.MaxCornerRate);
            public static Statistic MaxStrength = new Statistic(Names.MaxStrength);
            public static Statistic MaxWeaponLoadout = new Statistic(Names.MaxWeaponLoadout);
            public static Statistic MaxStealth = new Statistic(Names.MaxStealth);

            public static void Update(SpiderGraph Graph)
            {
                ThrustToWeightRatio.AddSample(Graph.CalculateThrustToWeightRatio());

                ThrustToWeightRatio.AddSample(Graph.CalculateThrustToWeightRatio());
                MaxCruiseSpeed.AddSample(Graph.CalculateMaxCruiseSpeed());
                MaxCornerRate.AddSample(Graph.CalculateMaxTurnRate());
                MaxStrength.AddSample(Graph.CalculateMaxStrength());
                MaxWeaponLoadout.AddSample(Graph.CalculateWeaponScore());
                MaxStealth.AddSample(Graph.CalculateStealth());
            }
            public static void Clear()
            {
                ThrustToWeightRatio.ClearSamples();
                MaxCruiseSpeed.ClearSamples();
                MaxCornerRate.ClearSamples();
                MaxStrength.ClearSamples();
                MaxWeaponLoadout.ClearSamples();
                MaxStealth.ClearSamples();
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

        private Mass GetMaxThrust()
        {
            var magicnumber_propellorpower = 0.0053333333333333m;
            var input = new List<Mass>
            {
                File.Properties.OfType<THRAFTBN>().Max(z => z.Value),
                File.Properties.OfType<THRMILIT>().Max(z => z.Value),
                File.Properties.OfType<PROPELLR>().Max(z => (z.Value.ConvertToBase*magicnumber_propellorpower).Kilograms().ToMetricTonnes())

            };
            var output = (input.All(y => y == null)) ? 0.MetricTonnes() : input.Where(y => y != null).OrderByDescending(x => x.ConvertToBase).First();

            return output;
        }
        private Mass GetMinWeight()
        {
            var input = new List<Mass>
            {
                File.Properties.OfType<WEIGHCLN>().Min(z => z.Value)
            };
            var output = (input.All(y => y == null)) ? 0.MetricTonnes() : input.Where(y => y != null).OrderByDescending(x => x.ConvertToBase).Last();
            return output;
        }
        private Mass GetOperatingWeight()
        {
            var weightClean = new List<Mass>
            {
                File.Properties.OfType<WEIGHCLN>().Min(z => z.Value)
            };
            var weightFuel50Percent = new List<Mass>
            {
                File.Properties.OfType<WEIGFUEL>().Min(z => z.Value)
            };
            var weightCleanOut = weightClean.All(y => y == null) ?
                0.MetricTonnes() :
                weightClean.Where(y => y != null).OrderByDescending(x => x.ConvertToBase).Last();
            var weightFuel50PercentOut = 0.5 *
                ((weightClean.All(y => y == null)) ?
                    0.MetricTonnes() :
                    weightClean.Where(y => y != null).OrderByDescending(x => x.ConvertToBase).Last()
                );
            return (weightCleanOut + weightFuel50PercentOut).Kilograms();
        }
        public decimal CalculateThrustToWeightRatio()
        {
            decimal numerator = GetMaxThrust().ConvertToBase;
            decimal denominator = GetOperatingWeight().ConvertToBase;
            if (denominator == 0) return decimal.MaxValue;
            decimal output = numerator / denominator;
            return output;
        }

        #endregion
        #region CruiseSpeed

        private Speed GetCruiseSpeed()
        {
            var input = new List<Speed>
            {
                File.Properties.OfType<REFVCRUS>().Max(z => z.Value),

            };
            var output = (input.All(y => y == null)) ? 0.Knotss() : input.Where(y => y != null).OrderByDescending(x => x.ConvertToBase).First();

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
        public decimal CalculateMaxCruiseSpeed()
        {
            decimal numerator = GetCruiseSpeed().ConvertToBase;
            decimal denominator = (decimal)GetCruiseThrottle();
            if (denominator == 0) return 0;
            decimal output = numerator / denominator;
            return output;
        }

        #endregion
        #region MaxTurnRate

        private Angle GetMaxInputAoA()
        {
            var ListOfMXIPTAOA = new List<Angle>
            {
                File.Properties.OfType<MXIPTAOA>().Max(z => z.Value),
            };
            var MXIPTAOA = (ListOfMXIPTAOA.All(y => y == null)) ? 0.Degrees() : ListOfMXIPTAOA.Where(y => y != null).OrderByDescending(x => x.ConvertToBase).First();

            return MXIPTAOA;
        }
        private Angle GetPSTMAoA()
        {
            var ListOfPSTMPTCH = new List<Angle>
            {
                File.Properties.OfType<PSTMPTCH>().Max(z => z.Value),
            };
            var PSTMPTCH = (ListOfPSTMPTCH.All(y => y == null)) ? 0.Degrees() : ListOfPSTMPTCH.Where(y => y != null).OrderByDescending(x => x.ConvertToBase).First();

            return PSTMPTCH;
        }
        public decimal CalculateMaxTurnRate()
        {
            return (GetMaxInputAoA().ConvertToBase + GetPSTMAoA().ConvertToBase).Radians().ToDegrees();
        }

        #endregion
        #region Strength

        public decimal CalculateMaxStrength()
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

            return (decimal)output;
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
                ? new List<int>
                {
                    File.Properties.OfType<INITIGUN>().Max(z => z.Value)
                }
                : new List<int>
                {
                    0
                };

            var output = input.OrderByDescending(x => x).First();

            return output;
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

        private decimal GetMaxGunDamagePerSecond()
        {
            return ((GetNumberOfGuns() * (decimal)GetPowerOfGuns()) / (decimal)GetSpeedOfGuns());
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

            var numberOfInit = 0;
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
                numberOfInit
            }.Max();

            return maxQtyWeapon;
        }
        public decimal CalculateWeaponScore()
        {
            var AAM = GetNumberOfWeapon(WeaponCategory.AIM9);
            var A_AAM = GetNumberOfWeapon(WeaponCategory.AIM9X);
            var AGM = GetNumberOfWeapon(WeaponCategory.AGM);
            var RKT = GetNumberOfWeapon(WeaponCategory.RKT);
            var B250 = GetNumberOfWeapon(WeaponCategory.B250);
            var B500 = GetNumberOfWeapon(WeaponCategory.B500);
            var B500HD = GetNumberOfWeapon(WeaponCategory.B500HD);
            var GUN = GetMaxGunDamagePerSecond() * (GetAmmoOfGuns()/3000M);

			//TODO: SOLVE SLOT LOADING  (PRIOTITY=0)
			//TODO: SOLVE SCORE BALANCE  (PRIOTITY=0)
			var score =
                (AAM * 1.0M) +
                (A_AAM * 1.2M) +
                (AGM * 0.9M) +
                (RKT * 0.75M) +
                (B250 * 0.5M) +
                (B500 * 0.6M) +
                (B500HD * 0.5M) +
                (GUN * 0.07M);

            return score;
        }

        #endregion
        #region Stealth

        public decimal CalculateStealth()
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

            return (decimal)output;
        }

        #endregion

        public float GetScore(Equations.Quadratic EQ, decimal Value)
        {
            float score = EQ.Solve(Value);
            if (score < 0) score = 0;
            if (score > 10) score = 10;
            return score;
        }

        public void ShowDebug()
        {
            var ThrustToWeightRatio = Equations.Quadratic.From3Point2s(new Point2(0m, 0m), new Point2(0.5m, 5m), new Point2(2m, 10m));
            Debug.WriteLine("----====----ThrustToWeightRatio: " + GetScore(ThrustToWeightRatio, CalculateThrustToWeightRatio()));

            var MaxCruiseSpeed = Equations.Quadratic.From3Point2s(new Point2(0m, 0m), new Point2(350m, 5m), new Point2(1000m, 10m));
            Debug.WriteLine("----====----MaxCruiseSpeed: " + GetScore(MaxCruiseSpeed, CalculateMaxCruiseSpeed()));

            var MaxTurnRate = Equations.Quadratic.From3Point2s(new Point2(0m, 0m), new Point2(0.0075m, 5m), new Point2(0.05m, 10m));
            Debug.WriteLine("----====----MaxTurnRate: " + GetScore(MaxTurnRate, CalculateMaxTurnRate()));

            var MaxStrength = Equations.Quadratic.From3Point2s(new Point2(0m, 0m), new Point2(10m, 5m), new Point2(100m, 10m));
            Debug.WriteLine("----====----MaxStrength: " + GetScore(MaxStrength, CalculateMaxStrength()));

            var WeaponScore = Equations.Quadratic.From3Point2s(new Point2(0m, 0m), new Point2(10m, 5m), new Point2(100m, 10m));
            Debug.WriteLine("----====----WeaponScore: " + GetScore(WeaponScore, CalculateWeaponScore()));

            var Stealth = Equations.Quadratic.From3Point2s(new Point2(1m, 0m), new Point2(0.5m, 5m), new Point2(0m, 10m));
            Debug.WriteLine("----====----Stealth: " + GetScore(Stealth, CalculateStealth()));
        }
    }
}
