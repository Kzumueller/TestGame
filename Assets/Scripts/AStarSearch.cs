using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AStarSearch : SearchAlgorithm
{
    protected override Tile CalculatePath(Tile start, Tile goal) {
        var candidates = new PriorityQueue<Tile>();
        var visited = new List<Tile>();
        candidates.Enqueue(start);

        while (0 < candidates.Count) {
            var tile = candidates.Dequeue();

            if (goal.Equals(tile))
                return tile;

            VisitNeighbours(candidates, visited, tile, goal);
            visited.Add(tile);
        }

        return null;
    }

    public void VisitNeighbours(PriorityQueue<Tile> candidates, List<Tile> visited, Tile current, Tile goal) {
        Visit(candidates, visited, current, goal, current + Tile.up);
        Visit(candidates, visited, current, goal, current + Tile.right);
        Visit(candidates, visited, current, goal, current + Tile.down);
        Visit(candidates, visited, current, goal, current + Tile.left);
    }

    public void Visit(PriorityQueue<Tile> candidates, List<Tile> visited, Tile from, Tile goal, Tile next) {
        if (IsBlocked(next) || visited.Contains(next)) return;

        next.Parent = from;
        next.CalculateCostTo(goal);
        var index = candidates.IndexOf(next);

        if (-1 != index) {
            var old = candidates[index];
            if (0 > next.CompareTo(old)) {
                old.Parent = from;
            }
        }
        else {
            candidates.Enqueue(next);
        }
    }
}
