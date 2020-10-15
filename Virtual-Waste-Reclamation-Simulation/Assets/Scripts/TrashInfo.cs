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
        trash.text = "Trash Left: " + counter;
    }

    // Update is called once per frame
    void Update()
    {
        trash.text = "Trash Left: " + counter;
    }

    public void Spawned(){
        counter--;
    }

    public int GetTrash(){
        int temp = counter;
        return temp;
    }
}
