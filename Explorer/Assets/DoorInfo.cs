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
		public DoorInfo()
		{
			DoorRectangle = new Rectangle[] { new Rectangle(), new Rectangle(), new Rectangle() };
			ButtonRectangles = new Rectangle[] { new Rectangle(), new Rectangle() };
			ButtonPositions = new Point[] { new Point(), new Point() };

		}
		public byte Command;

		public byte idx;

		public byte type;

		public byte knob;

		public string gfxfile;

		public Rectangle[] DoorRectangle; // rectangles in door?.cps size [3]

		public Rectangle[] ButtonRectangles; // rectangles in door?.cps size [2]

		public Point[] ButtonPositions; // x y position where to place door button size [2,2]
	}
}
