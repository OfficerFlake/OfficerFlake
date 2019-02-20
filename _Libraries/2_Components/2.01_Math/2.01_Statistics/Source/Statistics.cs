using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Loggers;

namespace Com.OfficerFlake.Libraries.Math.Statistics
{
    public class Statistic : IStatistic
    {
        #region CTOR
        public Statistic(string name)
        {
            Name = name;
        }
        #endregion
        public string Name { get;}
        public List<double> Samples { get; set; } = new List<double>();
	    public int n => Samples.Count;

	    public double Sum()
	    {
		    if (n == 0) return 0;
			return Samples.Sum();
	    }
        public double Min()
        {
            if (n == 0) return 0;
            return Samples.Min();
        }
	    public double Max()
	    {
		    if (n == 0) return 0;
		    return Samples.Max();
	    }
		public double Mode()
        {
            if (n == 0) return 0;
            return Samples.GroupBy(v => v).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
        }
        public double Mean()
        {
            if (n == 0) return 0;
            return Samples.Select(x => x/n).Sum();
        }
	    public double Variance()
	    {
		    double ret = 0;
		    if (n > 0)
		    {
			    //Compute the Average      
			    var avg = Mean();
			    //Perform the Sum of (value-avg)_2_2      
			    var sum = Samples.Sum(d => ((avg - d) * (avg - d)));
			    //Put it all together      
			    ret = sum;
		    }
		    return ret;
	    }
		public double StandardDeviation()
        {
            return System.Math.Sqrt(Variance());
        }

        public void DebugShowStatistics()
        {
            Logger.AddDebugMessage(Name + ": ");
            Logger.AddDebugMessage("----MODE: " + Mode());
            Logger.AddDebugMessage("----MEAN: " + Mean());
            Logger.AddDebugMessage("----STDDEV: " + StandardDeviation());
            Logger.AddDebugMessage("----MAX : " + Max());
            Logger.AddDebugMessage("----MIN : " + Min());
        }
    }
}
