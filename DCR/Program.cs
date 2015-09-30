using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace undcr
{
	/// <summary>
	/// 
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			List<MonsterGfxSides> monsters = new List<MonsterGfxSides>();
			string path = @"c:\eob2\";
			string filename = "cleric1";


			using (BinaryReader reader = new BinaryReader(File.Open(path + filename + ".dcr", FileMode.Open)))
			{
				short count = reader.ReadInt16();

				Console.WriteLine("{0} descriptor(s) found !", count);

				for (short i = 0; i < count; i++)
				{
					MonsterGfxSides def = new MonsterGfxSides();
					for (byte j = 0; j < 6; j++)
					{
						MonsterGfxPart part = new MonsterGfxPart();
						part.cps_x = reader.ReadByte();
						part.cps_y = reader.ReadByte();
						part.w = reader.ReadByte();
						part.h = reader.ReadByte();
						part.screen_x = reader.ReadByte();
						part.screen_y = reader.ReadByte();

						part.w *= 8;
						part.cps_x *= 8;
						def.Sides[j] = part;
					}

					monsters.Add(def);
				}

			}

			Bitmap bm = new Bitmap(320, 200);
			Graphics gfx = Graphics.FromImage(bm);
			foreach (var part in monsters)
			{
				for (byte j = 0; j < 6; j++)
				{
					MonsterGfxPart p = part.Sides[j];
					gfx.DrawRectangle(Pens.Red, new Rectangle(p.cps_x, p.cps_y, p.w, p.h));

				}

			}
			bm.Save(path + filename + "_dcr.png");
		}


	}


	/// <summary>
	/// 
	/// </summary>
	class MonsterGfxSides
	{
		public MonsterGfxPart[] Sides = new MonsterGfxPart[6];
	}


	/// <summary>
	/// 
	/// </summary>
	struct MonsterGfxPart
	{
		public byte cps_x;
		public byte cps_y;
		public byte w;
		public byte h;
		public byte screen_x;
		public byte screen_y;
	}
}
