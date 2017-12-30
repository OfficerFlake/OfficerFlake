using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Math
{
    public abstract class Equations
    {
        public class Quadratic : IQuadraticEquation
        {
            #region Properties
            public double Result { get; set; }
			public double A { get; set; }
			public double B { get; set; }
			public double C { get; set; }
			#endregion
			#region Constructors
			public Quadratic(){}
            public Quadratic(double result, double a, double b, double c)
            {
                Result = result;
                A = a;
                B = b;
                C = c;
            }

	        public Quadratic(double x, double y)
	        {
		        Result = y;
		        A = x * x;
		        B = x;
		        C = 1;
	        }
			public Quadratic(Quadratic duplicate)
            {
                Result = duplicate.Result;
                A = duplicate.A;
                B = duplicate.B;
                C = duplicate.C;
            }

            public static Quadratic From3Coordinate2(ICoordinate2 A, ICoordinate2 B, ICoordinate2 C)
            {
                //Convert the 3 points to quadratic equations.
                var equation1 = new Quadratic(A.X, A.Y);
                var equation2 = new Quadratic(B.X, B.Y);
                var equation3 = new Quadratic(C.X, C.Y);

                //Cancel out "C"
	            var equation4 = equation1.MakeSubject(equation1.C).Subtract(equation2.MakeSubject(equation1.C));
	            var equation5 = equation2.MakeSubject(equation2.C).Subtract(equation3.MakeSubject(equation3.C));

				//Cancel out "B"
				var equation6 = equation4.MakeSubject(equation4.B).Subtract(equation5.MakeSubject(equation5.B));

				//Solve for A then B then C
				var a = equation6.MakeSubject(equation6.A).Result; //Substitute into EQ 6
                var b = (equation4.Result - equation4.A*a)/equation4.B; //Into EQ 4
                var c = (A.Y) - (a * (A.X) * (A.X)) - (b * (A.X)); //Into EQ 1

                //Create new Quadratic solver based on A, B and C.
                var output = new Quadratic
                {
                    A = a,
                    B = b,
                    C = c
                };
                return output;
            }
            #endregion
            #region Methods
            public IQuadraticEquation MakeSubject(double value)
            {
                Quadratic output = new Quadratic(this);
                //No adjustment for X, this is intrinsic 
                output.Result /= value;
                output.A /= value;
                output.B /= value;
                output.C /= value;
                return output;
            }
	        public double SolveForResult(double X)
	        {
		        return MakeSubject(Result).Result;
	        }
	        public double SolveForA(double X)
	        {
		        return MakeSubject(A).A;
	        }
	        public double SolveForB(double X)
	        {
		        return MakeSubject(B).B;
	        }
	        public double SolveForC(double X)
	        {
		        return MakeSubject(C).C;
	        }
			#endregion
			#region Operators
	        public IQuadraticEquation Subtract(IQuadraticEquation subtractQuadraticEquation)
	        {
		        var output = new Quadratic();
		        output.Result = Result - subtractQuadraticEquation.Result;
		        output.A = A - subtractQuadraticEquation.A;
		        output.B = B - subtractQuadraticEquation.B;
				output.C = C - subtractQuadraticEquation.C;
		        return output;
	        }
	        public IQuadraticEquation Add(IQuadraticEquation subtractQuadraticEquation)
	        {
		        var output = new Quadratic();
		        output.Result = Result + subtractQuadraticEquation.Result;
		        output.A = A + subtractQuadraticEquation.A;
		        output.B = B + subtractQuadraticEquation.B;
		        output.C = C + subtractQuadraticEquation.C;
		        return output;
	        }
			#endregion

			public static Quadratic StatisticCurve(double x1, double x2, double x3)
	        {
		        return Quadratic.From3Coordinate2(
			        ObjectFactory.CreateCoordinate2(x1, 0.0d),
			        ObjectFactory.CreateCoordinate2(x2, 0.5d),
			        ObjectFactory.CreateCoordinate2(x3, 1.0d));
	        }
        }
    }
}
