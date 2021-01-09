using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    public Text text;
    void OnTriggerEnter(Collider other)
    {
        text.text = "Player Passed";
    }
}
