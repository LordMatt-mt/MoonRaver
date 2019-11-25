using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    // Use this for initialization
    public GameObject LevelSelection;
    public GameObject Levels;
    public GameObject Exit;
    public GameObject Help;
    public GameObject NewGame;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject HelpScreen;
    void Start()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Exit.SetActive(true);
        Help.SetActive(true);
        NewGame.SetActive(true);
        Levels.SetActive(true);
        HelpScreen.SetActive(false);
    }

    // Update is called once per frame
    public void LevelSelectScene()
    {
        LevelSelection.SetActive(true);
        Exit.SetActive(false);
        Help.SetActive(false);
        NewGame.SetActive(false);
        Levels.SetActive(false);
        Level1.SetActive(true);
        Level2.SetActive(true);
        Level3.SetActive(true);
    }
    public void Back()
    {
        LevelSelection.SetActive(false);
        Exit.SetActive(true);
        Help.SetActive(true);
        NewGame.SetActive(true);
        Levels.SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Helps()
    {
        HelpScreen.SetActive(true);
    }

    public void Helpscreen()
    {
        HelpScreen.SetActive(false);
    }

    public void PlayNewGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void Level_1()
    {
        SceneManager.LoadScene("Intro");
    }
    public void Level_2()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level_3()
    {
        SceneManager.LoadScene("Level2");
    }
}
