using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF
{
	class ConditionalToken : ScriptToken
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		public ConditionalToken(Script script) : base(script)
		{
			Conditions = new Stack<ConditionalBase>();
			ConditionalBase token = null;

			Console.WriteLine("IF ");
			while (true)
			{
				byte operation = script.ReadByte();
				if (operation == 0xee)
				{
					break;
				}


				switch (operation)
				{

					case 0xff:
					case 0xfe:
					case 0xfd:
					case 0xfc:
					case 0xfb:
					case 0xfa:
					case 0xf9:
					case 0xf8: token = new ConditionalOperator(script, operation); break;
					case 0xf7: token = new ConditionalGetWallNumber(script); break;
					case 0xf5: token = new ConditionalItemCount(script); break;
					case 0xf3: token = new ConditionalMonsterCount(script); break;
					case 0xf1: token = new ConditionalGetPartyPosition(script); break;
					case 0xf0: token = new ConditionalGetGlobalFlag(script); break;
					case 0xef: token = new ConditionalGetLevelFlag(script); break;
					//case 0xee: token = new ConditionalEnd(script); break;
					case 0xed: token = new ConditionalGetPartyDirection(script); break;
					case 0xe9: token = new ConditionalGetWallSide(script); break;
					case 0xe7: token = new ConditionalGetPointerItem(script); break;
					case 0xe4: token = new ConditionalMenuChoice(script); break;
					case 0xe0: token = new ConditionalGetTriggerFlag(script); break;
					case 0xdd: token = new ConditionalContainRace(script); break;
					case 0xdc: token = new ConditionalContainClass(script); break;
					case 0xdb: token = new ConditionalDice(script); break;
					case 0xda: token = new ConditionalPartyVisible(script); break;
					case 0xd2: token = new ConditionalImmediateShort(script); break;
					case 0xce: token = new ConditionalContainAlignment(script); break;
					case 0x01: token = new ConditionalPushTrue(script); break;
					case 0x00: token = new ConditionalPushFalse(script); break;
					default:
					if (operation >= 0x80)
						token = new ConditionalInvalid(operation, script);
					else
						token = new ConditionalPushValue(operation, script); break;
				}

				if (token == null)
					continue;

				Console.WriteLine("\t" + token);
				Conditions.Push(token);

			}


			ushort addr = script.ReadAddr();
			Console.WriteLine("\t====> JUMP TO 0x{0:X4}", addr);

			//Decode();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("");
		}


		/// <summary>
		/// 
		/// </summary>
		void Decode()
		{
			while (Conditions.Count > 0)
			{
				ConditionalOperator op = Conditions.Pop() as ConditionalOperator;
				if (op.Operator == 0xf9 || op.Operator == 0xf8)
				{

				}


				ConditionalBase right = Conditions.Pop();
				ConditionalBase left = Conditions.Pop();

				Console.WriteLine("{0} {1} {2}", left, op, right);
			}

		}







		#region Properties

		/// <summary>
		/// 
		/// </summary>
		Stack<ConditionalBase> Conditions;

		#endregion
	}
}
