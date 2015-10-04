using System;
using System.Collections.Generic;
using System.Linq;
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
			X = 0xff;
			Y = 0xff;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Location(byte x, byte y)
		{
			X = x;
			Y = y;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		static public Location FromValue(ushort value)
		{
			return new Location((byte)(value & 0x1f), (byte)((value >> 5) & 0x1f));
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		static public Location FromScript(Script script)
		{
			ushort value = script.ReadAddr();
			//return new Point((byte)(pos & 0x1f), (byte)((pos >> 5) & 0x1f));
			return new Location((byte)(value & 0x1f), (byte)((value >> 5) & 0x1f));
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0:D2}x{1:D2}", X, Y);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool IsInvalid
		{
			get
			{
				return X == 0 && Y == 0;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public byte X;

		/// <summary>
		/// 
		/// </summary>
		public byte Y;

		#endregion
	}
}
