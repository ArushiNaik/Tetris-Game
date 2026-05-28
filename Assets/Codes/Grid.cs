using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
    public static int w = 10;
    public static int h = 20;

    public static Tilemap lockedTilemap;

    void Awake()
    {
        lockedTilemap = GetComponent<Tilemap>();
    }

    public static bool InsideBorder(Vector3Int pos)
    {
        return pos.x >= 0 && pos.x < w && pos.y >= 0;
    }

    public static bool IsOccupied(Vector3Int pos)
    {
        return lockedTilemap.HasTile(pos);
    }

    public static bool IsRowFull(int y)
    {
        for (int x = 0; x < w; x++)
        {
            if (!lockedTilemap.HasTile(new Vector3Int(x, y, 0)))
                return false;
        }
        return true;
    }

    public static void DeleteRow(int y)
    {
        for (int x = 0; x < w; x++)
        {
            lockedTilemap.SetTile(new Vector3Int(x, y, 0), null);
        }
    }

    public static void DecreaseRow(int y)
    {
        for (int x = 0; x < w; x++)
        {
            Vector3Int from = new Vector3Int(x, y, 0);
            Vector3Int to = new Vector3Int(x, y - 1, 0);

            TileBase tile = lockedTilemap.GetTile(from);

            if (tile != null)
            {
                lockedTilemap.SetTile(to, tile);
                lockedTilemap.SetTile(from, null);
            }
        }
    }

    public static void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < h; i++)
        {
            DecreaseRow(i);
        }
    }

    public static void DeleteFullRows()
    {
        for (int y = 0; y < h; y++)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                y--;
            }
        }
    }
}