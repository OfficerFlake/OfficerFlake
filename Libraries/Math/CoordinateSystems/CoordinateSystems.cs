﻿using System;
using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.Math.CoordinateSystems
{
    public class Point1 : IPoint1
    {
        public IDistance X
        {
            get ;
            set ;
        }

        public Point1(IDistance x)
        {
            X = x;
        }
    }
	public class Point2 : IPoint2
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

		public Point2(IDistance x, IDistance y)
		{
			X = x;
			Y = y;
		}
	}
	public class Point3 : IPoint3
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

		public Point3(IDistance x, IDistance y, IDistance z)
		{
			X = x;
			Y = y;
			Z = z;
		}
	}

	public class Vector1 : IVector1
	{
		public IDistance X
		{
			get;
			set;
		}

		public Vector1(IDistance x)
		{
			X = x;
		}
	}
	public class Vector2 : IVector2
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

		public Vector2(IDistance x, IDistance y)
		{
			X = x;
			Y = y;
		}
	}
	public class Vector3 : IVector3
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

		public Vector3(IDistance x, IDistance y, IDistance z)
		{
			X = x;
			Y = y;
			Z = z;
		}
	}

	public class Orientation1 : IOrientation1
	{
		public IAngle H
		{
			get;
			set;
		}

		public Orientation1(IAngle h)
		{
			H = h;
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
	}
}
