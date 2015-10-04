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
	public class MazeBlock
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static  MazeBlock FromFile(BinaryReader reader)
		{
			MazeBlock block = new MazeBlock();

			block.North = reader.ReadByte();
			block.East = reader.ReadByte();
			block.South = reader.ReadByte();
			block.West = reader.ReadByte();

			return block;
		}


		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}", North, East, South, West);
		}
		#region Properties

		byte North;
		byte South;
		byte West;
		byte East;

		#endregion
	}
}
