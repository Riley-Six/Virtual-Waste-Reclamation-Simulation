using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private string binInfo;
    private string sortInfo;
    private string splitInfo;
    private string convInfo;
    // Start is called before the first frame update
    void Start()
    {
        convInfo = "Hey";
        splitInfo = "whats";
        sortInfo = "up";
        binInfo = "Sponsored by Raid Shadow Legends";
    }

    public void binClick()
    {
        GameObject.Find("Info").GetComponent<Info>().changeInfo(binInfo);
    }
    public void sortClick()
    {
        GameObject.Find("Info").GetComponent<Info>().changeInfo(sortInfo);
    }
    public void splitClick()
    {
        GameObject.Find("Info").GetComponent<Info>().changeInfo(splitInfo);
    }
    public void convClick()
    {
        GameObject.Find("Info").GetComponent<Info>().changeInfo(convInfo);
    }
}
