using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehavior
{
    public int totalItems = 10;
    public List<GameObject> spawnList;
    public List<GameObject> takenPostions;
    public List<GameObject> takenItems;
    public GridManager grid;

    // Start is called before the first frame update
    void Start()
    {
        spawnObjects()
    }

    // Find a random position on the grid
    Vector3 getRandomPositions()
    {
        int xRandom = 0
        int zRandom = 0
        Meshcollider c = grid.GetComponent<Meshcollider>();

        xRandom = (int)Random.Range(c.bounds.min.x, c.bounds.max.x);
        zRandom = (int)Random.Range(c.bounds.min.z, c.bounds.max.z);

        return new Vector3(xRandom, 0.0f, zRandom);
    }

    //Spawn a random object 
    public void spawnObjects()
    { 
        int randomIndex = 0;
        GameObject toSpawn;
        for (int i = 0; i < totalItems; i++)
        {
            randomIndex = Random.Range(0, spawnList);
            toSpawn = spawnList[randomIndex];
            Vector3 pos = getRandomPositions();

            if (!takenPostions.Contains(pos) && !takenItems.Contains(toSpawn))
            {
                Instantiate(toSpawn, pos, toSpawn.rotation);
                takenPostions.Add(pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
