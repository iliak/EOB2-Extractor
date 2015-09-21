using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace MAZ
{
	public class Maze
	{

		/// <summary>
		/// 
		/// </summary>
		public Maze()
		{
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public bool Load(string filename)
		{
			byte b;
			ushort s;

			using (Reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{
				Size = new Size(Reader.ReadUInt16(), Reader.ReadUInt16());
				Faces = Reader.ReadUInt16();
			}

			return true;
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		BinaryReader Reader;

		/// <summary>
		/// 
		/// </summary>
		public Size Size
		{
			get;
			private set;
		}

		/// <summary>
		/// Number of face per block
		/// </summary>
		public ushort Faces
		{
			get;
			private set;
		}


		#endregion
	}
}
