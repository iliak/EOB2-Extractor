using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class MessageToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public MessageToken(Script script) : base(script)
		{
			Id = script.ReadByte();
			Unk0 = script.ReadByte();
			Color = script.ReadByte();
			Unk1 = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string msg = Program.Maze.Messages.ElementAtOrDefault(Id);
			return string.Format("Display message {0} (color {1}) : \"{2}\"", Id, Color, msg);
		}


		#region Properties
		byte Id;
		byte Unk0;
		byte Color;
		byte Unk1;


		#endregion
	}
}
