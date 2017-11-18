using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Com.OfficerFlake.Libraries.Math.Statistics
{
    public class Statistic
    {
        #region CTOR

        public Statistic(string name)
        {
            Name = name;
        }
        #endregion
        public string Name { get;}
        private List<decimal> samplesList = new List<decimal>();

        public decimal Max()
        {
            if (samplesList.Count == 0) return 0;
            return samplesList.Max();
        }
        public decimal Min()
        {
            if (samplesList.Count == 0) return 0;
            return samplesList.Min();
        }
        public decimal Mode()
        {
            if (samplesList.Count == 0) return 0;
            return samplesList.GroupBy(v => v).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
        }
        public decimal Mean()
        {
            if (samplesList.Count == 0) return 0;
            return samplesList.Select(x => x/samplesList.Count).Sum();
        }
        public decimal StandardDeviation()
        {
            decimal ret = 0;
            if (samplesList.Count() > 0)
            {
                //Compute the Average      
                var avg = Mean();
                //Perform the Sum of (value-avg)_2_2      
                var sum = samplesList.Sum(d => ((d - avg) * (d - avg)));
                //Put it all together      
                ret = (decimal)System.Math.Sqrt((double)((sum) / (samplesList.Count() - 1)));
            }
            return ret;
        }

        public void AddSample(decimal value)
        {
            lock (samplesList)
            {
                samplesList.Add(value);
            }
        }

        public void ClearSamples()
        {
            samplesList.Clear();
        }

        public void DebugShowStatistics()
        {
            Debug.WriteLine(Name + ": ");
            Debug.WriteLine("----MODE: " + Mode());
            Debug.WriteLine("----MEAN: " + Mean());
            Debug.WriteLine("----STDDEV: " + StandardDeviation());
            Debug.WriteLine("----MAX : " + Max());
            Debug.WriteLine("----MIN : " + Min());
        }
    }
}
