using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	/// <summary>
	/// http://eab.abime.net/showpost.php?p=533880&postcount=374
	/// http://eab.abime.net/showpost.php?p=579468&postcount=405
	/// </summary>
	public class DoorInfo
	{
		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public byte Command;

		/// <summary>
		/// 
		/// </summary>
		public byte Id;

		/// <summary>
		/// 
		/// </summary>
		public byte Type;

		/// <summary>
		/// 
		/// </summary>
		public byte knob;

		/// <summary>
		/// 
		/// </summary>
		public string GfxName;

		/// <summary>
		/// 
		/// </summary>
		public Rectangle[] DoorRectangle = new Rectangle[3]; // rectangles in door?.cps size [3]

		/// <summary>
		/// 
		/// </summary>
		public Rectangle[] ButtonRectangles = new Rectangle[2]; // rectangles in door?.cps size [2]

		/// <summary>
		/// 
		/// </summary>
		public Point[] ButtonPositions = new Point[2]; // x y position where to place door button size [2,2]

		#endregion
	}
}
