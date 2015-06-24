namespace Minesweeper.SDK
{
    //mine generator helper: it generates a random number from 1 and cells
    using System;
    public class MinesweeperMineGenerator{
        private Random random;
        private int cells=0;

        public MinesweeperMineGenerator(int cells){
            this.random = new Random(DateTime.Now.Second);
            this.cells =cells;
        }
        public int make() {
            return random.Next(1, this.cells);
        }
    }
}
