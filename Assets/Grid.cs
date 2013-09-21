using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	
	public 	Vector3		squareSize = Vector3.one;
	
	public 	Color		gridColor = Color.blue;
	public 	Color		mouseOverColor = Color.yellow;
	public 	Color		selectedColor = Color.white;
	
	public	int			width = 10;
	public	int			height = 10;
	
	private Location	mouseLocation = null;
	private Location	selectedLocation = null;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		updateMouseCoordinateOnGrid();
		
		if (Input.GetButtonUp("Select"))
			selectedLocation = mouseLocation;
		
	}
	
	void OnDrawGizmos() {
		drawGrid ();
	}
	
	// draw entire grid 
	void drawGrid() {
		Gizmos.color = gridColor;
		
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				drawSquare (new Location(x, y));
			}
		}
		
		Gizmos.color = mouseOverColor;
		if (mouseLocation != null)
			if (mouseLocation.x < width && mouseLocation.x >= 0)
				if (mouseLocation.y < height && mouseLocation.y >= 0)
					drawSquare (mouseLocation);
		
		Gizmos.color = selectedColor;
		if (selectedLocation != null)
			drawSquare (selectedLocation);
	}
	
	//	draw square on grid
	private void drawSquare(Location location) {
				Vector3 drawCoordinates = transform.position;
				drawCoordinates += new Vector3(location.x * squareSize.x, location.y * squareSize.y, 0);
				drawCoordinates += squareSize/2;
				Gizmos.DrawWireCube(drawCoordinates,squareSize);
	}
	
	//	update the mouse coordinates on the screen and highlight / select the appropriate square
	private void updateMouseCoordinateOnGrid() {
		Vector3 realMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		realMousePosition -= transform.position;
		
		mouseLocation = getGridCoordinate(realMousePosition);		
	}
	
	public Location getGridCoordinate(Vector3 worldCoordinate) {
		Location gridCoordinate = new Location();
		
		gridCoordinate.x = (int) (worldCoordinate.x / squareSize.x);
		gridCoordinate.y = (int) (worldCoordinate.y / squareSize.y);
		
		if (gridCoordinate.x < 0)
			gridCoordinate.x = 0;
		else if (gridCoordinate.x > width-1)
			gridCoordinate.x = width-1;
		
		if (gridCoordinate.y < 0)
			gridCoordinate.y = 0;
		else if (gridCoordinate.y > height-1)
			gridCoordinate.y = height-1;
		
		//System.Diagnostics.Debug.Print(gridCoordinate);
		
		return gridCoordinate;
	}
	
	//public bool addToGrid(int gridX, int gridY) {
	//	if 
	//}
	
}
