using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteGround : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase groundTile;
    public Transform player;
    public int renderDistance = 10;

    private Vector3Int previousPlayerCell;

    void Update()
    {
        Vector3Int playerCell = tilemap.WorldToCell(player.position);

        if (playerCell != previousPlayerCell)
        {
            ExtendGround(playerCell);
            previousPlayerCell = playerCell;
        }
    }

    void ExtendGround(Vector3Int playerCell)
    {
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                Vector3Int cellPosition = new Vector3Int(playerCell.x + x, playerCell.y + y, 0);

                if (!tilemap.HasTile(cellPosition))
                {
                    tilemap.SetTile(cellPosition, groundTile);
                }
            }
        }
    }
}
