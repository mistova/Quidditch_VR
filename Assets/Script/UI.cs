using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void RestartButton()	//This function is called by restart button
    {
        SceneManager.LoadScene(0); // This load scene which index 0.
    }
}
