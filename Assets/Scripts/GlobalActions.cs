using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalActions : MonoBehaviour {

    public int currentScene;
    public int nextScene;
    private string[] scenes = { "devBox", "Level2" };
	// Update is called once per frame
	void Update () {
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
