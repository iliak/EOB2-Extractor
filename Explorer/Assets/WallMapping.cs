using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	//Wall-Types: Who can pass 
	//#define WF_PASSNONE			0x00  Can be passed by no one 
	//#define WF_PARTYPASS			0x01  Can be passed by the player, big item 
	//#define WF_SMALLPASS			0x02  Can be passed by a small item 
	//#define WF_MONSTERPASS		0x04  Can be passed by a monster 
	//#define WF_PASSALL			0x07  Can be passed by all 
	//#define WF_ISDOOR				0x08  Is a door 
	//#define WF_DOOROPEN			0x10  The door is open 
	//#define WF_DOORCLOSED			0x20  The door is closed 
	//#define WF_DOORKNOB			0x40  The door has a knob 
	//#define WF_ONLYDEC			0x80  No wall, only decoration, items visi 


	//Wall-Types: Kind 
	//#define WT_SOLID				0x01  Is a solid wall, draw top 
	//#define WT_SELFDRAW			0x02  Is a stair, for example, no bottom 
	//#define WT_DOORSTUCK			0x04  The door is stuck 
	//#define WT_DOORMOVES			0x08  The door is opening 
	//#define WT_DOOROPEN			0x10  The door is open 
	//#define WT_DOORCLOSED			0x20  The door is closed  

	/// <summary>
	/// 
	/// </summary>
	public class WallMapping
	{

		public byte index;              // This is the index used by the .maz file
		public byte WallType;           // Index to what backdrop wall type that is being used
		public byte DecorationID;       // Index to an optional overlay decoration image in the DecorationData.decorations array in the [[eob.dat |.dat]] files
										//public byte FileIndex;
		public byte EventMask;
		public byte Flags;
	}
}
