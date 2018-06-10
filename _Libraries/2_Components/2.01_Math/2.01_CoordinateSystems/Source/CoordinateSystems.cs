using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Math.CoordinateSystems
{
	public class Point2<T> : IPoint2<T>
	{
		public T X
		{
			get;
			set;
		}
		public T Y
		{
			get;
			set;
		}

		public Point2(T x, T y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ")";
		}
	}
	public class Point3<T> : IPoint3<T>
	{
		public T X
		{
			get;
			set;
		}
		public T Y
		{
			get;
			set;
		}
		public T Z
		{
			get;
			set;
		}

		public Point3(T x, T y, T z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ", " + Z + ")";
		}
	}
	public class Vector2<T> : IVector2<T>
	{
		public T X
		{
			get;
			set;
		}
		public T Y
		{
			get;
			set;
		}

		public Vector2(T x, T y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ")";
		}
	}
	public class Vector3<T> : IVector3<T>
{
		public T X
		{
			get;
			set;
		}
		public T Y
		{
			get;
			set;
		}
		public T Z
		{
			get;
			set;
		}

		public Vector3(T x, T y, T z)
		{
			X = x;
			Y = y;
			Z = z;
		}

	public override string ToString()
	{
		return "(" + X + ", " + Y + ", " + Z + ")";
	}
	}

	public class Coordinate2 : ICoordinate2
	{
		public IDistance X
		{
			get;
			set;
		}
		public IDistance Y
		{
			get;
			set;
		}

		public Coordinate2(IDistance x, IDistance y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ")";
		}
	}
	public class Coordinate3 : ICoordinate3
	{
		public IDistance X
		{
			get;
			set;
		}
		public IDistance Y
		{
			get;
			set;
		}
		public IDistance Z
		{
			get;
			set;
		}

		public Coordinate3(IDistance x, IDistance y, IDistance z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ", " + Z + ")";
		}
	}
	public class Orientation2 : IOrientation2
	{
		public IAngle H
		{
			get;
			set;
		}
		public IAngle P
		{
			get;
			set;
		}

		public Orientation2(IAngle h, IAngle p)
		{
			H = h;
			P = p;
		}

		public override string ToString()
		{
			return "(" + H + ", " + P + ")";
		}
	}
	public class Orientation3 : IOrientation3
	{
		public IAngle H
		{
			get;
			set;
		}
		public IAngle P
		{
			get;
			set;
		}
		public IAngle B
		{
			get;
			set;
		}

		public Orientation3(IAngle h, IAngle p, IAngle b)
		{
			H = h;
			P = p;
			B = b;
		}

		public override string ToString()
		{
			return "(" + H + ", " + P + ", " + B + ")";
		}
	}
}
