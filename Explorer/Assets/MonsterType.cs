using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
	public class MonsterType
	{

		public MonsterType()
		{
			AttackDice = new Dice[] { new Dice(), new Dice(), new Dice() };
			HPDice = new Dice(); //[] { new Dice(), new Dice() };
			attackList = new byte[5];
			unk5 = new byte[3];


			isAttack2 = false;
		}


		#region Properties

		public byte index;						 // +0
		public byte unk0;						 // +1
		public byte THAC0;						 // +2
		public byte unk1;						 // +3

		public Dice HPDice;						 // +4
		public byte numberOfAttacks;			 // +7
		public Dice[] AttackDice;				 // +16

		public ushort specialAttackFlag;		 // +18
		public ushort AbilitiesFlag;			 // +20
		public ushort unk2;						 // +22
		public ushort EXPGain;					 // +24

		public byte size;						 // +
		public byte attackSound;				 // +
		public byte moveSound;					 // +
		public byte unk3;						 // +

		public bool isAttack2;					 // +
		public byte distantAttack;				 // +
		public byte maxAttackCount;				 // +
		public byte[] attackList;				 // +

		public byte turnUndeadValue;			 // +
		public byte unk4;						 // +
		public byte[] unk5;						 // +

		#endregion
	}
}
