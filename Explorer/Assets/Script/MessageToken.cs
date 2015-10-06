using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class MessageToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public MessageToken(Script script, Maze maze) : base(script)
		{
			MsgId = script.ReadByte();
			Unk0 = script.ReadByte();
			Color = script.ReadByte();
			Unk1 = script.ReadByte();

			Message = maze.GetString(MsgId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Display message id: {0} (color: {1}, unk0: {2}, unk1: {3}) : \"{4}\"", MsgId, Color, Unk0, Unk1, Message);
		}


		#region Properties

		/// <summary>
		/// Display message
		/// </summary>
		string Message;

		/// <summary>
		/// 
		/// </summary>
		byte MsgId;

		/// <summary>
		/// 
		/// </summary>
		byte Color;

		/// <summary>
		/// 
		/// </summary>
		byte Unk0;

		/// <summary>
		/// 
		/// </summary>
		byte Unk1;			// Display text in the bottom of the main menu, or 0xff display message with a OK button and the blue backgroun (?)


		#endregion
	}
}
