using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptFunc : MonoBehaviour
{
    public string destination = "Level Select";

    public void GoTo()
    {
        Debug.Log("WORK?");
        SceneManager.LoadScene(destination);
    }

}
