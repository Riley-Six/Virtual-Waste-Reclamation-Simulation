using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAssistant : MonoBehaviour
{
    Vector2 position;
    WaypointAssistant next { set; get; }
    
    // Start is called before the first frame update
    void Start(Vector2 positionIn)
    {
        position = positionIn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool Link(ref WaypointAssistant a) {
        if (a) {
            next = a;
            return true;
        }
        return false;
    }
}
