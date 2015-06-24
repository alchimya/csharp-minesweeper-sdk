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

