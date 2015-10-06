using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class Trigger
	{

		/// <summary>
		/// 
		/// </summary>
		public Location Location;

		/// <summary>
		/// 
		/// </summary>
		public TriggerFlag Flags;

		/// <summary>
		/// 
		/// </summary>
		public ushort Offset;


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0} => 0x{1:X4} Flag: {2}", Location, Offset, Flags.ToString());
		}
	}


	/// <summary>
	/// 
	/// </summary>
	[Flags]
	public enum TriggerFlag
	{
		A = 0x01,
		B = 0x02,
		C = 0x04,
		OnPartyEnter = 0x08,			// Confirmed
		D = 0x10,
		HoleOrPressure = 0x20,
		F = 0x40,
		G = 0x80,
		H = 0x100,
		I = 0x200,
		K = 0x400,
		OnClick = 0x800,
		M = 0x1000,
		N = 0x2000,
		O = 0x4000,
		P = 0x8000,
	}
	// item drop
	// item taken
	// party enter
	//party leave
}
