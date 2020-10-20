using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI health;
    private int counter = 10;
    // Start is called before the first frame update
    void Start()
    {
        health.faceColor = (Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        health.text = counter.ToString("D2");
    }

    public void LoseHealth(){
        counter--;
    }

    public void Restart()
    {
        counter = 10;
    }

    public int GetHealth()
    {
        int temp = counter;
        return temp;
    }
}
