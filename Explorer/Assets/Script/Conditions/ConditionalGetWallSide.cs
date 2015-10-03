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
	public class ConditionalGetWallSide : ConditionalBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalGetWallSide(Script script) : base(script)
		{
			Side = script.ReadByte();
			target = Location.FromScript(script);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Wall side {0} at {1}, ", Side, target);
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		byte Side;

		/// <summary>
		/// 
		/// </summary>
		public Location target;

		#endregion
	}
}
