using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class ScreenMenuToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ScreenMenuToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			switch (Type)
			{
				// Display a picture from a CPS file
				case 0xd3:
				{
					PictureName = script.ReadString(13);
					X = script.ReadShort();
					Y = script.ReadShort();
					unk0 = script.ReadByte();
					unk1 = script.ReadByte();
					unk2 = script.ReadByte();
				}
				break;

				case 0xd4:
				{

				}
				break;

				//Display background ?
				case 0xd5:
				{

				}
				break;

				// Fade in 
				case 0xd6:
				{

				}
				break;

				// Button texts ?
				case 0xd8:
				{
					X = script.ReadShort();
					Y = script.ReadShort();
					unk0 = script.ReadByte();
					unk1 = script.ReadByte();
					unk2 = script.ReadByte();
				}
				break;

				case 0xf8:
				{
					X = script.ReadByte();
					Y = script.ReadByte();
					unk0 = script.ReadByte();
					unk1 = script.ReadByte();
				}
				break;

				default:
				{

				}
				break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Screen menu 0x{0:X2} (\"{1}\", X: {2}, Y: {3}, 0x{4:X2}, 0x{5:X2}, 0x{6:X2}, 0x{7:X2})", Type, PictureName, X * 8, Y, unk0, unk1, unk2, unk3);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		byte Type;


		/// <summary>
		/// 
		/// </summary>
		string PictureName;


		ushort X;
		ushort Y;
		//ushort Width;
		//ushort Height;
		byte unk0;
		byte unk1;
		byte unk2;
		byte unk3;

		#endregion
	}
}
