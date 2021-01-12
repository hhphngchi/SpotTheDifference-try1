using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int totalItems = 10;
    public List<GameObject> spawnList;
    public List<Vector3> takenPostions;
    public List<GameObject> takenItems;
    public GameObject grid;
    public GameObject toSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnList = new List<GameObject>();
        List<GameObject> gridTiles = grid.GetComponent<GridManager>().gridPositions;
        // find a random pos on the grid
        int posIndex = Random.Range(0, gridTiles.Count);
        GameObject tile = gridTiles[posIndex];

        Vector3 tilePos = tile.transform.position;
        // find a random object to spawn
        int itemIndex = 0;
        for (int i = 0; i < totalItems; i++)
        {
            itemIndex = Random.Range(0, spawnList.Count);
            toSpawn = spawnList[itemIndex];

            if (!takenPostions.Contains(tilePos) && !takenItems.Contains(toSpawn))
            {
                Instantiate(toSpawn, tilePos, Quaternion.identity);
                takenPostions.Add(tilePos);
                takenItems.Add(toSpawn);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
