using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SearchAlgorithm {

    public TileMapManager manager;

    //returns whether the passed tile is blocked
    public bool IsBlocked(Tile tile) {
        return TileType.Blocked == manager.TileValue(tile);
    }

    protected abstract Tile CalculatePath(Tile start, Tile goal);

    public Stack<Tile> GetPath(Tile start, Tile goal) {
        var tile = CalculatePath(start, goal);
        var stack = new Stack<Tile>();

        while (null != tile && !start.Equals(tile)) {
            stack.Push(tile);
            tile = tile.Parent;
        }

        return stack;
    }
}
