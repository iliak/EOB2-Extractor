using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	public class DecorationFileName
	{
		/// <summary>
		/// Points to a .cps file containg wall graphics data
		/// </summary>
		public string GFXName;


		/// <summary>
		/// Points to a .dat file containing rectangular data that point into the graphics data.
		/// </summary>
		public string DECName;
	}
}
