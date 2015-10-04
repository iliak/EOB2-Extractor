using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace Explorer
{
	/// <summary>
	/// 
	/// </summary>
	public class Maze
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		static public Maze FromFile(string filename)
		{
			Maze maze = new Maze();
			byte b;
			ushort s;

			#region Loading INF file
			using (BinaryReader reader = new BinaryReader(File.Open(filename + ".inf", FileMode.Open)))
			{

				// Hunk1 offset
				maze.Hunks[1] = reader.ReadUInt16();

				#region Sub level data
				for (byte sub = 0; sub < 2; sub++)
				{

					if (reader.BaseStream.Position < maze.Hunks[1])
					{
						MazeHeader header = new MazeHeader();

						// Chunk offsets
						header.NextHunk = reader.ReadUInt16();

						b = reader.ReadByte();
						if (b == 0xEC)
						{
							#region General informations
							header.MazeName = ReadString(reader, 13);
							header.VmpVcnName = ReadString(reader, 13);

							if (reader.ReadByte() != 0xFF)
								header.paletteName = ReadString(reader, 13);

							header.SoundName = ReadString(reader, 13);

							#endregion

							#region Door name & Positions + offset
							for (byte i = 0; i < 2; i++)
							{

								b = reader.ReadByte();
								if (b == 0xEC || b == 0xEA)
								{
									DoorInfo door = new DoorInfo();
									door.GfxName = ReadString(reader, 13);
									door.Id = reader.ReadByte();
									door.Type = reader.ReadByte();
									door.knob = reader.ReadByte();

									for (byte t = 0; t < 3; t++)
										door.DoorRectangle[t] = new Rectangle(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());

									for (byte t = 0; t < 2; t++)
										door.ButtonRectangles[t] = new Rectangle(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());

									for (byte t = 0; t < 2; t++)
										door.ButtonPositions[t] = new Point(reader.ReadInt16(), reader.ReadInt16());
									header.Doors[i] = door;
								}
							}
							#endregion

							// Max nomber of monster ??
							s = reader.ReadUInt16();

							#region Monsters graphics informations
							for (byte i = 0; i < 2; i++)
							{
								b = reader.ReadByte();
								if (b == 0xEC)
								{
									MonsterGFX gfx = new MonsterGFX();
									gfx.LoadProg = reader.ReadByte();
									gfx.unk0 = reader.ReadByte();
									gfx.Label = ReadString(reader, 13);
									gfx.unk1 = reader.ReadByte();
									header.MonsterGFX[i] = gfx;
								}
							}
							#endregion

							#region Monster definitions
							while ((b = reader.ReadByte()) != 0xFF)
							{
								MonsterType m = new MonsterType();
								m.index = b;
								m.unk0 = reader.ReadByte();
								m.THAC0 = reader.ReadByte();
								m.unk1 = reader.ReadByte();

								m.HPDice.Rolls = reader.ReadByte();
								m.HPDice.Sides = reader.ReadByte();
								m.HPDice.Base = reader.ReadByte();

								m.numberOfAttacks = reader.ReadByte();
								for (byte i = 0; i < 3; i++)
								{
									m.AttackDice[i] = new Dice(reader);
								}

								m.specialAttackFlag = reader.ReadUInt16();
								m.AbilitiesFlag = reader.ReadUInt16();
								m.unk2 = reader.ReadUInt16();
								m.EXPGain = reader.ReadUInt16();
								m.size = reader.ReadByte();
								m.attackSound = reader.ReadByte();
								m.moveSound = reader.ReadByte();
								m.unk3 = reader.ReadByte();

								b = (byte)reader.ReadByte();
								if (b != 0xff)
								{
									m.isAttack2 = true;
									m.distantAttack = reader.ReadByte();
									m.maxAttackCount = reader.ReadByte();

									for (byte i = 0; i < m.maxAttackCount; i++)
									{
										m.attackList[i] = reader.ReadByte();

										reader.ReadByte(); // Pad ???
									}
								}

								m.turnUndeadValue = reader.ReadByte();
								m.unk4 = reader.ReadByte();
								m.unk5[0] = reader.ReadByte();
								m.unk5[1] = reader.ReadByte();
								m.unk5[2] = reader.ReadByte();


								header.MonsterTypes.Add(m);
							}
							#endregion

							#region Wall decoration data
							b = reader.ReadByte();
							if (b != 0xFF)
							{
								ushort decorateblocks = reader.ReadUInt16();
								for (ushort i = 0; i < decorateblocks; i++)
								{
									DecorationInfo deco = new DecorationInfo();

									b = reader.ReadByte();
									if (b == 0xEC)
									{
										deco.Files = new DecorationFileName();
										deco.Files.GFXName = ReadString(reader, 13);
										deco.Files.DECName = ReadString(reader, 13);
									}
									else if (b == 0xFB)
									{
										deco.WallMappings = new WallMapping();
										deco.WallMappings.index = reader.ReadByte();
										deco.WallMappings.WallType = reader.ReadByte();
										deco.WallMappings.DecorationID = reader.ReadByte();
										deco.WallMappings.EventMask = reader.ReadByte();
										deco.WallMappings.Flags = reader.ReadByte();
									}

									header.Decorations.Add(deco);
								}
							}
							#endregion

							while (reader.ReadUInt32() != 0xFFFFFFFF)
							{
							}
						}

						maze.Headers[sub] = header;
					}

				}
				#endregion

				// Hunk2 offset
				maze.Hunks[2] = reader.ReadUInt16();


				#region Monsters
				b = reader.ReadByte();
				if (b != 0xff)
				{
					#region Monster timers
					while ((b = reader.ReadByte()) != 0xff)
					{
						maze.Timer.Enqueue(reader.ReadByte());
					}
					#endregion

					#region Monster descriptions
					for (byte i = 0; i < 30; i++)
					{
						Monster m = new Monster();
						m.Index = reader.ReadByte();
						m.TimeDelay = reader.ReadByte();
						s = reader.ReadUInt16();
						m.Location = Location.FromValue(s); // new Point(s >> 5, s & 0x1F);
						m.SubPosition = reader.ReadByte();
						m.Direction = reader.ReadByte();
						m.Type = reader.ReadByte();
						m.PictureIndex = reader.ReadByte();
						m.Phase = reader.ReadByte();
						m.Pause = reader.ReadByte();
						m.Weapon = reader.ReadUInt16();
						m.PocketItem = reader.ReadUInt16();

						maze.Monsters.Add(m);
					}
					#endregion
				}
				#endregion


				#region Scripts
				s = reader.ReadUInt16();            // Script length
				maze.Script = new Script(reader.ReadBytes(s - 2));
				#endregion


				#region Messages
				while (reader.BaseStream.Position < maze.Hunks[2])
				{
					string str = SearchString(reader);
					maze.Messages.Add(str);
				}

				#endregion


				#region Triggers
				ushort triggercount = reader.ReadUInt16();
				for (ushort i = 0; i < triggercount; i++)
				{
					Trigger t = new Trigger();
					s = reader.ReadUInt16();
					t.Location = Location.FromValue(s); // new Point((byte)(s & 0x1f), (byte)((s >> 5) & 0x1f));
														//t.Position = new Point((byte)((s >> 5) & 0x1f), (byte)(s & 0x1f));
														//t.Position = new Point(s >> 5, s & 0x1F);
					t.Flags = (TriggerFlag)reader.ReadUInt16();
					t.Offset = reader.ReadUInt16();

					maze.Triggers.Add(t);
				}

				#endregion
			}
			#endregion

			#region Load .MAZ file
			if (File.Exists(filename + ".maz"))
			{
				using (BinaryReader reader = new BinaryReader(File.Open(filename + ".maz", FileMode.Open)))
				{
					maze.Size = new Size(reader.ReadUInt16(), reader.ReadUInt16());
					maze.WallFaces = reader.ReadUInt16();

					maze.Blocks = new MazeBlock[maze.Size.Width, maze.Size.Height];

					for (byte y = 0; y < maze.Size.Height; y++)
					{
						for (byte x = 0; x < maze.Size.Width; x++)
						{
							maze.Blocks[x, y] = MazeBlock.FromFile(reader);
						}
					}
				}
			}
			#endregion

			return maze;
		}


		#region Helpers

		/// <summary>
		/// Reads a string from the stream
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		private static string ReadString(BinaryReader reader, byte length)
		{
			char[] buff = reader.ReadChars(length);

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
		private static string SearchString(BinaryReader reader)
		{
			StringBuilder sb = new StringBuilder();
			byte c;
			while ((c = reader.ReadByte()) != 0)
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
		public Queue<byte> Timer = new Queue<byte>();

		/// <summary>
		/// 
		/// </summary>
		public List<Monster> Monsters = new List<Monster>();

		/// <summary>
		/// 
		/// </summary>
		public MazeHeader[] Headers = new MazeHeader[2];

		/// <summary>
		/// 
		/// </summary>
		public ushort[] Hunks = new ushort[3];

		/// <summary>
		/// 
		/// </summary>
		public List<Trigger> Triggers = new List<Trigger>();

		/// <summary>
		/// 
		/// </summary>
		public List<string> Messages = new List<string>();

		/// <summary>
		/// 
		/// </summary>
		public Script Script;


		/// <summary>
		/// Maze size
		/// </summary>
		public Size Size;


		/// <summary>
		/// Number of side for a wall
		/// </summary>
		public ushort WallFaces;


		/// <summary>
		/// 
		/// </summary>
		public MazeBlock[,] Blocks;

		#endregion
	}
}
