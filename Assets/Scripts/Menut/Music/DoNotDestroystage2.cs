using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroystage2 : MonoBehaviour
{
    private Scene Scene;
    private Scene currentScene;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        Scene = currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "stage2")
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
