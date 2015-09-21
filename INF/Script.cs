using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


// http://eob.wikispaces.com/eob.inf
// http://eab.abime.net/showthread.php?t=24436&page=15
// http://eab.abime.net/showthread.php?t=24436&page=13
// http://www.shikadi.net/moddingwiki/Eye_of_the_Beholder_maze_information_Format
namespace INF
{
	public class Script
	{
		/// <summary>
		/// 
		/// </summary>
		public Script(byte[] bytecode)
		{
			ByteCode = bytecode;
			Tokens = new List<ScriptToken>();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string Decompile()
		{
			StringBuilder sb = new StringBuilder();

			Cursor = 0;
			while (Cursor < ByteCode.Length)
			{

				Console.Write("[0x{0:X4}]: ", Cursor + 2);
				byte opcode = ReadByte();

				ScriptToken token = null;

				#region Decode
				switch (opcode)
				{
					case 0xff: token = new SetWallToken(this); break;
					case 0xfe: token = new ChangeWallToken(this); break;
					case 0xfd: token = new OpenDoorToken(this); break;
					case 0xfc: token = new CloseDoorToken(this); break;
					case 0xfb: token = new CreateMonsterToken(this); break;
					case 0xfa: token = new TeleportToken(this); break;
					case 0xf9: token = new StealSmallItemToken(this); break;
					case 0xf8: token = new MessageToken(this); break;
					case 0xf7: token = new SetFlagToken(this); break;
					case 0xf6: token = new SoundToken(this); break;
					case 0xf5: token = new ClearFlagToken(this); break;
					case 0xf4: token = new HealToken(this); break;
					case 0xf3: token = new DamageToken(this); break;
					case 0xf2: token = new JumpToken(this); break;
					case 0xf1: token = new EndToken(this); break;
					case 0xf0: token = new ReturnToken(this); break;
					case 0xef: token = new CallToken(this); break;
					case 0xee: token = new ConditionalToken(this); break;
					case 0xed: token = new ConsumeItemToken(this); break;
					case 0xec: token = new ChangeLevelToken(this); break;
					case 0xeb: token = new GiveXPToken(this); break;
					case 0xea: token = new NewItemToken(this); break;
					case 0xe9: token = new LauncherToken(this); break;
					case 0xe8: token = new TurnToken(this); break;
					case 0xe7: token = new IdentifyItemToken(this); break;
					case 0xe6: token = new EncounterToken(this); break;
					case 0xe5: token = new WaitToken(this); break;
					case 0xe4: token = new UpdateScreenToken(this); break;
					case 0xe3: token = new ScreenMenuToken(this); break;
					case 0xe2: token = new SpecialWindowToken(this); break; // Special window picture
																			//case 0xe1: token = null; break;
																			//case 0xe0: token = new PushEventFlagToken(this); break;
					default:
					{
						Console.Write("# opcode: 0x{0:X2}", opcode);
					}
					break;
				}

				Console.WriteLine(token);

				Tokens.Add(token);

			}
			#endregion

			return sb.ToString();
		}


		#region Conditional tokens



		/// <summary>
		/// 
		/// </summary>
		private void condition_immediateshort()
		{
			ushort value = ReadAddr(); ;
			Console.Write("0x{0:X4}, ", value);
		}

		#endregion




		#region Helpers

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Point ReadPosition()
		{
			ushort pos = ReadShort();
			return new Point((byte)((pos >> 5) & 0x1f), (byte)(pos & 0x1f));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dice ReadDice()
		{
			return new Dice(ReadByte(), ReadByte(), ReadByte());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public byte ReadByte()
		{
			return ByteCode[Cursor++];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ushort ReadShort()
		{
			byte h = ByteCode[Cursor++];
			byte l = ByteCode[Cursor++];

			return (ushort)((h << 8) + l);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ushort ReadAddr()
		{
			byte h = ByteCode[Cursor++];
			byte l = ByteCode[Cursor++];

			return (ushort)((l << 8) + h);
		}

		#endregion


		#region Properties


		/// <summary>
		/// 
		/// </summary>
		List<ScriptToken> Tokens;

		/// <summary>
		/// 
		/// </summary>
		private byte[] ByteCode;


		/// <summary>
		/// 
		/// </summary>
		public ushort Cursor;

		#endregion
	}


	/// <summary>
	/// Script tokens
	/// </summary>
	public enum ScriptTokens
	{
		TOKEN_SET_WALL = 0xff,
		TOKEN_CHANGE_WALL = 0xfe,
		TOKEN_OPEN_DOOR = 0xfd,
		TOKEN_CLOSE_DOOR = 0xfc,
		TOKEN_CREATE_MONSTER = 0xfb,
		TOKEN_TELEPORT = 0xfa,
		TOKEN_STEAL_SMALL_ITEMS = 0xf9,
		TOKEN_MESSAGE = 0xf8,
		TOKEN_SET_FLAG = 0xf7,
		TOKEN_SOUND = 0xf6,
		TOKEN_CLEAR_FLAG = 0xf5,
		TOKEN_HEAL = 0xf4,
		TOKEN_DAMAGE = 0xf3,
		TOKEN_JUMP = 0xf2,
		TOKEN_END = 0xf1,
		TOKEN_RETURN = 0xf0,
		TOKEN_CALL = 0xef,
		TOKEN_CONDITIONAL = 0xee,
		TOKEN_CONSUME = 0xed,
		TOKEN_CHANGE_LEVEL = 0xec,
		TOKEN_GIVE_XP = 0xeb,
		TOKEN_NEW_ITEM = 0xea,
		TOKEN_LAUNCHER = 0xe9,
		TOKEN_TURN = 0xe8,
		TOKEN_IDENTIFY_ITEMS = 0xe7,
		TOKEN_ENCOUNTER = 0xe6,
		TOKEN_WAIT = 0xe5,
	}


	/// <summary>
	/// Condition values
	/// </summary>
	public enum ConditionValue
	{
		OPERATOR_EQ = 0xff,
		OPERATOR_NEQ = 0xfe,
		OPERATOR_LT = 0xfd,
		OPERATOR_LTE = 0xfc,
		OPERATOR_GT = 0xfb,
		OPERATOR_GTE = 0xfa,
		OPERATOR_AND = 0xf9,
		OPERATOR_OR = 0xf8,
		VALUE_GET_WALL_NUMBER = 0xf7,
		VALUE_COUNT_ITEMS = 0xf5,
		VALUE_COUNT_MONSTERS = 0xf3,
		VALUE_CHECK_PARTY_POSITION = 0xf1,
		VALUE_GET_GLOBAL_FLAG = 0xf0,
		VALUE_END_CONDITIONAL = 0xee,
		VALUE_GET_PARTY_DIRECTION = 0xed,
		VALUE_GET_WALL_SIDE = 0xe9,
		VALUE_GET_POINTER_ITEM = 0xe7,
		VALUE_GET_TRIGGER_FLAG = 0xe0,
		VALUE_CONTAINS_RACE = 0xdd,
		VALUE_CONTAINS_CLASS = 0xdc,
		VALUE_ROLL_DICE = 0xdb,
		VALUE_IS_PARTY_VISIBLE = 0xda,
		VALUE_CONTAINS_ALIGNMENT = 0xce,
		VALUE_GET_LEVEL_FLAG = 0xef,
	}

}
