using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrashInfo : MonoBehaviour
{
    public TextMeshProUGUI trash;
    private int counter = 27;
    // Start is called before the first frame update
    void Start()
    {
        trash.text = "Trash Left: ";
    }
    public void Start(int amount){
        counter = amount;
        trash.text = "Trash Left: " + counter;
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
