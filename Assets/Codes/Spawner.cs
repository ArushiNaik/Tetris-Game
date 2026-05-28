using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public Tilemap fallingTilemap;
    public TileBase[] tiles; // 7 colored tiles

    public void SpawnNext()
    {
        GameObject obj = new GameObject("Tetromino");

        Group g = obj.AddComponent<Group>();
        g.fallingTilemap = fallingTilemap;
        g.tiles = tiles; // 🔥 IMPORTANT
    }

    void Start()
    {
        SpawnNext();
    }
}