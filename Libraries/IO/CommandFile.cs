using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.IO;

namespace Com.OfficerFlake.Libraries.IO
{
    public abstract class CommandFile : IO.IOFile, ILoadable, ISaveable
    {
        protected CommandFile(string filename) : base(filename)
        {
        }

        public class Line
        {
            private string _line;
            private string[] Elements => _line.SplitPresevingQuotes();

            internal Line(string line)
            {
                _line = line;
            }
	        public string RawLine => _line;

            public string Command
            {
                get => (NumberOfElements > 0) ? Elements[0].ToUpperInvariant() : "";
				internal set
				{
	                if (NumberOfElements > 0)
	                {
		                _line = value.ToUpperInvariant() + " " + string.Join(" ", Elements.Skip(1));
	                }
	                else
	                {
		                _line = value.ToUpperInvariant();
	                }
				}
            }
	        public string[] Parameters
	        {
				get => (NumberOfElements > 1) ? Elements.Skip(1).ToArray() : new string[0];
		        internal set =>
					_line =
					
					Command + " " +
					string.Join(" ", 
						value.Select(x=>x.ToUpperInvariant())
						);
	        }	  

            public int NumberOfElements => Elements.Length;
	        public int NumberOfParameters => Parameters.Length;

            public string GetElementOrNull(int index)
            {
	            try
	            {
		            if (index >= Elements.Length || index < 0) return null;
		            return Elements[index];
	            }
	            catch
	            {
		            return null;
	            }
            }
            public object GetParameterOrNull(int index)
            {
	            try
	            {
		            if (index >= Parameters.Length || index < 0) return null;
		            return Parameters[index] ?? "";
	            }
	            catch
	            {
		            return null;
	            }
            }

	        public bool SetCommand(string value)
	        {
		        Command = value;
		        return true;
	        }
            public bool SetParameter(int index, string value)
            {
	            if (index < 0) return false;

				#region Initialise Variables
				int newSize = (index > NumberOfParameters - 1) ? (index + 1) : NumberOfParameters;
				string[] replacement = new string[newSize];
				#endregion

				#region Build New List
				for (int i = 0; i < replacement.Length; i++)
		            replacement[i] = "\"\"";
				#endregion
				#region Fill New List from Old List
				for (int i = 0; i < NumberOfParameters - 1; i++)
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
        public readonly List<Line> Lines = new List<Line>();

	    public string[] RawLines => Lines.Select(x=>x.RawLine).ToArray();
        
        public bool Load()
        {
            var loadedLines = ReadLines();
            Lines.Clear();
            foreach (var thisLine in loadedLines)
            {
                var thisLinePrepared = string.Join(" ", thisLine.SplitPresevingQuotes());
                Lines.Add(new Line(thisLinePrepared));
            }
            return true;
        }
        public bool Save()
        {
            var lines = Lines.Select(x => x.ToString()).ToArray();
            return Overwrite(lines);
        }
    }
}
