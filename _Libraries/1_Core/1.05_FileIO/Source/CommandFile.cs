using System;
using System.Collections.Generic;
using System.Linq;
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

	    public new List<ICommandFileLine> Contents { get; set; } = new List<ICommandFileLine>();

		public new bool Load()
        {
            base.Load();
	        Contents.Clear();
            foreach (var thisLine in base.Contents)
            {
                var thisLinePrepared = string.Join(" ", thisLine.SplitPresevingQuotes());
	            Contents.Add(new Line(thisLinePrepared));
            }
            return true;
        }
        public new bool Save()
        {
	        base.Contents = Contents.Select(x => x.ToString()).ToArray();
			return base.Save();
        }
	}

	public static class StringExtensions
	{
		/// <summary>
		/// Splits a string by its spaces, preserving any parts of the string held in quotation marks.
		/// </summary>
		/// <param name="input">A string with spaces in it that needs to be split into an array.</param>
		/// <returns>Array of strings.</returns>
		public static string[] SplitPresevingQuotes(this string input)
		{
			var cleanstr = input
				.Replace("\t", "    ")
				.Replace("\r", "")
				.Replace('\u2013', '-')
				.Replace('\u2014', '-')
				.Replace('\u2015', '-')
				.Replace('\u2017', '_')
				.Replace('\u2018', '\'')
				.Replace('\u2019', '\'')
				.Replace('\u201a', ',')
				.Replace('\u201b', '\'')
				.Replace('\u201c', '\"')
				.Replace('\u201d', '\"')
				.Replace('\u201e', '\"')
				.Replace("\u2026", "...")
				.Replace('\u2032', '\'')
				.Replace('\u2033', '\"');
			while (cleanstr.Contains("  ")) cleanstr = cleanstr.Replace("  ", " ");
			if (cleanstr.Count(x => x == '\"') == 1) cleanstr = cleanstr.Replace("\"", "");
			var result = cleanstr.Split('"')
				.Select((element, index) => index % 2 == 0  // If even index
					? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
					: new[] { element })  // Keep the entire item
				.SelectMany(element => element).ToArray();
			return result;
		}
	}
}
