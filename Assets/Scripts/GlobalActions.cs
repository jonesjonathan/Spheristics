using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalActions : MonoBehaviour {

    public int currentScene;
    public int nextScene;
    public Text timerText;
    private float timer = 0;
    private string[] scenes = { "devBox", "Level2" };
	// Update is called once per frame
	void Update () {
        //Timer
        timer += Time.deltaTime;
        timerText.text = timer.ToString("0.00") + "s";

		if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(scenes[currentScene]);
        }
	}

    public string[] getScenes()
    {
        return scenes;
    }
}
