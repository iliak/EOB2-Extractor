using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
		/// <returns></returns>
		public string Decompile()
		{
			StringBuilder sb = new StringBuilder();

			ushort cursor = 0;
			while (cursor < ByteCode.Length)
			{
				byte opcode = ByteCode[cursor++];
				ScriptToken token = (ScriptToken)opcode;
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

						}
						break;
					// Close Door
					case ScriptToken.TOKEN_CLOSE_DOOR:
						{

						}
						break;
					// Create monster
					case ScriptToken.TOKEN_CREATE_MONSTER:
						{

						}
						break;
					// Teleport
					case ScriptToken.TOKEN_TELEPORT:
						{

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

						}
						break;
					// Set flag
					case ScriptToken.TOKEN_SET_FLAG:
						{

						}
						break;
					// Sound
					case ScriptToken.TOKEN_SOUND:
						{

						}
						break;
					// Clear flag
					case ScriptToken.TOKEN_CLEAR_FLAG:
						{

						}
						break;
					// Heal
					case ScriptToken.TOKEN_HEAL:
						{

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
				}

			}

			sb.AppendLine("test");

			return sb.ToString();
		}

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public byte[] ByteCode;

		#endregion
	}

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
}
