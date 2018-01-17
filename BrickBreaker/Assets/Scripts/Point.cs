using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    public bool triggered = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        triggered = true;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
    }
}
