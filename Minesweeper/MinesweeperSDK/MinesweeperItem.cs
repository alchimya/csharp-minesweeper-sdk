namespace Minesweeper.SDK
{
    using System;

    //enum to define the item type
    public enum MinesweeperItemType{
        MinesweeperItemType_None = 0,
        MinesweeperItem_Empty = 1,
        MinesweeperItem_MineWarning = 2,
        MinesweeperItem_Mine = 3
    }
    //item type class
    public class MinesweeperItem
    {
        public Object tag { get; set;}
        public MinesweeperItemType type { get; set;}
        public Object value { get; set;}
        public MinesweeperItemCellDefinition cell { get; protected set;}

        public MinesweeperItem(MinesweeperItemCellDefinition cell){
            this.cell = cell;
        }

    }
}
