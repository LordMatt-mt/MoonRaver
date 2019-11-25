using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public Canvas pauseMenu;

    //public GameObject Main_Menu;
    //public GameObject ResumeButton;
    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                pauseMenu.gameObject.SetActive(false);
                GameObject.Find("HandGunMapped").GetComponent<WeaponScript>().enabled = true;
                Time.timeScale = 1;
            }
            else
            {
                isPaused = true;
                pauseMenu.gameObject.SetActive(true);
                GameObject.Find("HandGunMapped").GetComponent<WeaponScript>().enabled = false;
                Time.timeScale = 0;
             
            }
      
        }
    }

    public void Resume()
    {
        //Cursor.visible = false;
        pauseMenu.gameObject.SetActive(false);
        GameObject.Find("HandGunMapped").GetComponent<WeaponScript>().enabled = true;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
       
    }
    public void Restart()
    {
        //Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("level2");
    }

}
