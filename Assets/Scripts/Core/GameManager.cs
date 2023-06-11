using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
     * Frist scene is the main one
     * Other ones are loaded into the main one
     */
    public static void LoadScenes(params string[] scene)
    {
        for(int i = 0; i < scene.Length; i++)
        {
            if(i == 0)
                SceneManager.LoadScene(scene[i]);
            else
                SceneManager.LoadScene(scene[i], LoadSceneMode.Additive);
        }
    }
}
