using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    public Text text;	//Text in UI
    void OnTriggerEnter(Collider other)// When we collide with player it runs.
    {
        text.text = "Player Passed";   // Set text "Player Passed" to Text in UI.
    }
}
