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
		public TextMenuToken(Script script, Maze maze) : base(script)
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

					D8_Text = Assets.Text[TextID];
					D8_Buttons[0] = script.ReadAddr();
					D8_Buttons[1] = script.ReadAddr();
					D8_Buttons[2] = script.ReadAddr();

					D8_Strings[0] = maze.GetString(D8_Buttons[0]);
					D8_Strings[1] = maze.GetString(D8_Buttons[1]);
					D8_Strings[2] = maze.GetString(D8_Buttons[2]);
				}
				break;

				case 0xf8:
				{
					TextID = script.ReadAddr();
					Y = script.ReadAddr();

					//F8_Text = maze.GetString(TextID);
					//if (F8_Text == null)
						F8_Text= Assets.Text[TextID - 1];
					F8_Button = maze.GetString(Y);

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
					return string.Format("Text menu 0xD3 Display picture : (\"{0}\", X: {1}, Y: {2}, 0x{3:X2}, 0x{4:X2}, 0x{5:X2})", PictureName, X * 8, Y, unk0, unk1, unk2);
				}


				// Close dialog
				case 0xd4:
				{
					return string.Format("Text menu : background off");
				}

				//Display background ?
				case 0xd5:
				{
					return string.Format("Text menu : background on");

				}

				// Fade in 
				case 0xd6:
				{
					return string.Format("Text menu Fade in");

				}

				// Message and 3 buttons
				case 0xd8:
				{
					return string.Format("Text menu 0xD8 : \"{0}\" with buttons [\"{1}\"], [\"{2}\"], [\"{3}\"]", D8_Text, D8_Strings[0], D8_Strings[1], D8_Strings[2]);
				}


				// Message and 1 button
				case 0xf8:
				{
					return string.Format("Text menu 0xF8 : \"{0}\" with button [\"{1}\"]", F8_Text, F8_Button);
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


		#region 0xD8

		/// <summary>
		/// 
		/// </summary>
		string D8_Text;

		/// <summary>
		/// 
		/// </summary>
		ushort[] D8_Buttons = new ushort[3];

		/// <summary>
		/// 
		/// </summary>
		string[] D8_Strings = new string[3];

		#endregion


		#region 0xF8

		/// <summary>
		/// 
		/// </summary>
		string F8_Text;

		/// <summary>
		/// 
		/// </summary>
		string F8_Button;
		#endregion

		#endregion
	}
}
