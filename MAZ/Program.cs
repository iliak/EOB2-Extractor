using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace MAZ
{
	class Program
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			byte b;
			ushort s;
			uint l;


			Maze = new Maze();
			Maze.Load(@"c:\eob2-uncps\LEVEL4.MAZ");


		}


		#region Properties


		/// <summary>
		/// 
		/// </summary>
		static public Maze Maze;

		#endregion
	}


}


