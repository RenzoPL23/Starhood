using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateManager
{
    public static void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public static void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
