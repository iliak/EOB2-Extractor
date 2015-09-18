using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace undcr
{
	class Program
	{
		static void Main(string[] args)
		{
			string filename = @"c:\eob2\guard2.dcr";

			Bitmap bm = new Bitmap(320, 200);
			
			using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{
				short count = reader.ReadInt16();

				Console.WriteLine("{0} descriptor(s) found !", count);

				parts parts = new parts();
				for(int i = 0; i < count; i++)
				{
					parts.cps_x = reader.ReadByte();
					parts.cps_y = reader.ReadByte();
					parts.w = reader.ReadByte();
					parts.h = reader.ReadByte();
					parts.screen_x = reader.ReadByte();
					parts.screen_y = reader.ReadByte();

					parts.w *= 8;
					parts.h *= 8;
				}

			}

			bm.Save(@"c:\eob2\guard2.png");
		}

		
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
