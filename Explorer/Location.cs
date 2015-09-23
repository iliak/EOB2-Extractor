using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	public class Location
	{
		/// <summary>
		/// 
		/// </summary>
		public Location()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="Y"></param>
		public Location(ushort x, ushort y)
		{
			X = x;
			Y = y;
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		public Location(BinaryReader reader)
		{
			ushort tmp = reader.ReadUInt16();
			X = (ushort)(tmp & 0x1F);
			Y = (ushort)((tmp / 32) & 0x1f);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0}:{1}", X, Y);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		ushort X;

		/// <summary>
		/// 
		/// </summary>
		ushort Y;

		#endregion
	}
}
