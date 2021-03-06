using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private static GridSystem _instance = null;
    private int cols;
    private int rows;
    private readonly float tileSize;
    private Dictionary<Tuple<int, int>, Tile> grid;
    private static object locker = new object();
    public static GridSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    _instance = new GridSystem(26, 14, 1);
                }
            }
            return _instance;
        }
    }
    private GridSystem(int width, int height, float tileSize)
    {
        grid = new Dictionary<Tuple<int, int>, Tile>();
        cols = width;
        rows = height;
        this.tileSize = tileSize;
        for (int i=0; i<cols; i++)
        {
            for (int j=0; j<rows; j++)
            {
                Tuple<int, int> key = new Tuple<int, int>(i, j);
                Tile tile = new Tile(i * tileSize + tileSize / 2, j * tileSize + tileSize / 2);
                grid.Add(key, tile);
                Debug.DrawLine(new Vector2(i * tileSize, j * tileSize), new Vector2(i * tileSize, (j + 1) * tileSize), Color.white, 100f);
                Debug.DrawLine(new Vector2(i * tileSize, j * tileSize), new Vector2((i + 1) * tileSize, j * tileSize), Color.white, 100f);
            }
        }
    }
    public bool UseTile(Tile tile)
    {
        tile.UseTile();
        return true;
    }
    public bool ReturnTile(Tile tile)
    {
        tile.UnuseTile();
        return true;
    }
    public bool ExtendGrid(int x, int y)
    {
        if (x > cols && y > rows)
        {
            for (int i = cols; i < x; i++)
            {
                for (int j = rows; j < y; j++)
                {
                    Tuple<int, int> key = new Tuple<int, int>(i, j);
                    Tile tile = new Tile(i * tileSize + tileSize / 2, j * tileSize + tileSize / 2);
                    grid.Add(key, tile);
                    Debug.DrawLine(new Vector2(i * tileSize, j * tileSize), new Vector2(i * tileSize, (j + 1) * tileSize));
                    Debug.DrawLine(new Vector2(i * tileSize, j * tileSize), new Vector2((i + 1) * tileSize, j * tileSize));
                }
            }
            return true;
        }
        return false;
    }
    public bool GetTile(float x, float y, out Tile tile)
    {
        int i = (int)(x / tileSize);
        int j = (int)(y / tileSize);
        if (i >= cols || j >= rows || i < 0 || j < 0)
        {
            tile = null;
            return false;
        }
        Tuple<int, int> key = new Tuple<int, int>(i, j);
        tile = grid[key];
        return true;
    }
    public bool GetNeighborTile(int i, int j, Direction direction, out Tile tile)
    {
        if (direction == Direction.Up) j++;
        if (direction == Direction.Down) j--;
        if (direction == Direction.Left) i--;
        if (direction == Direction.Right) i++;
        if (i<0 || i>cols || j<0 || j>rows)
        {
            tile = null;
            return false;
        }
        Tuple<int, int> key = new Tuple<int, int>(i, j);
        tile = grid[key];
        return true;
    }
}
