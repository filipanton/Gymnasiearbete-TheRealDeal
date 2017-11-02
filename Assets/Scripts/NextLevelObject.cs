using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelObject : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
