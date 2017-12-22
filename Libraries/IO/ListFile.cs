using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.IO
{
	public class ListFile : File, Com.OfficerFlake.Libraries.Interfaces.IListFile
	{
		public List<IListFileLine> Lines { get; set; }

		protected ListFile(string filename) : base(filename)
        {
        }

		public class Line : IListFileLine
		{
			private List<string> Contents = new List<string>();

			public Line(string[] contents)
			{
				Contents = contents.ToList();
			}

			public int NumberOfParameters => Contents.Count;

			public string GetParameter(int index)
			{
				if (index > Contents.Count) return "";
				return Contents[index];
			}
			public void SetParameter(int index, string value)
			{
				while (index > Contents.Count) Contents.Add("");
				Contents[index] = value;
			}

			public override string ToString()
			{
				return string.Join(" ", Contents);
			}
		}

		public new bool Load()
        {
            base.Load();
            Lines.Clear();
            foreach (var thisLine in Contents)
            {
	            var contents = thisLine.SplitPresevingQuotes();
	            Lines.Add(new Line(contents));
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
