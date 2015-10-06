using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class NewItemToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public NewItemToken(Script script) : base(script)
		{
			ItemID = script.ReadAddr();
			Type = script.ReadAddr();
			switch (Type)
			{
				case 0xffff:
				{
					Unknown0 = script.ReadByte();
					Unknown1 = script.ReadByte();
				}
				break;

				case 0xfffe:
				{
					Unknown0 = script.ReadByte();
					Unknown1 = script.ReadByte();
					Unknown2 = script.ReadByte();
				}
				break;

				default:
				{
					Target = Location.FromValue(Type);
					SubPos = script.ReadByte();
					Unknown0 = script.ReadByte();
				}
				break;
			}

			Item item = Assets.Items[ItemID];
			if (item != null)
				ItemName = item.UnidentifiedName;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			switch(Type)
			{
				case 0xffff:
				{
					return string.Format("New item \"{0}\" (unknown: [0x{1:X2}:0x{2:X2}])", ItemName, Unknown0, Unknown1);
				}

				case 0xfffe:
                {
					return string.Format("New item \"{0}\" (unknown: [0x{1:X2}:0x{2:X2}:0x{3:X2}])", ItemName, Unknown0, Unknown1, Unknown2);
				}

				default:
				{
					return string.Format("New item \"{0}\" at {1}:{2} (unknown: [0x{3:X2}])", ItemName, Target, SubPos, Unknown0);
				}
			}
		}


		#region Properties

		ushort Type;
		ushort ItemID;
		Location Target;
		byte SubPos;
		byte Unknown0;
		byte Unknown1;
		byte Unknown2;

		string ItemName;
		#endregion
	}
}
