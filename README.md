# csharp-minesweeper-sdk
A class set to solve the logic of the famous game Minesweeper :)

# What is this?
Did you even play to Minesweeper?
<br/>
Wtih this project I solved the logic of this game by developing a class set.
<br/>
If you need  more information about this game, you can refer to wikipedia
<br/>
https://en.wikipedia.org/wiki/Minesweeper_(video_game)

<br/>
![ScreenShot](https://raw.github.com/alchimya/csharp-minesweeper-sdk/master/Screenshot/Screenshot_01.png)
![ScreenShot](https://raw.github.com/alchimya/csharp-minesweeper-sdk/master/Screenshot/Screenshot_02.png)

# Development Strategy
I developed this project by splitting the presentation of the game (front-end) by the game logic (back-end).
<br>
By using this strategy, I developed a sort of SDK (see MinesweeperSDK class library project) and actually we can use it  with different .Net environment: we don't are "locked" around UI elements or components.
<br/>
With this SDK, we can implement the same game, for example, as WPF application, WCF service, ASP.NET MVC application and so on.
<br/>
The integration of this "backend" is very easy!

# Tech Specifications and Requirements
.NET Framework 4.5
<br/>
Visual Studio 2013 Community
<br/>
NUnit framework
<br/>
lowerCamelCase coding style

# Game logic
I think that the main issue of his game is finding the adjacent mines and the adjacent empty cells around an item.
<br/>
In both cases we have to consider that at most each cell (item) could be surrounded by eight items (cells).
<br/>
If we consider a 4x4 grid (matrix) a cell C defined by a X,Y coordinates it will be surrounded by the following cells:
<br/>
![ScreenShot](https://raw.github.com/alchimya/csharp-minesweeper-sdk/master/Screenshot/Screenshot_03.png)
<br/>
In other words we can find the adjacent cells of an item by translating a point on the x and y axis.

# SDK Classes
- MinesweeperItemCellDefinition
It represents a cell, defined by a pair (int) values that indentify row and colum.
<br/>
To create a new instance is required to pass row and col as parameters of the constructor:
```cs
public MinesweeperItemCellDefinition(int row, int col)
```

- MinesweeperItem
It represents the "atomic" element of the grid game.
<br/>
To create a new instance is required to pass a MinesweeperItemCellDefinition instance as parameter of the constructor.
```cs
public MinesweeperItem(MinesweeperItemCellDefinition cell)
```
Within the class is exposed an enum that defines the possible kind of an item.
<br/>
```cs
public enum MinesweeperItemType{
        MinesweeperItemType_None = 0,
        MinesweeperItem_Empty = 1,
        MinesweeperItem_MineWarning = 2,
        MinesweeperItem_Mine = 3
    }
```
Each item can be defined as
- Mine
- Warning Mines Indicator
- Empty cell
- None (default)
MinesweeperItem has the following attributes:
```cs
//useful to store user info data
public Object tag { get; set;}
//allows to set the item type
public MinesweeperItemType type { get; set;}
//allows to store a value
public Object value { get; set;}
//allows to set cell coordinates
public MinesweeperItemCellDefinition cell { get; protected set;}	
```

- MinesweeperMineGenerator
This is an helper class and it helps us to generate a random number between 1 and number of cells (generally rows*cols or however a total elements of a matrix).
<br/>
How to use:
<br/>
1) create a new instance of the class by passing into the constructor the number of the cells
```cs
public MinesweeperMineGenerator(int cells)
```
2) to make a random mine cell, call the method make
```cs
public int make()
```

- MinesweeperGrid
This class represents the core of the SDK an it allows to make a grid game system with rows*cols items, and it helps, automatically, to define and dispose, randomly, mines on the grid.
<br/>
To create a new instance you can use two constructors:
```cs
public MinesweeperGrid(int rows, int cols)
public MinesweeperGrid(int rows, int cols, int maxMines)
```
As you can see, in both cases is needed to pass rows and cols of the grid (matrix) and optionally you can also define how many mines you want to place on your grid.
<br/>
If you don't pass the number of mines, the system will place rows-1 mines.
<br/>
In a next version maybe we can suppose to implement a calculation algorithm, for instance, based on the number of the cell.
<br/>
Class exposes the following behavior.
<br/>
<b>Properties:</b>
```cs
//returns the number of grid rows
public int rows { get; protected set; }
//returns the number of grid columns
public int cols { get; protected set; }	
//returns then number of max mines for the games
public int maxMines { get; protected set; }	
//returns a list of MinesweeperItem: it represents all items (cells) of the game grid
public List<MinesweeperItem> items { get; protected set; }	
```
<b>Methods:</b>
```cs
//With this method you can implement all the game behavior 
//If the item will be a mine,then will be raised a game over event 
//and all cells will be opened, otherwise it will find all the item's adjacent cells
public void evaluateItem(MinesweeperItem item)

//it allows to make the game grid and it, automatically and randomly, will place the mines
public void makeGrid()	

//This method is useful when we are in a "game over" mode it will "open" 
//all cells with a proper value (empty, mine number warning, mine)
public void openAllBlocks()	

//With this method you can discover
//a) how many adjacent mines are around the input method item
//b) how many adjacent empty cells are around the input method item
public void setAdjacentCells(MinesweeperItem item)

//Allows to find an item by cell coordinates (row and col)
public MinesweeperItem findItemAt(MinesweeperItemCellDefinition cell)	
```

# Event System
MinesweeperGrid works around a sort of messaging system implemented with a series of events exposed by the class.
<br/>
MinesweeperGrid exposes the following events defined by delegates methods:
<b>itemAdded</b>
<br>
this event will be raised when a new item (cell) will be added.
```cs
public event MinesweeperItemAdded itemAdded;
public delegate void MinesweeperItemAdded(MinesweeperItem item);
```

<b>itemMineAdded</b>
<br>
this event will be raised when a "mine" item will be added. 
```cs
public event MinesweeperItemMineAdded itemMineAdded;
public delegate void MinesweeperItemMineAdded(MinesweeperItem item);
```

<b>loadingCompleted</b>
<br>
this event will be raised when the grid game will be completely loaded. 
```cs
public event MinesweeperLoadingCompleted loadingCompleted;
public delegate void MinesweeperLoadingCompleted(List<MinesweeperItem> items);
```

<b>cellOpeningCompleted</b>
<br>
this event will be raised when a new item will be open as empty or mine cell. 
```cs
public event MinesweeperCellOpeningCompleted cellOpeningCompleted;
public delegate void MinesweeperCellOpeningCompleted(MinesweeperItem item);
```

<b>gameOver</b>
<br>
this event will be raised when item is a mine. 
```cs
public event MinesweeperGameOver gameOver;
public delegate void MinesweeperGameOver(MinesweeperItem item);
```

<b>errorOccurred</b>
<br>
this event will be raised when an error occurs 
```cs
public event MinesweeperError errorOccurred;
public delegate void MinesweeperError(Exception ex);
```
