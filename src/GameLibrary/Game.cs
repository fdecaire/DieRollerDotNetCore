using DieRollerLibrary;

namespace GameLibrary
{
	public class Game
	{
		private IDieRoller _dieRoller;

		public Game(IDieRoller dieRoller)
		{
			_dieRoller = dieRoller;
		}

		public int Play()
		{
			return _dieRoller.DieRoll();
		}

		public bool Attack()
		{
			if (_dieRoller.DieRoll() > 4)
			{
				return true;
			}
			return false;
		}

		public AttackResult Attack2()
		{
			if (_dieRoller.DieRoll() > 4)
			{
				if (_dieRoller.DieRoll() > 3)
				{
					return AttackResult.Damaged;
				}
				return AttackResult.Destroyed;
			}
			return AttackResult.Miss;
		}
	}
}