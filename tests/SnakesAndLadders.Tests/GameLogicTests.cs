using System.Threading.Tasks;
using Xunit;

namespace SnakesAndLadders.Tests
{
    public class GameLogicTests
    {
        [Fact]
        public async Task Should_go_to_square1_on_start()
        {
            //Given
            var logic = new GameLogic();

            //When
            logic.Start();

            //Then
            Assert.Equal(1, logic.TokenPosition);
        }

        [Fact]
        public async Task Should_increment_position_when_dice_throwed()
        {
            //Given
            var logic = new GameLogic();
            logic.Start();

            //When
            logic.MoveToken(3);

            //Then
            Assert.Equal(4, logic.TokenPosition);
        }

        [Fact]
        public async Task Should_increment_position_on_subsequent_dice_throws()
        {
            //Given
            var logic = new GameLogic();
            logic.Start();

            //When
            logic.MoveToken(3);
            logic.MoveToken(4);

            //Then
            Assert.Equal(8, logic.TokenPosition);
        }

        [Fact]
        public async Task Should_roll_dice_between_1_and_6()
        {
            //Given
            var logic = new GameLogic();
            logic.Start();

            //When
            var result = logic.ThrowDice();

            //Then
            Assert.InRange(result, 1, 6);
        }

        [Theory]
        [InlineData(45)]
        [InlineData(3)]
        [InlineData(87)]
        public async Task Should_increment_position_by_dice_number(int number)
        {
            //Given
            var logic = new GameLogic();
            logic.Start();
            logic.MoveToken(number);

            var oldposition = logic.TokenPosition;

            //When
            logic.MoveToken(logic.ThrowDice(4));

            //Then
            Assert.Equal(oldposition + 4, logic.TokenPosition);
        }

        [Fact]
        public async Task Should_record_game_won_when_position_equals_100()
        {
            //Given
            var logic = new GameLogic();
            logic.Start();
            logic.MoveToken(96);

            //When
            logic.MoveToken(3);

            //Then
            Assert.True(logic.GameWon);
        }

        [Fact]
        public async Task Should_not_increment_position_if_dice_roll_greater_than_100()
        {
            //Given
            var logic = new GameLogic();
            logic.Start();
            logic.MoveToken(96);

            //When
            logic.MoveToken(4);

            //Then
            Assert.Equal(97, logic.TokenPosition);
            Assert.False(logic.GameWon);
        }
    }
}