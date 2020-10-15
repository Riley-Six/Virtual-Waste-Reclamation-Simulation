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
    private Money moneyComponent;
    // Start is called before the first frame update
    void Start()
    {
        convInfo = "Hey";
        splitInfo = "whats";
        sortInfo = "up";
        binInfo = "Sponsored by Raid Shadow Legends";
        infoComponent = info.GetComponent<Info>();
        moneyComponent = info.GetComponentInChildren<Money>();
    }

    public void convClick(){
        infoComponent.changeInfo(convInfo, Color.cyan);
        infoComponent.changeSprite(convSprite);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().SetSpawn("conveyer");
        if (moneyComponent.GetFunds() >= 10)
        {
            moneyComponent.Bought(10);
        }
    }
    public void splitClick(){
        infoComponent.changeInfo(splitInfo, Color.green);
        //infoComponent.changeSprite(splitSprite);
    }

    public void sortClick(){
        infoComponent.changeInfo(sortInfo, Color.blue);
        infoComponent.changeSprite(sortSprite);
        if (moneyComponent.GetFunds() >= 30)
        {
            moneyComponent.Bought(30);
        }
    }

    public void binClick(){
        infoComponent.changeInfo(binInfo, Color.red);
        infoComponent.changeSprite(binSprite);
        if(moneyComponent.GetFunds() >= 50){
            moneyComponent.Bought(50);
        }
    }
}
