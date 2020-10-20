using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI money;
    private int funds = 100;
    // Start is called before the first frame update
    void Start()
    {
        money.text = funds.ToString();
        money.faceColor = new Color(0.0195f, 0.3773f, 0.0267f);
    }

    // Update is called once per frame
    void Update()
    {
        money.text = funds.ToString();
    }

    public void Bought(string item){
        switch (item)
        {
            case "Conveyer":
                funds -= 10;
                break;
            case "Bin":
                funds -= 20;
                break;
            case "Sorter":
                funds -= 50;
                break;
            default:
                break;
        }
    }

    public void Earned(int gain)
    {
        funds += gain;
    }

    public int GetFunds(){
        int temp = funds;
        return temp;
    }
}