using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    GameObject Menu_Object;

    GameObject LevelSelect_Object;

    public void Start()
    {
        Menu_Object = GameObject.Find("Menu");

        LevelSelect_Object = GameObject.Find("Level Select");

        LevelSelect_Object.SetActive(false);
    }

    public void LevelSelectBtn()
    {

        Menu_Object.SetActive(false);

        LevelSelect_Object.SetActive(true);

    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
}
