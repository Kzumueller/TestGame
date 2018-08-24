using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour {

    public TextAsset tileMap;
    public Transform obstacle;

    protected TileType[,] tiles;
    protected Vector3 tileSize;
    protected Vector3 planeSize;

    //returns 0 for accessible tiles, 1 for blocked tiles and out-of-range coordinates 
    public TileType TileValue(int s, int t)
        => (0 > s || tiles.GetLength(1) <= s || 0 > t || tiles.GetLength(0) <= t) 
        ? TileType.Blocked : tiles[t, s];

    //returns 0 for accessible tiles, 1 for blocked tiles
    public TileType TileValue(Tile tile) => TileValue(tile.s, tile.t);

    //returns the position of the center of the tile belonging to the passed coordinates  (s: vertical, t: horizontal)
    public Vector3 TileCenter(int s, int t) => new Vector3(
            (s + .5f) * tileSize.x,
            0f,
            (t + .5f) * tileSize.z
            ) - .5f * planeSize + transform.position;

    //returns the position of the center of the passed Tile
    public Vector3 TileCenter(Tile tile) => TileCenter(tile.s, tile.t);

    //turns a position on the grid into a Tile
    public Tile VectorToTile(Vector3 position) => new Tile(
            (int)Mathf.Floor((position.x - transform.position.x + .5f * planeSize.x) / tileSize.x),
            (int)Mathf.Floor((position.z - transform.position.z + .5f * planeSize.z) / tileSize.z)
            );

    //reads the provided tile map, parses it char by char and returns a 2D array of its lines and columns
    public TileType[,] ReadTileMap(TextAsset text)
    {
        var option = StringSplitOptions.RemoveEmptyEntries;
        var lines = tileMap.text.Split(Environment.NewLine.ToCharArray(), option);
        var lineCount = lines.Length;
        var columnCount = lines[0].ToCharArray().Length;
        var tiles = new TileType[lineCount, columnCount];

        Debug.Log(lineCount);
        Debug.Log(columnCount);

        for (var lineIndex = 0; lineIndex < lineCount; ++lineIndex)
        {
            var line = lines[lineIndex].ToCharArray();

            for (var columnIndex = 0; columnIndex < columnCount; ++columnIndex)
            {
                tiles[lineIndex, columnIndex] = (TileType) Char.GetNumericValue(line[columnIndex]);
            }
        }

        return tiles;
    }

    //sets up class members, scales them depending on obstacle and plane, and places obstacles
    void Awake()
    {
        if(null != tileMap) DrawTileMap();
    }

    public void DrawTileMap()
    {
        tiles = ReadTileMap(tileMap);

        tileSize = obstacle.transform.localScale;

        planeSize = new Vector3(
            tileSize.x * tiles.GetLength(1),
            0f,
            tileSize.z * tiles.GetLength(0)
        );

        transform.localScale = new Vector3(
            planeSize.x / 10f,
            1f,
            planeSize.z / 10f
        );

        for (var t = 0; t < tiles.GetLength(0); ++t)
        {
            for (var s = 0; s < tiles.GetLength(1); ++s)
            {
                if (TileType.Accessible == TileValue(s, t)) { continue; }

                var newObstacle = Instantiate(obstacle, TileCenter(s, t) + .5f * tileSize.y * transform.up, Quaternion.identity);
                newObstacle.parent = transform;
            }
        }
    }

    //calls DebugDrawGrid
    private void OnDrawGizmos()
    {
        DebugDrawGrid(transform.position - .5f * planeSize, planeSize, tileSize, Color.blue);
    }

    //draws a funny grid on the plane, visualizing the tile map
    public void DebugDrawGrid(Vector3 origin, Vector3 planeSize, Vector3 tileSize, Color color)
    {
        var width = planeSize.x;
        var height = planeSize.z;

        var numRows = (int) (planeSize.z / tileSize.z);
        var numCols = (int) (planeSize.x / tileSize.x);
        origin.y += .1f;

        for (var index = 0; index <= numRows; ++index)
        {
            var start = origin + index * tileSize.x * Vector3.forward;
            var end = start + width * Vector3.right;
            Debug.DrawLine(start, end, color);
        }

        for (var index = 0; index <= numCols; ++index)
        {
            var start = origin + index * tileSize.z * Vector3.right;
            var end = start + height * Vector3.forward;
            Debug.DrawLine(start, end, color);
        }
    }
}
