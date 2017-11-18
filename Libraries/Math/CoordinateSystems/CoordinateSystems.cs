using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.OfficerFlake.Libraries.Math.CoordinateSystems
{
	public abstract class Point
    {
        private decimal[] dimension = new decimal[0];

        public int NumberOfDimensions
        {
            get { return (dimension ?? new decimal[0]).ToArray().Length; }
            set
            {
                var DimensionCopy = new List<decimal>();
                for (int i = 0; i < NumberOfDimensions; i++)
                {
                    DimensionCopy.Add(dimension[i]);
                }
                for (int i = 0; i < value-NumberOfDimensions; i++)
                {
                    DimensionCopy.Add(0);
                }
                dimension = DimensionCopy.ToArray();
            }
        }

        protected decimal GetValueAtDimensionOrZero(int targetDimension)
        {
            return (NumberOfDimensions < targetDimension+1) ? 0m : dimension[targetDimension];
        }
        protected bool SetValueAtDimension(int targetDimension, decimal value)
        {
            if (NumberOfDimensions < targetDimension+1)
            {
                NumberOfDimensions = targetDimension + 1;
            }
            dimension[targetDimension] = value;
            return true;
        }

        protected Point(int numDimensions)
        {
            NumberOfDimensions = numDimensions;
        }

        private enum OperatorTypes
        {
            Add,
            Subtract,
            Multiply,
            Divide,
        }
        private static Point OperatorGeneric(Point A, Point B, OperatorTypes Operator)
        {
            int numberOfDimensions = (A.NumberOfDimensions < B.NumberOfDimensions) ? A.NumberOfDimensions : B.NumberOfDimensions;
            var values = new List<decimal>();
            for (var i = 0; i < numberOfDimensions; i++)
            {
                switch (Operator)
                {
                    case OperatorTypes.Add:
                        values.Add((A.GetValueAtDimensionOrZero(i) + B.GetValueAtDimensionOrZero(i)));
                        continue;
                    case OperatorTypes.Subtract:
                        values.Add((A.GetValueAtDimensionOrZero(i) - B.GetValueAtDimensionOrZero(i)));
                        continue;
                    case OperatorTypes.Multiply:
                        values.Add((A.GetValueAtDimensionOrZero(i) * B.GetValueAtDimensionOrZero(i)));
                        continue;
                    case OperatorTypes.Divide:
                        values.Add((A.GetValueAtDimensionOrZero(i) / B.GetValueAtDimensionOrZero(i)));
                        continue;
                    default:
                        throw new ArgumentException("Operator Invalid.");
                }
            }
            switch (numberOfDimensions)
            {
                case 1:
                    return new Point1(values[0]);
                case 2:
                    return new Point2(values[0], values[1]);
                case 3:
                    return new Point3(values[0], values[1], values[2]);
                default:
                    return null;
            }
        }
        public static Point operator +(Point A, Point B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Add);
        }
        public static Point operator -(Point A, Point B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Subtract);
        }
        public static Point operator *(Point A, Point B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Multiply);
        }
        public static Point operator /(Point A, Point B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Divide);
        }
    }

    public class Point1 : Point
    {
        public decimal X
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }

        public Point1(decimal x) : base(1)
        {
            X = x;
        }
    }
    public class Point2 : Point
    {
        public decimal X
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }
        public decimal Y
        {
            get { return GetValueAtDimensionOrZero(1); }
            set { SetValueAtDimension(1, value); }
        }
        public Point2(decimal x, decimal y) : base(2)
        {
            X = x;
            Y = y;
        }
    }
    public class Point3 : Point
    {
        public decimal X
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }
        public decimal Y
        {
            get { return GetValueAtDimensionOrZero(1); }
            set { SetValueAtDimension(1, value); }
        }
        public decimal Z
        {
            get { return GetValueAtDimensionOrZero(1); }
            set { SetValueAtDimension(1, value); }
        }
        public Point3(decimal x, decimal y, decimal z) : base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public abstract class Vector : Point
    {
        private enum OperatorTypes
        {
            Add,
            Subtract,
            Multiply,
            Divide,
        }

        protected Vector(int numberDimensions) : base(numberDimensions)
        {
        }

        private static Vector OperatorGeneric(Vector A, Vector B, OperatorTypes Operator)
        {
            int numberOfDimensions = (A.NumberOfDimensions < B.NumberOfDimensions) ? A.NumberOfDimensions : B.NumberOfDimensions;
            var values = new List<decimal>();
            for (var i = 0; i < numberOfDimensions; i++)
            {
                switch (Operator)
                {
                    case OperatorTypes.Add:
                        values.Add((A.GetValueAtDimensionOrZero(i) + B.GetValueAtDimensionOrZero(i)));
                        continue;
                    case OperatorTypes.Subtract:
                        values.Add((A.GetValueAtDimensionOrZero(i) - B.GetValueAtDimensionOrZero(i)));
                        continue;
                    case OperatorTypes.Multiply:
                        values.Add((A.GetValueAtDimensionOrZero(i) * B.GetValueAtDimensionOrZero(i)));
                        continue;
                    case OperatorTypes.Divide:
                        values.Add((A.GetValueAtDimensionOrZero(i) / B.GetValueAtDimensionOrZero(i)));
                        continue;
                    default:
                        throw new ArgumentException("Operator Invalid.");
                }
            }
            switch (numberOfDimensions)
            {
                case 1:
                    return new Vector1(values[0]);
                case 2:
                    return new Vector2(values[0], values[1]);
                case 3:
                    return new Vector3(values[0], values[1], values[2]);
                default:
                    return null;
            }
        }
        public static Vector operator +(Vector A, Vector B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Add);
        }
        public static Vector operator -(Vector A, Vector B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Subtract);
        }
        public static Vector operator *(Vector A, Vector B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Multiply);
        }
        public static Vector operator /(Vector A, Vector B)
        {
            return OperatorGeneric(A, B, OperatorTypes.Divide);
        }
    }

    public class Vector1 : Vector
    {
        public decimal X
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }
        public Vector1(decimal x) : base(1)
        {
            X = x;
        }
    }
    public class Vector2 : Vector
    {
        public decimal X
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }
        public decimal Y
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }
        public Vector2(decimal x, decimal y) : base(2)
        {
            X = x;
            Y = y;
        }
    }
    public class Vector3 : Vector
    {
        public decimal X
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }
        public decimal Y
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }
        public decimal Z
        {
            get { return GetValueAtDimensionOrZero(0); }
            set { SetValueAtDimension(0, value); }
        }

        public Vector3(decimal x, decimal y, decimal z) : base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 CrossProduct(Vector3 A, Vector3 B)
        {
            return new Vector3(0,0,0)
            {
                X = A.Y*B.Z - A.Z*B.Y,
                Y = A.Z*B.X - A.X*B.Z,
                Z = A.X*B.Y - A.Y*B.X
            };
        }
    }
}
