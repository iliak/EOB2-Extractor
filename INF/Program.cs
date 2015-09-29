using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace INF
{
	class Program
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			byte b;
			ushort s;
			uint l;


			Maze = new Maze();

			string filename = @"c:\eob2-uncps\LEVEL1.INF_uncps";
			using (Reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{

				// Hunk1 offset
				Maze.Hunks[1] = Reader.ReadUInt16();

				#region Sub level data
				for (byte sub = 0; sub < 2; sub++)
				{
					Header header = new Header();

					if (Reader.BaseStream.Position < Maze.Hunks[1])
					{
						// Chunk offsets
						header.NextHunk = Reader.ReadUInt16();

						b = Reader.ReadByte();
						if (b == 0xEC)
						{
							#region General informations
							header.mazeName = ReadString(13);
							header.vmpVcnName = ReadString(13);

							if (Reader.ReadByte() != 0xFF)
								header.paletteName = ReadString(13);

							header.SoundName = ReadString(13);

							#endregion

							#region Door name & Positions + offset
							for (byte i = 0; i < 2; i++)
							{
								DoorInfo door = header.Doors[i];

								b = Reader.ReadByte();
								if (b == 0xEC || b == 0xEA)
								{
									door.gfxfile = ReadString(13);
									door.idx = Reader.ReadByte();
									door.type = Reader.ReadByte();
									door.knob = Reader.ReadByte();

									for (byte t = 0; t < 3; t++)
									{
										door.DoorRectangle[t].X = Reader.ReadInt16();
										door.DoorRectangle[t].Y = Reader.ReadInt16();
										door.DoorRectangle[t].Width = Reader.ReadInt16();
										door.DoorRectangle[t].Height = Reader.ReadInt16();
									}

									for (byte t = 0; t < 2; t++)
									{
										door.ButtonRectangles[t].X = Reader.ReadInt16();
										door.ButtonRectangles[t].Y = Reader.ReadInt16();
										door.ButtonRectangles[t].Width = Reader.ReadInt16();
										door.ButtonRectangles[t].Height = Reader.ReadInt16();
									}

									for (byte t = 0; t < 2; t++)
									{
										door.ButtonPositions[t].X = Reader.ReadInt16();
										door.ButtonPositions[t].Y = Reader.ReadInt16();
									}
								}

							}
							#endregion

							// Max nomber of monster ??
							s = Reader.ReadUInt16();

							#region Monsters graphics informations
							for (byte i = 0; i < 2; i++)
							{
								MonsterGFX gfx = header.MonsterGFX[i];

								b = Reader.ReadByte();
								if (b == 0xEC)
								{
									gfx.LoadProg = Reader.ReadByte();
									gfx.unk0 = Reader.ReadByte();
									gfx.label = ReadString(13);
									gfx.unk1 = Reader.ReadByte();
								}
							}
							#endregion

							#region Monster definitions
							while ((b = Reader.ReadByte()) != 0xFF)
							{
								MonsterType m = new MonsterType();
								m.index = b;
								m.unk0 = Reader.ReadByte();
								m.THAC0 = Reader.ReadByte();
								m.unk1 = Reader.ReadByte();

								m.HPDice.Rolls = Reader.ReadByte();
								m.HPDice.Sides = Reader.ReadByte();
								m.HPDice.Base = Reader.ReadByte();

								m.numberOfAttacks = Reader.ReadByte();
								for (byte i = 0; i < 3; i++)
								{
									m.AttackDice[i].Rolls = Reader.ReadByte();
									m.AttackDice[i].Sides = Reader.ReadByte();
									m.AttackDice[i].Base = Reader.ReadByte();
								}

								m.specialAttackFlag = Reader.ReadUInt16();
								m.AbilitiesFlag = Reader.ReadUInt16();
								m.unk2 = Reader.ReadUInt16();
								m.EXPGain = Reader.ReadUInt16();
								m.size = Reader.ReadByte();
								m.attackSound = Reader.ReadByte();
								m.moveSound = Reader.ReadByte();
								m.unk3 = Reader.ReadByte();

								b = (byte)Reader.ReadByte();
								if (b != 0xff)
								{
									m.isAttack2 = true;
									m.distantAttack = Reader.ReadByte();
									m.maxAttackCount = Reader.ReadByte();

									for (byte i = 0; i < m.maxAttackCount; i++)
									{
										m.attackList[i] = Reader.ReadByte();

										Reader.ReadByte(); // Pad ???
									}
								}

								m.turnUndeadValue = Reader.ReadByte();
								m.unk4 = Reader.ReadByte();
								m.unk5[0] = Reader.ReadByte();
								m.unk5[1] = Reader.ReadByte();
								m.unk5[2] = Reader.ReadByte();


								header.MonsterTypes.Enqueue(m);
							}
							#endregion

							#region Wall decoration data
							b = Reader.ReadByte();
							if (b != 0xFF)
							{
								ushort decorateblocks = Reader.ReadUInt16();
								for (ushort i = 0; i < decorateblocks; i++)
								{
									DecorationInfo deco = new DecorationInfo();

									b = Reader.ReadByte();
									if (b == 0xEC)
									{
										deco.Files.GFXName = ReadString(13);
										deco.Files.DECName = ReadString(13);
									}
									else if (b == 0xFB)
									{
										deco.WallMappings.index = Reader.ReadByte();
										deco.WallMappings.WallType = Reader.ReadByte();
										deco.WallMappings.DecorationID = Reader.ReadByte();
										deco.WallMappings.EventMask = Reader.ReadByte();
										deco.WallMappings.Flags = Reader.ReadByte();
									}

									header.Decorations.Enqueue(deco);
								}
							}
							#endregion


							while ((l = Reader.ReadUInt32()) != 0xFFFFFFFF)
							{
							}
						}
					}

					Maze.Headers[sub] = header;
				}
				#endregion

				// Hunk2 offset
				Maze.Hunks[2] = Reader.ReadUInt16();


				#region Monsters
				b = Reader.ReadByte();
				if (b != 0xff)
				{
					#region Monster timers
					while ((b = Reader.ReadByte()) != 0xff)
					{
						Maze.Timer.Enqueue(Reader.ReadByte());
					}
					#endregion

					#region Monster descriptions
					for (byte i = 0; i < 30; i++)
					{
						Monster m = new Monster();
						m.Index = Reader.ReadByte();
						m.TimeDelay = Reader.ReadByte();
						s = Reader.ReadUInt16();
						m.Position = new Point(s >> 5, s & 0x1F);
						m.SubPosition = Reader.ReadByte();
						m.Direction = Reader.ReadByte();
						m.Type = Reader.ReadByte();
						m.PictureIndex = Reader.ReadByte();
						m.MoveState = Reader.ReadByte();
						m.Pause = Reader.ReadByte();
						m.Weapon = Reader.ReadUInt16();
						m.PocketItem = Reader.ReadUInt16();

						Maze.Monsters.Enqueue(m);
					}
					#endregion
				}
				#endregion


				#region Scripts
				s = Reader.ReadUInt16();			// Script length
				Maze.Script = new Script(Reader.ReadBytes(s - 2));
				#endregion


				#region Messages
				while (Reader.BaseStream.Position < Maze.Hunks[2])
				{
					string str = SearchString();
					Maze.Messages.Add(str);
				}

				#endregion


				#region Triggers
				ushort triggercount = Reader.ReadUInt16();
				for (ushort i = 0; i < triggercount; i++)
				{
					Trigger t = new Trigger();
					s = Reader.ReadUInt16();
					t.Position = new Point((byte)(s & 0x1f), (byte)((s >> 5) & 0x1f));
					//t.Position = new Point((byte)((s >> 5) & 0x1f), (byte)(s & 0x1f));
					//t.Position = new Point(s >> 5, s & 0x1F);
					t.Flags = Reader.ReadUInt16();
					t.Offset = Reader.ReadUInt16();

					Maze.Triggers.Enqueue(t);
				}

				#endregion
			}


			Console.WriteLine(Maze.Script.Decompile());
		}

		#region Helpers

		/// <summary>
		/// Reads a string from the stream
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		private static string ReadString(byte length)
		{
			char[] buff = Reader.ReadChars(length);

			StringBuilder sb = new StringBuilder();
			for (byte i = 0; i < length; i++)
			{
				if (buff[i] == 0)
					break;

				sb.Append(buff[i]);
			}

			return sb.ToString();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private static string SearchString()
		{
			StringBuilder sb = new StringBuilder();
			byte c;
			while ((c = Reader.ReadByte()) != 0)
			{
				sb.Append((char)c);
			}

			return sb.ToString();
		}

		#endregion


		#region Properties

		/// <summary>
		/// 
		/// </summary>
		static BinaryReader Reader;


		/// <summary>
		/// 
		/// </summary>
		static public Maze Maze;

		#endregion
	}


	struct parts
	{
		public byte cps_x;
		public byte cps_y;
		public byte w;
		public byte h;
		public byte screen_x;
		public byte screen_y;
	}
}



/*
!!!! Rectangle.x & Rectangle.w needs to be multiplied by 8 !!


http://www.shikadi.net/moddingwiki/Eye_of_the_Beholder_maze_information_Format
Command codes

0xff (Set wall)
0xfe (Change wall)
0xfd (Open door)
0xfc (Close coor)
0xfb (Create monster)
0xfa (Teleport)
0xf9 (Steal small item)
0xf8 (Message)
0xf7 (Set flag)
0xf6 (Sound)
0xf5 (Clear flag)
0xf4 (Heal)
0xf3 (Damage)
0xf2 (Jump)
0xf1 (End code)
0xf0 (Return)
0xef (Call)
0xee (Conditions)
0xed (Item consume)
0xec (Change level)
0xeb (Give experience)
0xea (New item)
0xe9 (Launcher)
0xe8 (Turn)
0xe7 (Identify all items)
0xe6 (Encounters)
0xe5 (Wait)
0xe4 (Update screen)
0xe3 (Text menu)
0xe2 (Special window pictures)
*/
