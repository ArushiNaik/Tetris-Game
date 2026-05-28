using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Group : MonoBehaviour
{
    public Tilemap fallingTilemap;
    public TileBase[] tiles; // 7 tiles (colored)

    public static float gameSpeed = 1f;
    float lastFall = 0;

    private Vector3Int pivot;
    private List<Vector3Int> cells;
    private TileBase currentTile;

    void Start()
    {
        pivot = new Vector3Int(Grid.w / 2, Grid.h - 2, 0);

        List<Vector3Int[]> shapes = new List<Vector3Int[]>
        {
            // I
            new Vector3Int[] {
                new Vector3Int(-1,0,0), new Vector3Int(0,0,0),
                new Vector3Int(1,0,0), new Vector3Int(2,0,0)
            },

            // O
            new Vector3Int[] {
                new Vector3Int(0,0,0), new Vector3Int(1,0,0),
                new Vector3Int(0,1,0), new Vector3Int(1,1,0)
            },

            // T
            new Vector3Int[] {
                new Vector3Int(0,0,0), new Vector3Int(-1,0,0),
                new Vector3Int(1,0,0), new Vector3Int(0,1,0)
            },

            // L
            new Vector3Int[] {
                new Vector3Int(0,0,0), new Vector3Int(-1,0,0),
                new Vector3Int(1,0,0), new Vector3Int(-1,1,0)
            },

            // J
            new Vector3Int[] {
                new Vector3Int(0,0,0), new Vector3Int(-1,0,0),
                new Vector3Int(1,0,0), new Vector3Int(1,1,0)
            },

            // S
            new Vector3Int[] {
                new Vector3Int(0,0,0), new Vector3Int(1,0,0),
                new Vector3Int(0,1,0), new Vector3Int(-1,1,0)
            },

            // Z
            new Vector3Int[] {
                new Vector3Int(0,0,0), new Vector3Int(-1,0,0),
                new Vector3Int(0,1,0), new Vector3Int(1,1,0)
            }
        };

        int i = Random.Range(0, shapes.Count);
        cells = new List<Vector3Int>(shapes[i]);
        currentTile = tiles[i]; // 🔥 THIS is your color

        Draw();

        if (!IsValid())
        {
            Debug.Log("GAME OVER");
            enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            TryMove(Vector3Int.left);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            TryMove(Vector3Int.right);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            TryRotate();

        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= gameSpeed)
        {
            if (!TryMove(Vector3Int.down))
            {
                LockPiece();
                FindAnyObjectByType<Spawner>().SpawnNext();
                enabled = false;
            }

            lastFall = Time.time;
        }
    }

    void Draw()
    {
        foreach (var c in cells)
        {
            Vector3Int pos = pivot + c;
            fallingTilemap.SetTile(pos, currentTile);
        }
    }

    void Clear()
    {
        foreach (var c in cells)
        {
            fallingTilemap.SetTile(pivot + c, null);
        }
    }

    bool TryMove(Vector3Int dir)
    {
        Clear();
        pivot += dir;

        if (IsValid())
        {
            Draw();
            return true;
        }

        pivot -= dir;
        Draw();
        return false;
    }

    void TryRotate()
    {
        Clear();

        List<Vector3Int> rotated = new List<Vector3Int>();

        foreach (var c in cells)
            rotated.Add(new Vector3Int(c.y, -c.x, 0));

        var old = cells;
        cells = rotated;

        if (!IsValid())
            cells = old;

        Draw();
    }

    bool IsValid()
    {
        foreach (var c in cells)
        {
            Vector3Int pos = pivot + c;

            if (!Grid.InsideBorder(pos)) return false;
            if (Grid.IsOccupied(pos)) return false;
        }
        return true;
    }

    void LockPiece()
    {
        foreach (var c in cells)
        {
            Vector3Int pos = pivot + c;
            Grid.lockedTilemap.SetTile(pos, currentTile);
        }

        Clear();
        Grid.DeleteFullRows();
    }
}