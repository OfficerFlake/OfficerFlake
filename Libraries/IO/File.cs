using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Com.OfficerFlake.Libraries.Extensions;

namespace Com.OfficerFlake.Libraries.IO
{
    public class IOFile : IReadable, IWriteable, IEraseable
    {
        private bool DebugMode = false;
        public string Filename { get; }
	    internal string[] FileContents = new string[0];

        public IOFile(string filename)
        {
            switch (filename)
            {
                case null:
                    throw new ArgumentException("filename is null");
                case "":
                    throw new ArgumentException("filename is empty");
                default:
                    this.Filename = filename;
                    break;
            }
        }

        #region Read

	    public Encoding GetEncoding()
	    {
			// Read the BOM
		    var bom = new byte[4];
		    using (var file = new FileStream(Filename, FileMode.Open, FileAccess.Read))
		    {
			    file.Read(bom, 0, 4);
		    }

		    // Analyze the BOM
		    if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
		    if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
		    if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
		    if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
		    if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
		    return Encoding.ASCII;
		}

		/// <summary>
		/// Will try to read all the bytes from the file, or will return null if it fails.
		/// </summary>
		/// <returns>Byte array or null.</returns>
        private byte[] TryToReadAllBytesFromFileOrReturnNull()
        {
            if (DebugMode) Debug.WriteLine("Now Loading: " + Filename);
            try
            {
                using (var streamReader = new StreamReader(Filename))
                {
					return streamReader.ReadToEnd().ToByteArray();
                }
            }
            catch (Exception e)
            {
                if (DebugMode) Debug.WriteLine(e);
                return null;
            }
        }

		/// <summary>
		/// Will try to read all the bytes from the file, or will return null if it fails.
		/// </summary>
		/// <returns>Byte array or null.</returns>
        public byte[] ReadAll()
        {
            return TryToReadAllBytesFromFileOrReturnNull();
        }

		/// <summary>
		/// Will try to read all the bytes from the file, and if successful, will spit the data out as an array of strings for each line. Otherwise null.
		/// </summary>
		/// <returns>Each line  of the file as an array of strings, otherwise null</returns>
        protected string[] ReadLines()
        {
            var bytes = ((IReadable)this).ReadAll();
			FileContents = (bytes ?? new byte[0]).ToSystemString().Replace("\r","").Split('\n');
	        return FileContents;
        }
        #endregion
        #region Write
	    /// <summary>
	    /// Tries to write or append the bytes to the file. return true if successful, otherwise returns false.
	    /// </summary>
	    /// <param name="input">Bytes to write or append.</param>
	    /// <param name="append">Append to file? Default true (to save your data...)</param>
	    private bool TryToWriteBytesToFileOrThrowException(byte[] input, bool append = true)
        {
            try
            {
                using (var streamWriter = new StreamWriter(Filename, append))
                {
					streamWriter.Write(input.ToString().Replace("\r", ""));
                }
	            return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
	            return false;
            }
        }

		/// <summary>
		/// Tries to write the bytes to the file, appending if the file already contains data. Returns true if successful.
		/// </summary>
		/// <param name="input">Bytes to write to file.</param>
		/// <returns>True if successful.</returns>
        public bool Write(byte[] input)
        {
            try
            {
                TryToWriteBytesToFileOrThrowException(input, false);
                return true;
            }
            catch
            {
                return false;
            }
        }

		/// <summary>
		/// Tries to write the bytes to the file by overwriting if data already exists. Returns true if successful.
		/// </summary>
		/// <param name="input">Bytes to write to the file.</param>
		/// <returns>True if successful.</returns>
        protected bool Overwrite(byte[] input)
        {
            return Erase() && ((IWriteable)this).Write(input);
        }

		/// <summary>
		/// Tries to write the array of strings to the file, by overwriting if data already exists. Returns true if successful.
		/// </summary>
		/// <param name="input">Array of strings to write to file.</param>
		/// <returns>True if successful.</returns>
        protected bool Overwrite(string[] input)
        {
            return Erase() && ((IWriteable)this).Write(input.ToByteArray());
        }

		/// <summary>
		/// Tries to write the string to the file, by overwriting if data already exists. Returns true if successful.
		/// </summary>
		/// <param name="input">String to write to the file.</param>
		/// <returns>True if successful.</returns>
        protected bool Overwrite(string input)
        {
            return Erase() && ((IWriteable)this).Write(input.ToByteArray());
        }
        #endregion
        #region Erase
		/// <summary>
		/// Tries to erase the file if it exists. Returns true if no file, or succeeds.
		/// </summary>
		/// <returns>True is successful or no file to erase.</returns>
        private bool TryToEraseFile()
        {
            if (!System.IO.File.Exists(Filename)) return true;
            try
            {
                System.IO.File.Delete(Filename);
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e);
	            return false;
            }
        }

		/// <summary>
		/// Tries to erase the file file if it exists. Returns true if no file, or succeeds.
		/// </summary>
		/// <returns>True is successful or no file to erase.</returns>
		public bool Erase()
        {
            var startTime = DateTime.Now;
            const int timeout = 5000;
            while ((DateTime.Now - startTime).TotalMilliseconds < timeout)
            {
				return TryToEraseFile();
            }
            return false;
        }

        #endregion
    }
}
