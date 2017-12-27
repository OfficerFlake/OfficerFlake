namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IQuadraticEquation
	{
		double Result { get; set; }
		double A { get; set; }
		double B { get; set; }
		double C { get; set; }

		IQuadraticEquation MakeSubject(double value);
		IQuadraticEquation Subtract(IQuadraticEquation subtractQuadraticEquation);
		IQuadraticEquation Add(IQuadraticEquation subtractQuadraticEquation);

		double SolveForResult(double x);
		double SolveForA(double x);
		double SolveForB(double x);
		double SolveForC(double x);
	}
}
