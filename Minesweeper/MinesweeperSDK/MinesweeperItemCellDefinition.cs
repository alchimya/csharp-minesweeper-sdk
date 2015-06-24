namespace Minesweeper.SDK
{
    //class to deinfe de item (cell) coordinate (row,col)
    public class MinesweeperItemCellDefinition{
        public int row { get; protected set; }
        public int col { get; protected set; }

        public MinesweeperItemCellDefinition(int row, int col) {
            this.row = row;
            this.col = col;
        }
    }
}
