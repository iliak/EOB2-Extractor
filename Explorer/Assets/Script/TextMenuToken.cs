using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class TextMenuToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public TextMenuToken(Script script) : base(script)
		{
			Type = script.ReadByte();
			switch (Type)
			{
				// Display a picture from a CPS file
				case 0xd3:
				{
					PictureName = script.ReadString(13);        // Name of the cps file
					X = script.ReadShort();
					Y = script.ReadShort();
					unk0 = script.ReadByte();
					unk1 = script.ReadByte();   // Something to do with palette ??
					unk2 = script.ReadByte();
				}
				break;

				// Close Dialog
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
					TextID = script.ReadAddr();
					Buttons[0] = script.ReadAddr();
					Buttons[1] = script.ReadAddr();
					Buttons[2] = script.ReadAddr();
				}
				break;

				case 0xf8:
				{
					X = script.ReadAddr();
					Y = script.ReadAddr();
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
			switch (Type)
			{
				// Display a picture from a CPS file
				case 0xd3:
				{
					return string.Format("Text menu 0x{0:X2} Display picture : (\"{1}\", X: {2}, Y: {3}, 0x{4:X2}, 0x{5:X2}, 0x{6:X2})", Type, PictureName, X * 8, Y, unk0, unk1, unk2);
				}


				// Close dialog
				case 0xd4:
				{
					return string.Format("Text menu Display text background off");
				}

				//Display background ?
				case 0xd5:
				{
					return string.Format("Text menu Display text background on");

				}

				// Fade in 
				case 0xd6:
				{
					return string.Format("Text menuFade in");

				}

				// Message and 3 buttons
				case 0xd8:
				{
					return string.Format("Text menu 0x{0:X2} Message with 3 buttons : (Msg ID: 0x{1:X2}, Button 1: 0x{2:X2}, Button 2: 0x{3:X2}, Button 3: 0x{4:X2})", Type, TextID, Buttons[0], Buttons[1], Buttons[2]);
				}


				// Message and 1 button
				case 0xf8:
				{
					return string.Format("Text menu 0x{0:X2} Message with 1 button : (Msg ID: 0x{1:X4}, Text ID: 0x{2:X4})", Type, X, Y);
				}
			}


			return string.Format("Text menu 0x{0:X2} unknown code !!!", Type);
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
		byte unk0;
		byte unk1;
		byte unk2;




		/// <summary>
		/// Id of the text in textdata
		/// </summary>
		ushort TextID;

		/// <summary>
		/// 
		/// </summary>
		ushort[] Buttons = new ushort[6];

		#endregion
	}
}
