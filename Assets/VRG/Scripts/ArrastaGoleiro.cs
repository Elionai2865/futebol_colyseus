using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArrastaGoleiro : MonoBehaviour
{
	private Vector3 mOffset;
	private float mZCoord;

	public Camera myCam;

	void OnMouseDown()
	{
		mZCoord = myCam.WorldToScreenPoint(gameObject.transform.position).z;
		// Store offset = gameobject world pos - mouse world pos
		mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
	}

	private Vector3 GetMouseAsWorldPoint()
	{
		// Pixel coordinates of mouse (x,y)
		Vector3 mousePoint = Input.mousePosition;
		// z coordinate of game object on screen
		mousePoint.z = mZCoord;
		// Convert it to world points
		return myCam.ScreenToWorldPoint(mousePoint);
	}

	void OnMouseDrag()
	{
		if (GetMouseAsWorldPoint().x + mOffset.x >= 7.5f)
		{
			transform.position = new Vector3(7.5f, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else if (GetMouseAsWorldPoint().x + mOffset.x <= -7.5f)
		{
			transform.position = new Vector3(-7.5f, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else
		{
			transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}
