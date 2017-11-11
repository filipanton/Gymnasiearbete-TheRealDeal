using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelObject : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)


    {
        int currentscene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(currentscene);
    }
}
