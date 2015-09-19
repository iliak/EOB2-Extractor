using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


// http://eob.wikispaces.com/eob.inf
// http://eab.abime.net/showthread.php?t=24436&page=15
// http://www.shikadi.net/moddingwiki/Eye_of_the_Beholder_maze_information_Format

namespace INF
{
	public class Script
	{
		/// <summary>
		/// 
		/// </summary>
		public Script()
		{
			Debug = true;
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
				byte opcode = ReadByte();
				ScriptToken token = (ScriptToken)opcode;

				#region Decode
				switch (token)
				{
					// Set wall
					case ScriptToken.TOKEN_SET_WALL:
						{

						}
						break;
					// Change Wall
					case ScriptToken.TOKEN_CHANGE_WALL:
						{

						}
						break;
					// Open Door
					case ScriptToken.TOKEN_OPEN_DOOR:
						{
							token_opendoor();
						}
						break;
					// Close Door
					case ScriptToken.TOKEN_CLOSE_DOOR:
						{
							token_closedoor();
						}
						break;
					// Create monster
					case ScriptToken.TOKEN_CREATE_MONSTER:
						{
							token_createmonster();
						}
						break;
					// Teleport
					case ScriptToken.TOKEN_TELEPORT:
						{
							token_teleport();
						}
						break;
					// Steal small item
					case ScriptToken.TOKEN_STEAL_SMALL_ITEMS:
						{

						}
						break;
					// Message
					case ScriptToken.TOKEN_MESSAGE:
						{
							token_message();
						}
						break;
					// Set flag
					case ScriptToken.TOKEN_SET_FLAG:
						{
							token_setflag();
						}
						break;
					// Sound
					case ScriptToken.TOKEN_SOUND:
						{
							token_sound();
						}
						break;
					// Clear flag
					case ScriptToken.TOKEN_CLEAR_FLAG:
						{
							token_clearflag();
						}
						break;
					// Heal
					case ScriptToken.TOKEN_HEAL:
						{
							token_heal();
						}
						break;
					// Damage
					case ScriptToken.TOKEN_DAMAGE:
						{

						}
						break;
					// Jump
					case ScriptToken.TOKEN_JUMP:
						{

						}
						break;
					// End code
					case ScriptToken.TOKEN_END:
						{

						}
						break;
					// Return
					case ScriptToken.TOKEN_RETURN:
						{

						}
						break;
					//  Call
					case ScriptToken.TOKEN_CALL:
						{

						}
						break;
					//  Conditions
					case ScriptToken.TOKEN_CONDITIONAL:
						{
							token_conditional();
						}
						break;
					// Item consume
					case ScriptToken.TOKEN_CONSUME:
						{

						}
						break;
					//  Change level
					case ScriptToken.TOKEN_CHANGE_LEVEL:
						{

						}
						break;
					//  Give Experience
					case ScriptToken.TOKEN_GIVE_XP:
						{
							token_givexp();
						}
						break;
					// New item
					case ScriptToken.TOKEN_NEW_ITEM:
						{

						}
						break;
					// Launcher
					case ScriptToken.TOKEN_LAUNCHER:
						{

						}
						break;
					// Turn
					case ScriptToken.TOKEN_TURN:
						{

						}
						break;
					// Identify all items
					case ScriptToken.TOKEN_IDENTIFY_ITEMS:
						{

						}
						break;
					// Encounters (cut scene)
					case ScriptToken.TOKEN_ENCOUNTER:
						{

						}
						break;
					// Wait
					case ScriptToken.TOKEN_WAIT:
						{

						}
						break;
					//// Update screen
					//case 0xe4:
					//	{

					//	}
					//	break;
					//// Text menu
					//case 0xe3:
					//	{

					//	}
					//	break;
					//// Special window picture
					//case 0xe2:
					//	{

					//	}
					//	break;
					//// 
					//case 0xe1:
					//	{

					//	}
					//	break;
					//// Push EventFlags on stack 
					//case 0xe0:
					//	{

					//	}
					//	break;
					default:
						{
							Console.Write("#");
						}
						break;
				}

			}
			#endregion

			return sb.ToString();
		}

		#region Token methods

		/// <summary>
		/// 
		/// </summary>
		private void token_conditional()
		{
			byte token = ReadByte();
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_setflag()
		{
			byte type = ReadByte();
			byte flag = ReadByte();
			switch (type)
			{
				// Level
				case 0xef:
					{
						if (Debug)
						{
							Console.WriteLine("Set flag {0} to level", flag);
						}
					}
					break;
				// Global
				case 0xf0:
					{
						if (Debug)
						{
							Console.WriteLine("Set flag {0} to global", flag);
						}
					}
					break;
				// Monster
				case 0xf3:
					{
						if (Debug)
						{
							Console.WriteLine("Set flag {0} to monster!", flag);
						}
					}
					break;
				default:
					{
						if (Debug)
						{
							Console.WriteLine("Set flag: ERROR !!!");
						}
					}
					break;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_clearflag()
		{
			byte type = ReadByte();
			byte flag = ReadByte();
			switch (type)
			{
				// Level
				case 0xef:
					{
						if (Debug)
						{
							Console.WriteLine("Clear flag {0} to level", flag);
						}
					}
					break;
				// Global
				case 0xf0:
					{
						if (Debug)
						{
							Console.WriteLine("Clear flag {0} to global", flag);
						}
					}
					break;
				// Monster
				case 0xf3:
					{
						if (Debug)
						{
							Console.WriteLine("Clear flag {0} to monster!", flag);
						}
					}
					break;

				default:
					{
						if (Debug)
						{
							Console.WriteLine("Clear flag: ERROR !!!");
						}
					}
					break;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_message()
		{
			byte id = ReadByte();
			ReadByte();
			byte color = ReadByte();
			ReadByte();
			if (Debug)
			{
				string msg = Program.Maze.Messages.ElementAtOrDefault(id);

				Console.WriteLine("Display message {0} (color {1}) : \"{2}\"", id, color, msg);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_sound()
		{
			byte id = ReadByte();
			Point target = ReadPosition();

			if (Debug)
			{
				Console.WriteLine("Play sound {0} at {1}", id, target);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_teleport()
		{
			byte type = ReadByte();
			Point source = ReadPosition();
			Point target = ReadPosition();

			switch (type)
			{
				// Party
				case 0xe8:
					{
						if (Debug)
						{
							Console.WriteLine("Teleport team to {0}", target.ToString());
						}
					}
					break;
				// Monster
				case 0xf3:
					{
						if (Debug)
						{
							Console.WriteLine("Teleport monster at {0} to {1}", source.ToString(), target.ToString());
						}
					}
					break;
				// Item
				case 0xf5:
					{
						if (Debug)
						{
							Console.WriteLine("Teleport item at {0} to {1}", source.ToString(), target.ToString());
						}
					}
					break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_createmonster()
		{

			Monster m = new Monster();
			m.Index = ReadByte();
			m.Type = ReadByte();
			m.Position = ReadPosition();
			m.SubPosition = ReadByte();
			m.Direction = ReadByte();
			m.Type = ReadByte();
			m.PictureIndex = ReadByte();
			m.MoveState = ReadByte();
			m.Pause = ReadByte();
			m.PocketItem = ReadShort();
			m.Weapon = ReadShort();



			if (Debug)
			{
				Console.WriteLine("Create monster : {0}", m.ToString());
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_opendoor()
		{
			Point target = ReadPosition();
			if (Debug)
			{
				Console.WriteLine("Open door at {0}:{1}", target.X, target.Y);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_closedoor()
		{
			Point target = ReadPosition();
			if (Debug)
			{
				Console.WriteLine("Close door at {0}:{1}", target.X, target.Y);
			}
		}



		/// <summary>
		/// 
		/// </summary>
		private void token_heal()
		{

		}


		/// <summary>
		/// 
		/// </summary>
		private void token_givexp()
		{
			byte to = ReadByte();

			if (to == 0x2e)
			{
				ushort amount = ReadShort();
				if (Debug)
				{
					Console.WriteLine("Give {0} XP to the team", amount);
				}
			}
		}


		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private Point ReadPosition()
		{
			ushort pos = ReadShort();
			return new Point((byte)((pos >> 5) & 0x1f), (byte)(pos & 0x1f));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private byte ReadByte()
		{
			return ByteCode[Cursor++];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private ushort ReadShort()
		{
			byte h = ByteCode[Cursor++];
			byte l = ByteCode[Cursor++];

			return (ushort)((h << 8) + l);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private byte PeekByte()
		{
			return ByteCode[Cursor];
		}


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public bool Debug;

		/// <summary>
		/// 
		/// </summary>
		public byte[] ByteCode;


		/// <summary>
		/// 
		/// </summary>
		private ushort Cursor;

		#endregion
	}


	/// <summary>
	/// Script tokens
	/// </summary>
	public enum ScriptToken
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
