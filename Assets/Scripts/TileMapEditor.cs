using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

public class TileMapEditor : TileMapManager {

    public int width = 10;
    public int height = 10;

    //sets up members
    void Awake()
    {
        if (null == tileMap)
        {
            tileSize = obstacle.GetComponent<MeshFilter>().mesh.bounds.size;
            planeSize = new Vector3(tileSize.x * width, 0f, tileSize.z * height);
            transform.localScale = new Vector3(planeSize.x / 10f, 1f, planeSize.z / 10f);
            tiles = new TileType[width, height];
        }
        else
        {
            DrawTileMap();
        }
        
    }

    //finds and deletes all obstacles
    public void ClearObstacles() => GameObject.FindGameObjectsWithTag("Obstacle").ToList()
        .ForEach(obstacle => DestroyImmediate(obstacle));

    //saves the current state as a text file to be used in the game
    public void SaveTileMap()
    {
        var fileName = EditorUtility.SaveFilePanelInProject("Save Tile Map", "NewTileMap", "txt", "...");
        if (0 == fileName.Length) return;
        var stringBuilder = new StringBuilder();

        for (var t = 0; t < height; ++t)
        {
            for (var s = 0; s < width; ++s)
            {
                stringBuilder.Append(tiles[t, s]);
            }
            stringBuilder.Append(Environment.NewLine);
        }

        File.WriteAllText(fileName, stringBuilder.ToString());
    }

    //determines the clicked tile and places an obstacle there
    void OnMouseDown()
    {
        //the camera must have orthographic projection for this to work, otherwise it needs a depth parameter which is not included in Input.mousePosition
        var position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));  
        var tile = VectorToTile(position);
        if (TileType.Blocked == TileValue(tile)) { return; }

        var obstacleClone = Instantiate(obstacle, TileCenter(tile) + .5f * tileSize.y * Vector3.up, Quaternion.identity);
        obstacleClone.parent = transform;
        obstacleClone.tag = "Obstacle";
        tiles[tile.t, tile.s] = TileType.Blocked;
    }

    //draws "Clear" and "Save As" buttons
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 60, 30), "Clear"))
        {
            ClearObstacles();
        }

        if (GUI.Button(new Rect(10, 50, 60, 30), "Save As"))
        {
            SaveTileMap();
        }
    }
}
