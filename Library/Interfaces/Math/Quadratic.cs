namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IQuadraticEquation
	{
		double Y { get; set; }
		double X { get; set; }
		double A { get; set; }
		double B { get; set; }
		double C { get; set; }

		double SolveForY();
		double SolveForX();
		double SolveForA();
		double SolveForB();
		double SolveForC();
	}
}
