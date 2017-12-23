using System.Collections.Generic;
using System.Linq;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.Interfaces;

namespace Com.OfficerFlake.Libraries.IO
{
    public abstract class CommandFile : File, ICommandFile
    {
	    protected CommandFile(string filename) : base(filename)
        {
        }

        public class Line : ICommandFileLine
        {
            private string _line;
	        public string RawLine => _line;

			private string[] Elements => _line.SplitPresevingQuotes();

            public Line(string line)
            {
                _line = line;
            }

            public string Command
			{
                get => (Elements.Length > 0) ? Elements[0].ToUpperInvariant() : "";
				set
				{
	                if (Elements.Length > 0)
	                {
		                _line = value.ToUpperInvariant() + " " + string.Join(" ", Elements.Skip(1));
	                }
	                else
	                {
		                _line = value.ToUpperInvariant();
	                }
				}
            }
	        private string[] Parameters
			{
				get => (Elements.Length > 1) ? Elements.Skip(1).ToArray() : new string[0];
		        set =>
					_line =
					
					Command + " " +
					string.Join(" ", 
						value.Select(x=>x.ToUpperInvariant())
						);
	        }

	        public int NumberOfParameters => Parameters.Length;
			public string GetParameter(int index)
            {
	            try
	            {
		            if (index >= Parameters.Length || index < 0) return null;
		            return Parameters[index] ?? "";
	            }
	            catch
	            {
		            return "";
	            }
            }
            public bool SetParameter(int index, string value)
            {
	            if (index < 0) return false;

				#region Initialise Variables
				int newSize = (index > Parameters.Length - 1) ? (index + 1) : Parameters.Length;
				string[] replacement = new string[newSize];
				#endregion

				#region Build New List
				for (int i = 0; i < replacement.Length; i++)
		            replacement[i] = "\"\"";
				#endregion
				#region Fill New List from Old List
				for (int i = 0; i < Parameters.Length - 1; i++)
					replacement[i] = Parameters[i];
				#endregion

	            replacement[index] = value;

				#region Update Parameters
	            Parameters = replacement;
				#endregion
	            return true;
            }

            public override string ToString()
            {
                return string.Join(" ", Elements);
            }
		}
        public readonly List<ICommandFileLine> Lines = new List<ICommandFileLine>();

		List<ICommandFileLine> ICommandFile.Lines { get; set; } = new List<ICommandFileLine>();

		public new bool Load()
        {
            base.Load();
            Lines.Clear();
            foreach (var thisLine in Contents)
            {
                var thisLinePrepared = string.Join(" ", thisLine.SplitPresevingQuotes());
                Lines.Add(new Line(thisLinePrepared));
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
