using System;
using System.Collections;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;
using Com.OfficerFlake.Libraries.UnitsOfMeasurement;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public static partial class PropertyTypes
    {
	    public interface DAT_0_Parameters
	    {
	    }
		public interface DAT_1_Parameter<T1>
	    {
		    T1 Value { get; set; }
	    }
	    public interface DAT_2_Parameters<T1, T2>
	    {
		    T1 Value1 { get; set; }
		    T2 Value2 { get; set; }

	    }
	    public interface DAT_3_Parameters<T1, T2, T3>
	    {
		    T1 Value1 { get; set; }
		    T2 Value2 { get; set; }
		    T3 Value3 { get; set; }
	    }
	    public interface DAT_4_Parameters<T1, T2, T3, T4>
	    {
		    T1 Value1 { get; set; }
		    T2 Value2 { get; set; }
		    T3 Value3 { get; set; }
		    T4 Value4 { get; set; }
	    }
	    public interface DAT_5_Parameters<T1, T2, T3, T4, T5>
	    {
		    T1 Value1 { get; set; }
		    T2 Value2 { get; set; }
		    T3 Value3 { get; set; }
		    T4 Value4 { get; set; }
		    T5 Value5 { get; set; }
	    }
	    public interface DAT_6_Parameters<T1, T2, T3, T4, T5, T6>
	    {
		    T1 Value1 { get; set; }
		    T2 Value2 { get; set; }
		    T3 Value3 { get; set; }
		    T4 Value4 { get; set; }
		    T5 Value5 { get; set; }
		    T6 Value6 { get; set; }
	    }
		public interface DAT_7_Parameters<T1, T2, T3, T4, T5, T6, T7>
	    {
		    T1 Value1 { get; set; }
		    T2 Value2 { get; set; }
		    T3 Value3 { get; set; }
		    T4 Value4 { get; set; }
		    T5 Value5 { get; set; }
		    T6 Value6 { get; set; }
		    T7 Value7 { get; set; }
	    }
		public interface DAT_8_Parameters<T1, T2, T3, T4, T5, T6, T7, T8>
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
	}