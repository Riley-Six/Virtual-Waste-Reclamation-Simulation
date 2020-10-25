using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private string binInfo;
    //private string sortInfo;
    private string splitInfo;
    private string convInfo;
    private Info infoComponent;
    private Phase phaseComponent;
    private TrashInfo trashComponent;
    private BinSelection bComponent;
    public Sprite convSprite;
    //public Sprite sortSprite;
    public Sprite binSprite;
    public Sprite splitSprite;
    public GameObject BinSelection;
    public GameObject info;
    public GameObject finish;
    public GameObject trivia;
    public GameObject glass;
    public GameObject juice;
    public GameObject plastic;
    public GameObject trash;
    public GameObject wrapper;
    public GameObject yard;
    public GameObject aluminum;
    public GameObject cardboard;
    // Start is called before the first frame update
    void Start()
    {
        convInfo = "Cost: $2\nThe Conveyer moves trash.";
        splitInfo = "Cost: $15\nRecyling goes UP, Trash goes DOWN";
        binInfo = "Cost: $10\nBlue for Recyling, Green for Trash.";
        infoComponent = info.GetComponent<Info>();
        phaseComponent = info.GetComponentInChildren<Phase>();
        trashComponent = info.GetComponentInChildren<TrashInfo>();
        bComponent = BinSelection.GetComponent<BinSelection>();
    }

    public void convClick(){
        infoComponent.changeInfo(convInfo, Color.cyan);
        infoComponent.changeSprite(convSprite);
        GameObject.Find("Grid Manager").SendMessage("modeSetter", "convey");

    }
    public void splitClick(){
        infoComponent.changeInfo(splitInfo, Color.black);
        infoComponent.changeSprite(splitSprite);
        GameObject.Find("Grid Manager").SendMessage("modeSetter", "sort");
    }

    public void binClick(){
        infoComponent.changeInfo(binInfo, Color.yellow);
        infoComponent.changeSprite(binSprite);
        //GameObject.Find("Grid Manager").SendMessage("modeSetter", "trash");
        bComponent.Activate();
        
    }

    public void FinishClick(){
        //trashComponent.StartGame(25);
        phaseComponent.SwitchPhase();
        trivia.GetComponent<Trivia>().Activate(1);

        GameObject.Find("BigS(Clone)").SendMessage("StartTheGame");

        finish.SetActive(false);
    }

    public void OkClick(){
        trivia.GetComponent<Trivia>().DeActivate();
    }

    public void RecycleClick()
    {
        GameObject.Find("Grid Manager").SendMessage("modeSetter", "recycling");
        //bComponent.SetType("Recycle");
        bComponent.DeActivate();
    }
    public void TrashClick()
    {
        //bComponent.SetType("Trash");    
        GameObject.Find("Grid Manager").SendMessage("modeSetter", "trash");
        bComponent.DeActivate();
    }

    /*public void TrashClick()
    {
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().SetSpawn("Trash");
        //bComponent.SetType("Trash");
        bComponent.DeActivate();
    }*/

    
    public void JuiceClick(){
        bComponent.SetType("Juice");
        bComponent.DeActivate();
    }

    public void WrapperClick()
    {
        bComponent.SetType("Wrapper");
        bComponent.DeActivate();
    }

    public void AluminumClick()
    {
        bComponent.SetType("Aluminum");
        bComponent.DeActivate();
    }
    //-------
    
    public void GlassClick()
    { 
        bComponent.SetType("Glass");
        bComponent.DeActivate();
    }
    public void YardClick()
    {
        bComponent.SetType("Yard");
        bComponent.DeActivate();
    }
    public void CardboardClick()
    {
        bComponent.SetType("Cardboard");
        bComponent.DeActivate();
    }
    public void PlasticClick()
    {
        bComponent.SetType("Plastic");
        bComponent.DeActivate();
    }
}
