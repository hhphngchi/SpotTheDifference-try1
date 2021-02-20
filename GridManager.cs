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
	public int tileWidth, tileHeight;
	public List<GameObject> gridPositions;

	// Use this for initialization
	void Start () {
		
		gridPositions = new List<GameObject>();
		 // ganerate the grid
		for (int x = 0; x < width; x += tileWidth)
		{
			for (int y = 0; y < height; y += tileHeight)
			{
				Vector3 originPosition = new Vector3(this.transform.position.x + x/2, this.transform.position.y + y/2, this.transform.position.z);
				GameObject pos = Instantiate(Tile, originPosition, Quaternion.identity);

				// adjust position's size
				x = tileWidth;
				y = tileHeight;
				gridPositions.Add(pos);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
