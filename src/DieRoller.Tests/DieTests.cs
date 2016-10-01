using Xunit;
using DieRollerLibrary;
using GameLibrary;
using Moq;

namespace DieRoller.Tests
{
    public class DieTests
    {
		[Fact]
		public void test_one_die_roll()
		{
			var dieRoller = new Mock<IDieRoller>();
			dieRoller.Setup(x => x.DieRoll())
				.Returns(2);

			var game = new Game(dieRoller.Object);
			var result = game.Play();
			Assert.Equal(2, result);
		}

		[Fact]
		public void test_die_result_from_game()
		{
			var dieRoller = new Mock<IDieRoller>();
			dieRoller.SetupSequence(x => x.DieRoll())
				.Returns(2)
				.Returns(5)
				.Returns(3);

			var game = new Game(dieRoller.Object);
			var result = game.Play();
			Assert.Equal(2, result);

			result = game.Play();
			Assert.Equal(5, result);

			result = game.Play();
			Assert.Equal(3, result);
		}

	    [Theory]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
	    public void test_attack_unsuccessful(int dieResult)
	    {
			var dieRoller = new Mock<IDieRoller>();
			dieRoller.Setup(x => x.DieRoll())
				.Returns(dieResult);

			var game = new Game(dieRoller.Object);
			var result = game.Attack();
		    Assert.False(result);
	    }

		[Theory]
		[InlineData(5)]
		[InlineData(6)]
		public void test_attack_successful(int dieResult)
		{
			var dieRoller = new Mock<IDieRoller>();
			dieRoller.Setup(x => x.DieRoll())
				.Returns(dieResult);

			var game = new Game(dieRoller.Object);
			var result = game.Attack();
			Assert.True(result);
		}

	    [Theory]
	    [InlineData(5, 4)]
	    [InlineData(5, 5)]
	    [InlineData(5, 6)]
	    [InlineData(6, 4)]
	    [InlineData(6, 5)]
	    [InlineData(6, 6)]
	    public void test_attack_damaged(int dieResult1, int dieResult2)
	    {
		    var dieRoller = new Mock<IDieRoller>();
		    dieRoller.SetupSequence(x => x.DieRoll())
			    .Returns(dieResult1)
				.Returns(dieResult2);

			var game = new Game(dieRoller.Object);
		    var result = game.Attack2();
		    Assert.Equal(AttackResult.Damaged, result);
	    }

		[Theory]
		[InlineData(5, 1)]
		[InlineData(5, 2)]
		[InlineData(5, 3)]
		[InlineData(6, 1)]
		[InlineData(6, 2)]
		[InlineData(6, 2)]
		public void test_attack_destroyed(int dieResult1, int dieResult2)
		{
			var dieRoller = new Mock<IDieRoller>();
			dieRoller.SetupSequence(x => x.DieRoll())
				.Returns(dieResult1)
				.Returns(dieResult2);

			var game = new Game(dieRoller.Object);
			var result = game.Attack2();
			Assert.Equal(AttackResult.Destroyed, result);
		}

		[Theory]
		[InlineData(1, 1)]
		[InlineData(2, 2)]
		[InlineData(3, 3)]
		[InlineData(4, 1)]
		public void test_attack_miss(int dieResult1, int dieResult2)
		{
			var dieRoller = new Mock<IDieRoller>();
			dieRoller.SetupSequence(x => x.DieRoll())
				.Returns(dieResult1)
				.Returns(dieResult2);

			var game = new Game(dieRoller.Object);
			var result = game.Attack2();
			Assert.Equal(AttackResult.Miss, result);
		}
	}
}
