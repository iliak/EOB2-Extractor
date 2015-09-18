using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF
{
	/// <summary>
	/// 
	/// </summary>
	public class Maze
	{
		/// <summary>
		/// 
		/// </summary>
		public Maze()
		{
			Headers = new Header[2];
			Timer = new Queue<byte>();
			Monsters = new Queue<Monster>();
			Hunks = new ushort[3];
			Specials = new Queue<MazeInfo>();
			Messages = new Queue<string>();
			Script = new Script();
		}

		/// <summary>
		/// 
		/// </summary>
		public Queue<byte> Timer;

		/// <summary>
		/// 
		/// </summary>
		public Queue<Monster> Monsters;

		/// <summary>
		/// 
		/// </summary>
		public Header[] Headers;

		/// <summary>
		/// 
		/// </summary>
		public ushort[] Hunks;

		/// <summary>
		/// 
		/// </summary>
		public Queue<MazeInfo> Specials;

		/// <summary>
		/// 
		/// </summary>
		public Queue<string> Messages;

		/// <summary>
		/// 
		/// </summary>
		public Script Script;
	}
}
