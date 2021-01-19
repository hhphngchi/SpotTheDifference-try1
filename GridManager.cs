using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int num_diffs = 5;
	public int num_total = 10;

	// grid width and height
	public int width, height;

	// placemat
	public GameObject Tile;
	public int tileScale;
	public List<GameObject> gridPositions;

	public int totalItems = 10;
	public List<GameObject> spawnList;
	public List<Texture> textureList;

	private bool settingColor = true;

	private List<Color> colorList = new List<Color>()
	{
		 Color.red,
		 Color.green,
		 Color.yellow,
		 Color.magenta,
		 new Color(255F, 0F, 255F),
		 new Color(0F, 255F, 255F),
		 new Color(255F, 255F, 0F),
		 new Color(128F, 0F, 128F),
		 new Color(128F, 0F, 0F)
	};

	public List<Vector3> takenPostions;
	public List<GameObject> takenItems;
	private GameObject toSpawn;

	// Use this for initialization
	void Start()
	{
		gridPositions = new List<GameObject>();
		// ganerate the grid
		for (int x = 4; x < width; x++)
		{
			for (int z = 4; z < height; z++)
			{
				Vector3 originalPosition = new Vector3(x * tileScale, 0, z * tileScale);
				GameObject pos = Instantiate(Tile, originalPosition, Quaternion.identity);

				// add position into the list
				gridPositions.Add(pos);
			}
		}
		
		// find a random object to spawn
		int itemIndex = 0;
		for (int i = 0; i < totalItems; i++)
		{

			// find a random pos on the grid
			int posIndex = Random.Range(0, gridPositions.Count - 1);

			GameObject tile = gridPositions[posIndex];

			Vector3 tilePos = tile.transform.position;

			itemIndex = Random.Range(0, spawnList.Count - 1);
			toSpawn = spawnList[itemIndex];

			if (!takenPostions.Contains(tilePos))
			{			
				GameObject obj = Instantiate(toSpawn, tilePos, Quaternion.identity) as GameObject;
				if (settingColor)
                {
					obj.GetComponent<Renderer>().material.color = colorList[Random.Range(0, colorList.Count - 1)];
					settingColor = false;
				}
                else
                {
					obj.GetComponent<Renderer>().material.SetTexture("_MainTex", textureList[Random.Range(0, textureList.Count - 1)]);
					settingColor = true;
				}
				
				takenPostions.Add(tilePos);
				takenItems.Add(toSpawn);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
