using System;
using NUnit.Framework;
using Minesweeper.SDK;
namespace MinesweeperUnitTest {
    [TestFixture]
    public class MinesweeperGridTest {

        [Test]
        public void grid_make_items_test() {
            MinesweeperGrid gameGrid = new MinesweeperGrid(10, 10);
            gameGrid.makeGrid();
            Assert.True(gameGrid.items.Count == 100);
        }

        [Test]
        public void open_all_blocks_test() {
            MinesweeperGrid gameGrid = new MinesweeperGrid(10, 10);
            gameGrid.openAllCells();
            foreach (MinesweeperItem item in gameGrid.items) {
                Assert.True(item.type!= MinesweeperItemType.MinesweeperItemType_None);
            }
        }
        [Test]
        public void find_item_test() {
            int rows = 10;
            int cols = 10;
            MinesweeperGrid gameGrid = new MinesweeperGrid(rows, cols);
            gameGrid.makeGrid();
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    Assert.True(gameGrid.findItemAt(new MinesweeperItemCellDefinition(r,c))!=null);
                }
            }

        }

    }
}
