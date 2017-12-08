using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;
using Com.OfficerFlake.Libraries.IO;

namespace Com.OfficerFlake.Libraries.YSFlight.Files
{
    public abstract class CommandFile : IO.File, ILoadable, ISaveable
    {
        protected CommandFile(string filename) : base(filename)
        {
        }

        public class Line
        {
            private string _line;
            private string[] Elements => _line.ToUpperInvariant().SplitPresevingQuotes();

            public Line(string line)
            {
                _line = line;
            }

            public string Command
            {
                get => (NumberOfElements > 0) ? Elements[0] : "";
                set
                {
	                if (NumberOfElements > 0)
	                {
		                _line = value + " " + string.Join(" ", Elements.Skip(1));
	                }
	                else
	                {
		                _line = value;
	                }
				}
            }
	        public string[] Parameters
	        {
				get => (NumberOfElements > 1) ? Elements.Skip(1).ToArray() : new string[0];
				set => _line = Command + " " + string.Join(" ", value);
	        }	  

            public int NumberOfElements => Elements.Length;
            public int NumberOfParameters
			{
	            get => Parameters.Length;
	            set
	            {
		            if (NumberOfElements >= value)
		            {
			            _line = string.Join(" ", Elements.Take(value));
			            return;
		            }

					string temp = string.Join(" ", Elements);
					int remainder = value-NumberOfElements;
		            for (int i = 0; i < remainder; i++)
		            {
			            temp += " " + "\"\"";
		            }
		            _line = temp;
	            }
			}

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

            public bool SetParameter(int index, string value)
            {
	            if (index < 0) return false;
	            if (NumberOfParameters < index)
	            {
		            
	            }

				//TODO: Fix this, it's clearly wrong... (PRIOTITY=0)

				//If Index is too high?
				if (index < 0) index = NumberOfParameters + (index % NumberOfParameters);

                var sb = new StringBuilder();
                sb.Append(Command);

				//count to index position.
                for(var i = 0; i < NumberOfParameters; i++)
                {
                    sb.Append(" ");
                    sb.Append(GetParameterOrNull(i) ?? "\"\"");
                }

				//Set parameter

				//count from index+1 to end.
                for (var i = 0; i < index - NumberOfParameters; i++)
                {
                    sb.Append(" \"\"");
                }

				//What in the living fuck is this recursive bullshit!?
                if (NumberOfParameters < index)
                {
                    _line = sb.ToString();
                    SetParameter(index, value);
                }
                _line = sb.ToString();


                return true;
            }

            public override string ToString()
            {
                return string.Join(" ", Elements);
            }
        }
        protected readonly List<Line> Lines = new List<Line>();
        
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
