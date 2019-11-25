using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour {

    // Use this for initialization
    public Canvas gameOver;
    public GameObject Player;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().currentHealth >= 1)
        {
            gameOver.gameObject.SetActive(false);
            
        }
        else
        {
            gameOver.gameObject.SetActive(true);
            //Cursor.visible = true;
            GameObject.Find("HandGunMapped").GetComponent<WeaponScript>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            GameObject.Find("GameManager").GetComponent<CameraRotate>().enabled = false;
            GameObject.Find("GameManager").GetComponent<PauseMenu>().enabled = false;
            Player.GetComponent<MeshRenderer>().enabled = false;
      
        }
	}

        public void MainMenu()
        {
        SceneManager.LoadScene("MainMenu");
        }
        public void Restart()
         {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
