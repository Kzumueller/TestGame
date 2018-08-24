using System.Collections.Generic;

public class BreadthFirstSearch : SearchAlgorithm {

    protected override Tile CalculatePath(Tile start, Tile goal) {
        var candidates = new Queue<Tile>();
        var visited = new List<Tile>();

        candidates.Enqueue(start);
        visited.Add(start);

        while (0 < candidates.Count) {
            var tile = candidates.Dequeue();

            if (goal.Equals(tile)) {
                return tile;
            }

            VisitNeighbours(candidates, visited, tile);
        }

        return null;
    }

    private void VisitNeighbours(Queue<Tile> candidates, List<Tile> visited, Tile current) {
        Visit(candidates, visited, current, current + Tile.up);
        Visit(candidates, visited, current, current + Tile.right);
        Visit(candidates, visited, current, current + Tile.down);
        Visit(candidates, visited, current, current + Tile.left);
    }

    private void Visit(Queue<Tile> candidates, List<Tile> visited, Tile from, Tile next) {
        if (IsBlocked(next) || visited.Contains(next)) return;

        candidates.Enqueue(next);
        visited.Add(next);
        next.Parent = from;
    }
}
