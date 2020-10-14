using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private string binInfo;
    private string sortInfo;
    private string splitInfo;
    private string convInfo;
    public Sprite convSprite;
    public Sprite sortSprite;
    public Sprite binSprite;
    //public Sprite splitSprite;
    public GameObject info;
    private Info infoComponent;
    // Start is called before the first frame update
    void Start()
    {
        convInfo = "Hey";
        splitInfo = "whats";
        sortInfo = "up";
        binInfo = "Sponsored by Raid Shadow Legends";
        infoComponent = info.GetComponent<Info>();
    }

    public void convClick(){
        infoComponent.changeInfo(convInfo, Color.cyan);
        infoComponent.changeSprite(convSprite);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().SetSpawn("conveyer");
    }
    public void splitClick(){
        infoComponent.changeInfo(splitInfo, Color.green);
        //infoComponent.changeSprite(splitSprite);
    }

    public void sortClick(){
        infoComponent.changeInfo(sortInfo, Color.blue);
        infoComponent.changeSprite(sortSprite);
    }

    public void binClick(){
        infoComponent.changeInfo(binInfo, Color.red);
        infoComponent.changeSprite(binSprite);
    }
}
