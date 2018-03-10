using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movinglava : MonoBehaviour {

    public GameObject platform;

    public float moveSpeed;

    public Transform currentPoint;

    public Transform[] points;

    public int pointSelection;

	void Start ()
    {
        currentPoint = points[pointSelection];

	}
	
	
	void Update ()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
	}
}
