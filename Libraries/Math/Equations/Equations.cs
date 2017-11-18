using Com.OfficerFlake.Libraries.Math.CoordinateSystems;

namespace Com.OfficerFlake.Libraries.Math
{
    public abstract class Equations
    {
        public class Quadratic
        {
            #region Properties

            public decimal Result;
            public decimal A;
            public decimal B;
            public decimal C;

            #endregion
            #region Constructors
            public Quadratic()
            {
            }
            public Quadratic(decimal x, decimal y)
            {
                Result = y;
                A = x*x;
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

            public static Quadratic From3Point2s(Point2 A, Point2 B, Point2 C)
            {
                //Convert the 3 points to quadratic equations.
                var equation1 = new Quadratic(A.X, A.Y);
                var equation2 = new Quadratic(B.X, B.Y);
                var equation3 = new Quadratic(C.X, C.Y);

                //Cancel out "C"
                var equation4 = equation1.MakeSubject(equation1.C) - equation2.MakeSubject(equation2.C);
                var equation5 = equation2.MakeSubject(equation2.C) - equation3.MakeSubject(equation3.C);

                //Cancel out "B"
                var equation6 = equation4.MakeSubject(equation4.B) - equation5.MakeSubject(equation5.B);

                //Solve for A then B then C
                var a = equation6.MakeSubject(equation6.A).Result; //Substitute into EQ 6
                var b = (equation4.Result - equation4.A*a)/equation4.B; //Into EQ 4
                var c = A.Y - (a * A.X * A.X) - (b * A.X); //Into EQ 1

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
            public Quadratic MakeSubject(decimal value)
            {
                Quadratic output = new Quadratic(this);
                //No adjustment for X, this is intrinsic 
                output.Result /= value;
                output.A /= value;
                output.B /= value;
                output.C /= value;
                return output;
            }
            public float Solve(decimal X)
            {
                return (float)(A * (X * X) + B * X + C);
            }
            #endregion
            #region Operators
            public static Quadratic operator -(Quadratic Eq1, Quadratic Eq2)
            {
                return new Quadratic()
                {
                    A = Eq1.A - Eq2.A,
                    B = Eq1.B - Eq2.B,
                    C = Eq1.C - Eq2.C,
                    Result = Eq1.Result - Eq2.Result,
                };
            }
            public static Quadratic operator +(Quadratic Eq1, Quadratic Eq2)
            {
                return new Quadratic()
                {
                    A = Eq1.A + Eq2.A,
                    B = Eq1.B + Eq2.B,
                    C = Eq1.C + Eq2.C,
                    Result = Eq1.Result + Eq2.Result,
                };
            }
            #endregion
        }
    }
}
