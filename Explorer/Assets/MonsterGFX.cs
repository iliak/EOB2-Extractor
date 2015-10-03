using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class MonsterGFX
	{
		public MonsterGFX()
		{
			used = false;

		}


		public bool used;

		public byte LoadProg;

		public byte unk0;

		public byte unk1;

		public string label;		// for .cps and .dcr files
	}
}
