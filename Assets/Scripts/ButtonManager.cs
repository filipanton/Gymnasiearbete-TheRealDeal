using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    GameObject Menu_Object;

    GameObject LevelSelect_Object;

    GameObject Finish_Object;

    public void Start()
    {
        Menu_Object = GameObject.Find("Menu");

        LevelSelect_Object = GameObject.Find("Level Select");

        LevelSelect_Object.SetActive(false);

        Finish_Object = GameObject.Find("Finish");
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

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
    }

    public void Level6()
    {
        SceneManager.LoadScene(6);
    }

    public void Level7()
    {
        SceneManager.LoadScene(7);
    }

    public void Finish()
    {
        SceneManager.LoadScene(0);
    }
}
