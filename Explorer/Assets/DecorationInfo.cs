using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	public class DecorationInfo
	{
		public DecorationInfo()
		{
			Files = new DecorationFileName();
			WallMappings = new WallMapping();
		}

		public DecorationFileName Files;

		public WallMapping WallMappings;
	}
}
