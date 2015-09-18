using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace INF
{
	public class Header
	{
		/// <summary>
		/// 
		/// </summary>
		public Header()
		{
			Doors = new DoorInfo[] { new DoorInfo(), new DoorInfo() };
			MonsterGFX = new MonsterGFX[] { new MonsterGFX(), new MonsterGFX()};
			MonsterTypes = new Queue<MonsterType>(30);
			Decorations = new Queue<DecorationInfo>();
		}


		/// <summary>
		/// 
		/// </summary>
		public string mazeName;

		/// <summary>
		/// 
		/// </summary>
		public string vmpVcnName;

		/// <summary>
		/// 
		/// </summary>
		public string paletteName;

		/// <summary>
		/// 
		/// </summary>
		public string SoundName;


		/// <summary>
		/// 
		/// </summary>
		public DoorInfo[] Doors;

		/// <summary>
		/// 
		/// </summary>
		public MonsterGFX[] MonsterGFX;

		/// <summary>
		/// 
		/// </summary>
		public Queue<MonsterType> MonsterTypes;

		/// <summary>
		/// 
		/// </summary>
		public Queue<DecorationInfo> Decorations;


		/// <summary>
		/// 
		/// </summary>
		public ushort NextHunk;
	}



}
