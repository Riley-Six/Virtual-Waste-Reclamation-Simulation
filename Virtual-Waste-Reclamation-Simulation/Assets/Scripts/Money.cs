using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI money;
    private int counter = 100;
    // Start is called before the first frame update
    void Start()
    {
        money.text = counter.ToString();
        money.faceColor = new Color(0.0195f, 0.3773f, 0.0267f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}