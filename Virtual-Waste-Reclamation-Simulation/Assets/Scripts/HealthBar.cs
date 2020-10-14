using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI health;
    private int counter = 5;
    // Start is called before the first frame update
    void Start()
    {
        health.faceColor = (Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        LoseHealth();
    }

    public void LoseHealth(){
        health.text = counter.ToString("D2");
    }
}
