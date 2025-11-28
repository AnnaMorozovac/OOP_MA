using MazeGrid;

namespace Algorithms;

public interface IMazeAlgorithm
{
    Task CreateMaze(Grid grid);
}