using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public 	Vector3		squareSize = Vector3.one;
	
	public 	Color		gridColor = Color.blue;
	public 	Color		mouseOverColor = Color.yellow;
	public 	Color		selectedColor = Color.white;
	public	int			width = 10;
	public	int			height = 10;
	
	
	
	private int			currentMouseXOnGrid = -1;
	private int			currentMouseYOnGrid = -1;
	
	private int			currentSelectedX = -1;
	private int			currentSelectedY = -1;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		updateMouseCoordinateOnGrid();
	}
	
	void OnDrawGizmos() {
		drawGrid ();
	}
	
	void drawGrid() {
		Gizmos.color = gridColor;
		
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				drawSquare (x, y);
			}
		}
		
		Gizmos.color = mouseOverColor;
		if (currentMouseXOnGrid < width && currentMouseYOnGrid >= 0)
			if (currentMouseYOnGrid < height && currentMouseYOnGrid >= 0)
				drawSquare (currentMouseXOnGrid, currentMouseYOnGrid);
		
		Gizmos.color = selectedColor;
		if (currentSelectedX != -1)
			drawSquare (currentSelectedX, currentSelectedY);
	}
	
	private void drawSquare(int gridX, int gridY) {
				Vector3 drawCoordinates = transform.position;
				drawCoordinates += new Vector3(gridX * squareSize.x, gridY * squareSize.y, 0);
				drawCoordinates += squareSize/2;
				Gizmos.DrawWireCube(drawCoordinates,squareSize);
	}
	
	private void updateMouseCoordinateOnGrid() {
		Vector3 realMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		realMousePosition -= transform.position;
		
		currentMouseXOnGrid = (int) (realMousePosition.x / (squareSize.x));
		currentMouseYOnGrid = (int) (realMousePosition.y / (squareSize.y));
		
		if (Input.GetButton("Select")) {
			currentSelectedX = currentMouseXOnGrid;
			currentSelectedY = currentMouseYOnGrid;
		}			
	}
	
	//public bool addToGrid(int gridX, int gridY) {
	//	if 
	//}
	
}
