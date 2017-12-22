using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.IO;

namespace Com.OfficerFlake.Libraries.IO
{
    public class ListFile : File, IListFile
	{
	    protected ListFile(string filename) : base(filename)
        {
        }

		public List<string> Lines = new List<string>();

		public new bool Load()
        {
            base.Load();
            Lines.Clear();
            foreach (var thisLine in Contents)
            {
                var thisLinePrepared = string.Join(" ", thisLine.SplitPresevingQuotes());
	            Lines.Add(thisLinePrepared);
            }
            return true;
        }
        public new bool Save()
        {
	        Contents = Lines.Select(x => x.ToString()).ToArray();
			return base.Save();
        }
    }
}
