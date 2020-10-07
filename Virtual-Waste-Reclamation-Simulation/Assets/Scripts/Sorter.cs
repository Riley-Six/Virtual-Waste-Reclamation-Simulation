using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    string info;
    // Start is called before the first frame update
    void Start()
    {
        info = "up";
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
