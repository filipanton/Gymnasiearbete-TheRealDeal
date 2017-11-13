using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tilemapscript : MonoBehaviour {

    

	void Awake ()
    {


        GetComponent<TilemapCollider2D>().enabled = false;


        





    }
    private void Start()
    {
        GetComponent<TilemapCollider2D>().enabled = true;

    }
}
