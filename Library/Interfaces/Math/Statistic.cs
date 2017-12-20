using System;
using System.Collections.Generic;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IStatistic
	{
		List<double> Samples { get; set; }
		int n { get; }

		double Min();
		double Max();
		double Sum();
		double Mode();
		double Mean();
		double Variance();
		double StandardDeviation();
	}

	public static class StatisticsExtensions
	{
		//TODO : Mopve to Implementation
		public static double GetCorrelationCoefficient(IStatistic X, IStatistic Y)
		{
			int n = (X.n > Y.n) ? X.n : Y.n;

			double sumX = 0;
			double sumY = 0;
			double sumXY = 0;
			double sumXSquared = 0;
			double sumYSquared = 0;

			for (int i = 0; i < n; i++)
			{
				double xSample = X.Mean();
				if (X.n-1 >= i) xSample = X.Samples[i];
				double ySample = Y.Mean();
				if (Y.n-1 >= i) ySample = Y.Samples[i];

				sumX += xSample;
				sumY += ySample;
				sumXY += xSample * ySample;
				sumXSquared += xSample * xSample;
				sumYSquared += ySample * ySample;
			}

			return
				(n * sumXY - sumX * sumY)
				/
				(Math.Sqrt
					(
					(n * sumXSquared - sumX*sumX)*(n*sumYSquared-sumY*sumY)
					)
				);
		}
		public static double GetCoefficientOfDetermination(IStatistic X, IStatistic Y)
		{
			double r = GetCorrelationCoefficient(X, Y);
			return r * r;
		}
	}
}
