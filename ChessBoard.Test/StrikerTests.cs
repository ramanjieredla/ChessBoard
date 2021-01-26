using ChessBoard.App;
using ChessBoard.Test.Mocks;
using Xunit;

namespace ChessBoard.Test
{
    public class StrikerTests
    {
        // Check if the number of moves taken increment when striker moves
        [Fact]
        public void Move()
        {
            var striker = new Striker(new MockBoard(), new MockConsoleWriter(), 3);

            striker.MoveLeft();

            Assert.Equal(1, striker.GetMovesTaken());
        }


        //Check if the number of lives decrement when player hit by Mine
        [Fact]
        public void ReduceLives()
        {
            int initialLives = 3, livesToDecrement = 1;

            var striker = new Striker(new MockBoard(), new MockConsoleWriter(), initialLives);

            striker.ReduceLives(livesToDecrement);

            Assert.Equal(initialLives - livesToDecrement, striker.GetLivesLeft());
        }

        // Check if striker alive/not based on number of lives
        [Fact]
        public void CheckIfAlive()
        {
            int initialLives = 3;

            var striker = new Striker(new MockBoard(), new MockConsoleWriter(), initialLives);

            striker.ReduceLives(1);

            Assert.True(striker.Alive());

            striker.ReduceLives(initialLives - 1);

            Assert.False(striker.Alive());
        }

        // Check if striker stats are set to initial values when reset
        [Fact]
        public void Reset()
        {
            int maximumLives = 3, livesToDecrement = 1;
            var striker = new Striker(new MockBoard(), new MockConsoleWriter());

            striker.ReduceLives(livesToDecrement);
            striker.MoveRight();

            Assert.NotEqual(maximumLives, striker.GetLivesLeft());
            Assert.NotEqual(0, striker.GetMovesTaken());

            striker.Reset();

            Assert.Equal(maximumLives, striker.GetLivesLeft());
            Assert.Equal(0, striker.GetMovesTaken());
        }
    }
}
