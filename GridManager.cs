using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridManager : MonoBehaviour {
	public int num_diffs = 5;
	public int num_total = 10;
	// grid width and height
	public int width, height;

	// placemat
	public GameObject Placemat;
	public int placematWidth, placematHeight;

	// Use this for initialization
	void Start () {
		Placemat[] gridPositions = new Placemat[](num_total);
		 // ganerate the grid
		for (int x = 0; x < width; x += placematWidth)
		{
			for (int y = 0; y < height; y += placematHeight)
			{
				Placemat pos = Instantiate(placemat, this.transform.position.x + x / 2, this.transform.position.y + y / 2);

				// adjust position's size
				x = placematWidth;
				y = placematHeight;
				gridPositions.add(pos);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
