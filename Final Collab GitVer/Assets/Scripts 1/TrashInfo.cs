using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashInfo : MonoBehaviour
{
    public TextMeshProUGUI trash;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        trash.text = "Trash Left: ";
    }
    public void StartAmount(int amount){
        counter = amount;
        trash.text = "Trash Left: " + counter;
    }

    public void setTrashNum(int numTrash)
    {
        //counter = numTrash;
    }

    public void Spawned(){
        counter--;
        trash.text = "Trash Left: " + counter;
    }

    public int GetTrash(){
        int temp = counter;
        return temp;
    }
}
