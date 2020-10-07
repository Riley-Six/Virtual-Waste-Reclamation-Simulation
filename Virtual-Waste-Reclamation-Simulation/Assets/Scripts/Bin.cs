using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Bin : MonoBehaviour
{
    string info;
    // Start is called before the first frame update
    void Start()
    {
        info = "Sponsored by Raid Shadow Legends.";
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
