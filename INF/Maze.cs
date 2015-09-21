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
			Triggers = new Queue<Trigger>();
			Messages = new List<string>();
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
		public Queue<Trigger> Triggers;

		/// <summary>
		/// 
		/// </summary>
		public List<string> Messages;

		/// <summary>
		/// 
		/// </summary>
		public Script Script;
	}
}
