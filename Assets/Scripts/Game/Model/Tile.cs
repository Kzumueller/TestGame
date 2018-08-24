using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//wrapper for a coordinate pair on the tile map
public class Tile : IComparable
{
    public int costSinceStart = 0;
    public int costToGoal = 0;

    public readonly int s, t;

    //parent tile used to construct linked lists to form paths
    private Tile parent;
    public Tile Parent {
        get {
            return parent;
        }
        set {
            parent = value;
            costSinceStart = parent.costSinceStart + 1;
        }
    }

    public static Tile up = new Tile(0, 1);
    public static Tile right = new Tile(1, 0);
    public static Tile down = new Tile(0, -1);
    public static Tile left = new Tile(-1, 0);

    public Tile(int s, int t)
    {
        this.s = s;
        this.t = t;
    }

    public int ManhattanDistance(Tile other) => s - other.s + t - other.t;

    public void CalculateCostTo(Tile goal) => costToGoal = ManhattanDistance(goal);

    public int CompareTo(object other) {
        if (null == other) return 1;
        var tile = other as Tile;

        return (costSinceStart + costToGoal).CompareTo(tile.costSinceStart + tile.costToGoal);
    }

    public static Tile operator +(Tile one, Tile other) {
        return new Tile(one.s + other.s, one.t + other.t);
    }

    //tiles are equal if their coordinates are the same
    public override bool Equals(object other) {
        if (null == other) return false;
        var tile = other as Tile;

        return (s == tile.s) && (t == tile.t);
    }

    // Happy now, VS?
    public override int GetHashCode() {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"Tile {s},{t}, cost since start: {costSinceStart}, cost to goal: {costToGoal}";
    }
}
