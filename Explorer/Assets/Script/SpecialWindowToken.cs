using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	class SpecialWindowToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public SpecialWindowToken(Script script) : base(script)
		{
			Unknown = script.ReadAddr();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Special Window (0x{0:X4})...", Unknown);
		}

		#region Properties

		ushort Unknown;

		#endregion
		// Level 05 : 0x0003 (trigger: 24 @01x02 offset: 0x072C => Select a member to resurect) 
		// Level 07 : 0x0000 (trigger: 02@x17x05 offset: 0x011B =>)
		//		      0x0004 (trigger: 94 @20x03 offset: 0x16CD => Add hero to the party)
		// Level 09 : 0x0006 (trigger: 30 @19x25 offset: 0x0119 =>)
		// Level 11 : 0x0001 (trigger: 07 @10x29 offset: 0x08EC => Select a member ?)
		//			  0x0002 
		// Level 12 : 0x0000 (trigger: 28 @05x21 offset: 0x0D00 => )
		// Level 14 : 0x0006 (trigger: 32 @15x09 offset: 0x15bb => )
		// Level 15 : 0x0005 (trigger: 67 @21x12 offset: 0x1092 => )
		//
	}

	public enum SpecialWindowFlag
	{
		A = 0x0,
		B = 0x1,
		C = 0x2,
		FindDeadMember = 0x3,			// Display dead members
		E = 0x4,
		F = 0x5,
		G = 0x6,
	}
}
