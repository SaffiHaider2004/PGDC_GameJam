using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform player;
    public int tileLength = 30;
    public int numberOfTiles = 6;
    private float spawnZ = 0;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z - 30 > spawnZ - numberOfTiles * tileLength)
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        Instantiate(tilePrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        spawnZ += tileLength;
    }
}
