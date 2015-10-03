using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Explorer
{
	class SoundToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public SoundToken(Script script) : base(script)
		{
			Id = script.ReadByte();
			byte b = script.ReadByte();
			if (b != 0x00)
				Target = Location.FromValue(b);

			Flag = script.ReadByte();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (Target == null)
				return string.Format("Play sound {0} Flag: 0x{1:X2}", Id, Flag);
			else
				return string.Format("Play sound {0} at {1}, Flag: 0x{2:X2}", Id, Target, Flag);
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		Location Target;

		/// <summary>
		/// 
		/// </summary>
		byte Id;


		/// <summary>
		/// 
		/// </summary>
		byte Flag;

		#endregion
	}
}
