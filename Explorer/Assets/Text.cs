using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class Text
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="basedir"></param>
		/// <returns></returns>
		public static List<string> Decode(string basedir)
		{
			List<string> msg = new List<string>();

			StringBuilder sb = new StringBuilder();

			string filename = Path.Combine(basedir, "TEXT.DAT");
			using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{
				// Start offset of the strings
				ushort limit = reader.ReadUInt16();

				for (ushort pos = 0; pos < limit; pos += 2)
				{
					reader.BaseStream.Position = pos;

					ushort offset = reader.ReadUInt16();

					reader.BaseStream.Position = offset;

					// Read until \0 is found !
					sb.Clear();
					byte c;
					while ((c = reader.ReadByte()) != 0)
					{
						sb.Append((char)c);
					}

					// Add message to the list
					msg.Add(sb.ToString());
				}

			}

			return msg;
		}



	}
}
