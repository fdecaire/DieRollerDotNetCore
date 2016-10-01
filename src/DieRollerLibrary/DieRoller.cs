using System;

namespace DieRollerLibrary
{
	public class DieRoller : IDieRoller
	{
		private static Random _randomNumberGenerator = new Random(DateTime.Now.Millisecond);

		public int DieRoll()
		{
			return _randomNumberGenerator.Next() % 6;
		}
	}
}
