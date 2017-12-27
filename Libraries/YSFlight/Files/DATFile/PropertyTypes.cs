using System.Text;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
	public interface IDAT_Parameters
	{
		object[] Parameters { get; set; }
		string ToString();
	}
	public interface IDAT_0_Parameters : IDAT_Parameters
	{
	}
	public interface IDAT_1_Parameter<T1> : IDAT_Parameters
	{
		T1 Value { get; set; }
	}
	public interface IDAT_2_Parameters<T1, T2> : IDAT_Parameters
	{
		T1 Value1 { get; set; }
		T2 Value2 { get; set; }

	}
	public interface IDAT_3_Parameters<T1, T2, T3> : IDAT_Parameters
	{
		T1 Value1 { get; set; }
		T2 Value2 { get; set; }
		T3 Value3 { get; set; }
	}
	public interface IDAT_4_Parameters<T1, T2, T3, T4> : IDAT_Parameters
	{
		T1 Value1 { get; set; }
		T2 Value2 { get; set; }
		T3 Value3 { get; set; }
		T4 Value4 { get; set; }
	}
	public interface IDAT_5_Parameters<T1, T2, T3, T4, T5> : IDAT_Parameters
	{
		T1 Value1 { get; set; }
		T2 Value2 { get; set; }
		T3 Value3 { get; set; }
		T4 Value4 { get; set; }
		T5 Value5 { get; set; }
	}
	public interface IDAT_6_Parameters<T1, T2, T3, T4, T5, T6> : IDAT_Parameters
	{
		T1 Value1 { get; set; }
		T2 Value2 { get; set; }
		T3 Value3 { get; set; }
		T4 Value4 { get; set; }
		T5 Value5 { get; set; }
		T6 Value6 { get; set; }
	}
	public interface IDAT_7_Parameters<T1, T2, T3, T4, T5, T6, T7> : IDAT_Parameters
	{
		T1 Value1 { get; set; }
		T2 Value2 { get; set; }
		T3 Value3 { get; set; }
		T4 Value4 { get; set; }
		T5 Value5 { get; set; }
		T6 Value6 { get; set; }
		T7 Value7 { get; set; }
	}
	public interface IDAT_8_Parameters<T1, T2, T3, T4, T5, T6, T7, T8> : IDAT_Parameters
	{
		T1 Value1 { get; set; }
		T2 Value2 { get; set; }
		T3 Value3 { get; set; }
		T4 Value4 { get; set; }
		T5 Value5 { get; set; }
		T6 Value6 { get; set; }
		T7 Value7 { get; set; }
		T8 Value8 { get; set; }
	}

	public class DATProperty : CommandFile.Line, IDAT_Parameters
	{
		private object[] _parameters;
		public object[] Parameters
		{
			get => _parameters;
			set
			{
				for(int i=0; i<value.Length; i++)
				{
					object thisObject = value[i];
					base.SetParameter(i, thisObject.ToString());
				}
				_parameters = value;
			}
		}

		public DATProperty(string line) : base(line)
		{
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Command);
			foreach (object thisObject in Parameters)
			{
				sb.Append(" ");
				sb.Append(thisObject.ToString());
			}
			return sb.ToString();
		}
	}
}
