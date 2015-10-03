using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class MazeHeader
	{
		/// <summary>
		/// 
		/// </summary>
		public string MazeName;

		/// <summary>
		/// 
		/// </summary>
		public string VmpVcnName;

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
		public DoorInfo[] Doors = new DoorInfo[2];

		/// <summary>
		/// 
		/// </summary>
		public MonsterGFX[] MonsterGFX = new MonsterGFX[2];

		/// <summary>
		/// 
		/// </summary>
		public List<MonsterType> MonsterTypes = new List<MonsterType>();

		/// <summary>
		/// 
		/// </summary>
		public List<DecorationInfo> Decorations = new List<DecorationInfo>();


		/// <summary>
		/// 
		/// </summary>
		public ushort NextHunk;
	}



}
