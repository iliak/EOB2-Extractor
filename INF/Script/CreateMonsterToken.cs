using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class CreateMonsterToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public CreateMonsterToken(Script script) : base(script)
		{
			Monster = new Monster();
			Monster.Index = script.ReadByte();
			Monster.Type = script.ReadByte();
			Monster.Position = Location.FromScript(script); // script.ReadPosition();
			Monster.SubPosition = script.ReadByte();
			Monster.Direction = script.ReadByte();
			Monster.Type = script.ReadByte();
			Monster.PictureIndex = script.ReadByte();
			Monster.MoveState = script.ReadByte();
			Monster.Pause = script.ReadByte();
			Monster.PocketItem = script.ReadShort();
			Monster.Weapon = script.ReadShort();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Create monster: {0}", Monster);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		Monster Monster;

		#endregion
	}
}
