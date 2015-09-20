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

				if (Debug)
				{
					Console.Write("0x{0:X4}: ", Cursor);
				}
				byte opcode = ReadByte();

				#region Decode
				switch (opcode)
				{
					// Set wall
					case 0xff:
					{
						token_setwall();
					}
					break;
					// Change Wall
					case 0xfe:
					{
						token_changewall();
					}
					break;
					// Open Door
					case 0xfd:
					{
						token_opendoor();
					}
					break;
					// Close Door
					case 0xfc:
					{
						token_closedoor();
					}
					break;
					// Create monster
					case 0xfb:
					{
						token_createmonster();
					}
					break;
					// Teleport
					case 0xfa:
					{
						token_teleport();
					}
					break;
					// Steal small item
					case 0xf9:
					{
						token_stealsmallitems();
					}
					break;
					// Message
					case 0xf8:
					{
						token_message();
					}
					break;
					// Set flag
					case 0xf7:
					{
						token_setflag();
					}
					break;
					// Sound
					case 0xf6:
					{
						token_sound();
					}
					break;
					// Clear flag
					case 0xf5:
					{
						token_clearflag();
					}
					break;
					// Heal
					case 0xf4:
					{
						token_heal();
					}
					break;
					// Damage
					case 0xf3:
					{
						token_damage();
					}
					break;
					// Jump
					case 0xf2:
					{
						token_jump();
					}
					break;
					// End code
					case 0xf1:
					{
						token_end();
					}
					break;
					// Return
					case 0xf0:
					{
						token_return();
					}
					break;
					//  Call
					case 0xef:
					{
						token_call();
					}
					break;
					//  Conditions
					case 0xee:
					{
						token_conditional();
					}
					break;
					// Item consume
					case 0xed:
					{
						token_consume();
					}
					break;
					//  Change level
					case 0xec:
					{
						token_changelevel();
					}
					break;
					//  Give Experience
					case 0xeb:
					{
						token_givexp();
					}
					break;
					// New item
					case 0xea:
					{
						token_newitem();
					}
					break;
					// Launcher
					case 0xe9:
					{
						token_launcher();
					}
					break;
					// Turn
					case 0xe8:
					{
						token_turn();
					}
					break;
					// Identify all items
					case 0xe7:
					{
						token_identifyitem();
					}
					break;
					// Encounters (cut scene)
					case 0xe6:
					{
						token_encounter();
					}
					break;
					// Wait
					case 0xe5:
					{
						token_wait();
					}
					break;
					// Update screen
					case 0xe4:
					{
						token_updatescreen();
					}
					break;
					// Text menu
					case 0xe3:
					{
						token_screenmenu();
					}
					break;
					// Special window picture
					case 0xe2:
					{
						token_specialwindow();
					}
					break;
					// 
					case 0xe1:
					{

					}
					break;
					// Push EventFlags on stack 
					case 0xe0:
					{

					}
					break;
					default:
					{
						Console.WriteLine("# opcode: 0x{0:X2}", opcode);
					}
					break;
				}

			}
			#endregion

			return sb.ToString();
		}


		#region Conditional tokens

		/// <summary>
		/// 
		/// </summary>
		private void token_conditional()
		{
			Console.Write("IF (");

			while (true)
			{
				byte operation = ReadByte();
				switch (operation)
				{
					// Contain race
					case 0xdd:
					{
						condition_containrace();
					}
					break;

					// get wall number
					case 0xf7:
					{
						condition_getwallnumber();
					}
					break;

					// Count items
					case 0xf5:
					{
						condition_countitems();
					}
					break;

					// Count monsters
					case 0xf3:
					{
						condition_countmonsters();
					}
					break;

					// Check party position
					case 0xf1:
					{
						condition_checkpartyposition();
					}
					break;

					// Get global flag
					case 0xf0:
					{
						condition_getglobalflag();
					}
					break;

					// Get Party direction
					case 0xed:
					{
						condition_getpartydirection();
					}
					break;

					// Get wall side
					case 0xe9:
					{
						condition_getwallside();
					}
					break;

					// Get pointer item
					case 0xe7:
					{
						condition_getpointeritem();
					}
					break;

					// Get trigger flag
					case 0xe0:
					{
						condition_gettriggerflag();
					}
					break;

					// contains class
					case 0xdc:
					{
						condition_containclass();
					}
					break;

					// Roll dice
					case 0xdb:
					{
						condition_rolldice();
					}
					break;

					// Is party visible
					case 0xda:
					{

					}
					break;

					// Immediate short value
					case 0xd2:
					{
						condition_immediateshort();
					}
					break;

					// contains alignment
					case 0xce:
					{

					}
					break;

					// Get level flag
					case 0xef:
					{
						condition_getlevelflag();
					}
					break;

					// End condition
					case 0xee:
					{
						Console.Write(")");
					}
					break;

					#region Operators
					// operator EQ
					case 0xff:
					{
						Console.Write(" == ");
					}
					break;

					// operator NEQ
					case 0xfe:
					{
						Console.Write(" != ");
					}
					break;

					// operator LT
					case 0xfd:
					{
						Console.Write(" < ");
					}
					break;

					// operator LTE
					case 0xfc:
					{
						Console.Write(" <= ");
					}
					break;

					// operator GT
					case 0xfb:
					{
						Console.Write(" > ");
					}
					break;

					// operator GTE
					case 0xfa:
					{
						Console.Write(" >= ");
					}
					break;

					// operator AND
					case 0xf9:
					{
						Console.Write(" && ");
					}
					break;

					// operator OR
					case 0xf8:
					{
						Console.Write(" || ");
					}
					break;
					#endregion

					default:
					{
						Console.Write("[0x{0:X2}] ", operation);
					}
					break;
				}


				if (operation == 0xee)
				{
					break;
				}
				//else
				//Console.Write(" ... ");
			}


			ushort addr = ReadAddr();
			Console.WriteLine("\t====> JUMP TO 0x{0:X4}", addr - 2);
		}


		/// <summary>
		/// 
		/// </summary>
		private void condition_immediateshort()
		{
			ushort value = ReadAddr(); ;
			Console.Write("0x{0:X4}, ", value);
		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_countmonsters()
		{
			Point target = ReadPosition();
			Console.Write("Count monsters at {0}, ", target);
		}


		/// <summary>
		/// 
		/// </summary>
		private void condition_countitems()
		{
			byte type = ReadByte();
			Point target = ReadPosition();
			Console.Write("Count items of type 0x{0:X2} at {1}, ", type, target);
		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_gettriggerflag()
		{
			Console.Write("Get trigger flag, ");
		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_getpartydirection()
		{
			Console.Write("Check party direction ");
		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_checkpartyposition()
		{
			Point pos = ReadPosition();
			Console.Write("Check party position {0}, ", pos);

		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_getglobalflag()
		{
			byte flag = ReadByte();
			Console.Write("Get global flag 0x{0:X2}, ", flag);

		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_getlevelflag()
		{
			byte flag = ReadByte();
			Console.Write("Get level flag 0x{0:X2}, ", flag);

		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_rolldice()
		{
			Dice dice = ReadDice();
			Console.Write("Roll dice {0}, ", dice);

		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_getpointeritem()
		{
			byte type = ReadByte();

			if (type == 0xf5)
				Console.Write("Get pointer item unknown, ");
			else if (type == 0xf6)
				Console.Write("Get pointer item value, ");
			else if (type == 0xe1)
				Console.Write("Get pointer item type, ");

		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_getwallside()
		{
			byte side = ReadByte();
			Point target = ReadPosition();
			Console.Write("Get wall side {0} at {1}, ", side, target);
		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_getwallnumber()
		{
			Point target = ReadPosition();
			Console.Write("Get wall number at {0}, ", target);
		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_containrace()
		{
			byte raceid = ReadByte();
			Console.Write("Need race {0}, ", raceid);
		}

		/// <summary>
		/// 
		/// </summary>
		private void condition_containclass()
		{
			byte id = ReadByte();
			Console.Write("Need class {0}, ", id);
		}

		#endregion


		#region Token methods

		private void token_specialwindow()
		{
			Console.WriteLine("Special window...");
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_screenmenu()
		{
			byte id = ReadByte();

			if (Debug)
			{
				Console.WriteLine("Screen menu 0x{0:X2}", id);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_updatescreen()
		{
			if (Debug)
			{
				Console.WriteLine("Update screen...");
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_wait()
		{
			ushort ticks = ReadShort();

			if (Debug)
			{
				Console.WriteLine("Waiting {0} ticks", ticks);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_encounter()
		{
			byte index = ReadByte();
			if (Debug)
			{
				Console.WriteLine("Encounter {0}", index);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_identifyitem()
		{
			Point target = ReadPosition();
			if (Debug)
			{
				Console.WriteLine("Identify items at {0}", target);
			}

		}

		/// <summary>
		/// 
		/// </summary>
		private void token_turn()
		{
			byte type = ReadByte();
			byte amount = ReadByte();

			switch (type)
			{
				// Party
				case 0xf1:
				{
					if (Debug)
					{
						Console.WriteLine("Turning party {0} time(s)", amount);
					}
				}
				break;

				// Item
				case 0xf5:
				{
					if (Debug)
					{
						Console.WriteLine("Turning item {0} time(s)", amount);
					}
				}
				break;

				default:
				{
					Console.WriteLine("Turning unknow type (0x{0:2}) {1} time(s)", type, amount);
				}
				break;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_launcher()
		{
			byte type = ReadByte();
			ushort itemid = ReadShort();
			Point target = ReadPosition();
			byte direction = ReadByte();
			byte subpos = ReadByte();

			switch (type)
			{
				// Spell
				case 0xdf:
				{
					if (Debug)
					{
						Console.WriteLine("Launching spell 0x{0:X4} from {1} facing {2} at subpos {3}", itemid, target, direction, subpos);
					}
				}
				break;

				// Item
				case 0xec:
				{
					if (Debug)
					{
						Console.WriteLine("Launching item 0x{0:X4} from {1} facing {2} at subpos {3}", itemid, target, direction, subpos);
					}
				}
				break;

				default:
				{
					Console.WriteLine("Launching unknow (id: 0x{0:X4}) from {1} facing {2} at subpos {3}", itemid, target, direction, subpos);
				}
				break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_newitem()
		{
			ushort itemid = ReadShort();
			Point target = ReadPosition();
			byte subpos = ReadByte();

			if (Debug)
			{
				Console.WriteLine("New item 0x{0:X4} at {1}:{2}", itemid, target, subpos);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_changelevel()
		{
			byte type = ReadByte();
			byte level;
			Point target;
			byte direction;

			switch (type)
			{
				// Inter level
				case 0xe5:
				{
					level = ReadByte();
					target = ReadPosition();
					direction = ReadByte();

					if (Debug)
					{
						Console.WriteLine("Change level to {0} at {1} facing to {2}", level, target, direction);
					}
				}
				break;

				// Intra level
				case 0x00:
				{
					target = ReadPosition();
					direction = ReadByte();
					if (Debug)
					{
						Console.WriteLine("Change level at {0} facing to {1}", target, direction);
					}
				}
				break;

				default:
				{
					Console.WriteLine("Change level (unknow id 0x{0:X2})", type);
				}
				break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_consume()
		{
			byte location;
			Point target;

			byte type = ReadByte();
			switch (type)
			{
				// Mouse pointer
				case 0xff:
				{
					location = type;
					if (Debug)
					{
						Console.WriteLine("Consume item from mouse pointer");
					}
				}
				break;
				// at position
				case 0xfe:
				{
					location = type;
					target = ReadPosition();
					if (Debug)
					{
						Console.WriteLine("Consume item at position {0}", target);
					}
				}
				break;
				// At position by type
				case 0x0:
				{
					location = 0;
					target = ReadPosition();
					if (Debug)
					{
						Console.WriteLine("Consume item at position {0} of type {1}", target, type);
					}
				}
				break;

				default:
				{
					Console.WriteLine("Consume item unknown type 0x{0:X2}", type);
				}
				break;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_call()
		{
			ushort address = ReadShort();
			if (Debug)
			{
				Console.WriteLine("Call to 0x{0:X4}", address);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_return()
		{
			if (Debug)
			{
				Console.WriteLine("Return");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_end()
		{
			if (Debug)
			{
				Console.WriteLine("End");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_jump()
		{
			ushort addr = ReadAddr();

			if (Debug)
			{
				Console.WriteLine("Jumping to 0x{0:X4}", addr - 2);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_damage()
		{
			byte whom = ReadByte();
			Dice dice = ReadDice();

			if (Debug)
			{
				Console.WriteLine("Damage {0} with dice {1}", whom, dice);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_setwall()
		{
			Point target;
			byte to;
			byte side;
			byte direction;

			byte type = ReadByte();
			switch (type)
			{
				// All sides
				case 0xf7:
				{
					target = ReadPosition();
					to = ReadByte();
					if (Debug)
					{
						Console.WriteLine("Set wall at {0} all sides to {1}", target, to);
					}
				}
				break;
				// One side
				case 0xe9:
				{
					target = ReadPosition();
					side = ReadByte();
					to = ReadByte();
					if (Debug)
					{
						Console.WriteLine("Set wall at {0} sides {1} to {2}", target, side, to);
					}
				}
				break;
				// Change party direction
				case 0xed:
				{
					direction = ReadByte();
					if (Debug)
					{
						Console.WriteLine("Set wall change party direction to {0}", direction);
					}
				}
				break;

				default:
				{
					Console.WriteLine("Set wall unknow type 0x{0:X2}", type);
				}
				break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void token_changewall()
		{
			Point target;
			byte to;
			byte from;
			byte side;

			byte type = ReadByte();
			switch (type)
			{
				// All sides
				case 0xf7:
				{
					target = ReadPosition();
					to = ReadByte();
					from = ReadByte();
					if (Debug)
					{
						Console.WriteLine("Change wall at {0} all sides to {1} from {2}", target, to, from);
					}
				}
				break;
				// One side
				case 0xe9:
				{
					target = ReadPosition();
					side = ReadByte();
					to = ReadByte();
					from = ReadByte();
					if (Debug)
					{
						Console.WriteLine("Change wall at {0} side {1} to {2} from {3}", target, side, to, from);
					}
				}
				break;
				// Open door
				case 0xed:
				{
					target = ReadPosition();
					if (Debug)
					{
						Console.WriteLine("Change wall open door at {0}", target);
					}
				}
				break;

				default:
				{
					Console.WriteLine("Change wall unknow type 0x{0:X2}", type);
				}
				break;
			}
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
						Console.WriteLine("Set flag 0x{0:X2} to level", flag);
					}
				}
				break;
				// Global
				case 0xf0:
				{
					if (Debug)
					{
						Console.WriteLine("Set flag 0x{0:X2} to global", flag);
					}
				}
				break;
				// Monster
				case 0xf3:
				{
					if (Debug)
					{
						Console.WriteLine("Set flag 0x{0:X2} to monster!", flag);
					}
				}
				break;

				default:
				{
					Console.WriteLine("Set flag unknow type 0x{0:X2}", type);
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
						Console.WriteLine("Clear flag 0x{0:X2} to level", flag);
					}
				}
				break;
				// Global
				case 0xf0:
				{
					if (Debug)
					{
						Console.WriteLine("Clear flag 0x{0:X2} to global", flag);
					}
				}
				break;
				// Monster
				case 0xf3:
				{
					if (Debug)
					{
						Console.WriteLine("Clear flag 0x{0:X2} to monster!", flag);
					}
				}
				break;


				default:
				{
					Console.WriteLine("Clear wall unknow type 0x{0:X2}", type);
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

				default:
				{
					Console.WriteLine("Teleport unknow type 0x{0:X2}", type);
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
		private void token_stealsmallitems()
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
			if (Debug)
			{
				Console.WriteLine("Heal");
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void token_givexp()
		{
			byte type = ReadByte();

			switch (type)
			{
				// To the party
				case 0x2e:
				{
					ushort amount = ReadShort();
					if (Debug)
					{
						Console.WriteLine("Give {0} XP to the team", amount);
					}
				}
				break;
				default:
				{
					Console.WriteLine("Give XP unknow type 0x{0:X2}", type);
				}
				break;
			}
		}

		#endregion


		#region Helpers

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
		private Dice ReadDice()
		{
			return new Dice(ReadByte(), ReadByte(), ReadByte());
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
		private ushort ReadAddr()
		{
			byte h = ByteCode[Cursor++];
			byte l = ByteCode[Cursor++];

			return (ushort)((l << 8) + h);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private byte PeekByte()
		{
			return ByteCode[Cursor];
		}

		#endregion


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
