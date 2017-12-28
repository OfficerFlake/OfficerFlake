using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.IO
{
	public class ListFile : File, IListFile
	{
		public new List<IListFileLine> Contents { get; set; }

		protected ListFile(string filename) : base(filename)
        {
        }

		public class Line : IListFileLine
		{
			public List<string> Contents { get; set; }

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
            Contents.Clear();
            foreach (var thisLine in base.Contents)
            {
	            var contents = thisLine.SplitPresevingQuotes();
	            Contents.Add(new Line(contents));
            }
            return true;
        }
        public new bool Save()
        {
	        base.Contents = Contents.Select(x => x.ToString()).ToArray();
			return base.Save();
        }
    }
}
