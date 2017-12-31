using Com.OfficerFlake.Libraries.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OfficerFlake.Libraries.Extensions
{
	public static class SimpleColors
	{
		#region Colors

		public static ISimpleColor Black => Color0;

		public static readonly ISimpleColor Color0 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(0, 0, 0), '0');

		public static ISimpleColor DarkBlue => Color1;

		public static readonly ISimpleColor Color1 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(0, 0, 170), '1');

		public static ISimpleColor DarkGreen => Color2;

		public static readonly ISimpleColor Color2 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(0, 170, 0), '2');

		public static ISimpleColor DarkTeal => Color3;

		public static readonly ISimpleColor Color3 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(0, 170, 170), '3');

		public static ISimpleColor DarkRed => Color4;

		public static readonly ISimpleColor Color4 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(170, 0, 0), '4');

		public static ISimpleColor DarkPurple => Color5;

		public static readonly ISimpleColor Color5 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(170, 0, 170), '5');

		public static ISimpleColor DarkYellow => Color6;

		public static readonly ISimpleColor Color6 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(0, 170, 0), '6');

		public static ISimpleColor Gray => Color7;

		public static readonly ISimpleColor Color7 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(170, 170, 170), '7');

		public static ISimpleColor DarkGray => Color8;

		public static readonly ISimpleColor Color8 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(85, 85, 85), '8');

		public static ISimpleColor Blue => Color9;

		public static readonly ISimpleColor Color9 = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(85, 85, 255), '9');

		public static ISimpleColor Green => ColorA;

		public static readonly ISimpleColor ColorA = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(85, 255, 85), 'A');

		public static ISimpleColor Teal => ColorB;

		public static readonly ISimpleColor ColorB = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(85, 255, 255), 'B');

		public static ISimpleColor Red => ColorC;

		public static readonly ISimpleColor ColorC = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(255, 85, 85), 'C');

		public static ISimpleColor Purple => ColorD;

		public static readonly ISimpleColor ColorD = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(255, 85, 255), 'D');

		public static ISimpleColor Yellow => ColorE;

		public static readonly ISimpleColor ColorE = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(255, 255, 85), 'E');

		public static ISimpleColor White => ColorF;

		public static readonly ISimpleColor ColorF = ObjectFactory.CreateSimpleColor(
			ObjectFactory.CreateColor(255, 255, 255), 'F');

		public static readonly List<ISimpleColor> List = new List<ISimpleColor>()
		{
			Color0,
			Color1,
			Color2,
			Color3,
			Color4,
			Color5,
			Color6,
			Color7,
			Color8,
			Color9,
			ColorA,
			ColorB,
			ColorC,
			ColorD,
			ColorE,
			ColorF
		};

		#endregion
	}

	//[EditorBrowsable(EditorBrowsableState.Never)]
	public static class SimpleColorExtensions
	{
		#region Extensions
		public static System.Drawing.Color ToSystemDrawingColor(this ISimpleColor simpleColor)
		{
			return System.Drawing.Color.FromArgb(
				255,
				simpleColor.Color.Red,
				simpleColor.Color.Green,
				simpleColor.Color.Blue);
		}
		#endregion
	}
}
