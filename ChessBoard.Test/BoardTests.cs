using ChessBoard.App;
using ChessBoard.Test.Mocks;
using Xunit;

namespace ChessBoard.Test
{
    public class BoardTests
    {
        //Check if Active and Final boxes are correctly positioned
        [Fact]        
        public void Initialize()
        {
            int width = 8, height = 8;
            var board = new Board(new MockConsoleWriter());
            board.Initialize(width, height);
            var activeBox = board.GetActiveBox();
            var finalBox = board.GetFinalBox();

            Assert.Equal(typeof(Box), activeBox.GetType());
            Assert.Equal(0, activeBox.GetYPosition());
            Assert.True(activeBox.GetXPosition() >= 0 && activeBox.GetXPosition() < width);

            Assert.Equal(typeof(FinalBox), finalBox.GetType());
            Assert.Equal(height - 1, finalBox.GetYPosition());
            Assert.True(finalBox.GetXPosition() >= 0 && finalBox.GetXPosition() < width);

        }

        //Check if the number of boxes are correct and have correct labels
        [Fact]
        public void GenerateBoxes()
        {
            var boxes = new Board(new MockConsoleWriter()).GenerateBoxes(8, 8);

            Assert.Equal("A1", boxes[0, 0].GetId());
            Assert.Equal("H8", boxes[7, 7].GetId());
            Assert.Equal(8, boxes.GetLength(0));
            Assert.Equal(8, boxes.GetLength(1));
        }

        //CHeck if the Box is generated correctly
        [Fact]
        public void GenerateFinalBox()
        {
            //B5
            var box = new Board(new MockConsoleWriter()).GenerateFinalBox(1, 5);

            Assert.Equal(typeof(FinalBox), box.GetType());
            Assert.Equal("B5", box.GetId());
        }

        //Check if the moving boxes are correct
        [Fact]
        public void ShiftBox()
        {
            int width = 2, height = 2;

            var board = new Board(new MockConsoleWriter());

            board.Initialize(width, height);

            board.SetActiveBox(0, 0);
            Assert.True(board.GetActiveBox().GetId() == "A1");
            
            board.MoveBoxUp();
            Assert.True(board.GetActiveBox().GetId() == "A2");

            board.MoveBoxRight();
            Assert.True(board.GetActiveBox().GetId() == "B2");

            board.MoveBoxDown();
            Assert.True(board.GetActiveBox().GetId() == "B1");

            board.MoveBoxLeft();
            Assert.True(board.GetActiveBox().GetId() == "A1");
        }
    }
}
