using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Conveyer : MonoBehaviour
{
    private string info;
    // Start is called before the first frame update
    void Start()
    {
        info = "Hey";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoSomething()
    {
        GameObject.Find("Info").GetComponent<Info>().changeInfo(info);
    }
}
