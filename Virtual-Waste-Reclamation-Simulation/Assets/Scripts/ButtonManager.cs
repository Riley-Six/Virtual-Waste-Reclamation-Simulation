using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Phase phaseComponent;
    private TrashInfo trashComponent;
    public GameObject finish;
    public GameObject trivia;
    // Start is called before the first frame update
    void Start()
    {
        convInfo = "Hey";
        splitInfo = "whats";
        sortInfo = "up";
        binInfo = "Sponsored by Raid Shadow Legends";
        infoComponent = info.GetComponent<Info>();
        moneyComponent = info.GetComponentInChildren<Money>();
        phaseComponent = info.GetComponentInChildren<Phase>();
        trashComponent = info.GetComponentInChildren<TrashInfo>();
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

    public void FinishClick(){
        trashComponent.Start(25);
        phaseComponent.SwitchPhase();
        trivia.GetComponent<Trivia>().Activate();
        finish.SetActive(false);
    }

    public void OkClick(){
        trivia.GetComponent<Trivia>().DeActivate();
    }
}
