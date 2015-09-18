using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF
{
	public class WallMapping
	{

		public byte index;              // This is the index used by the .maz file
		public byte WallType;           // Index to what backdrop wall type that is being used
		public byte DecorationID;       // Index to an optional overlay decoration image in the DecorationData.decorations array in the [[eob.dat |.dat]] files
		//public byte FileIndex;
		public byte unk0;
		public byte unk1;
	}
}
