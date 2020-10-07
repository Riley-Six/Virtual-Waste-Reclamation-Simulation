using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Info : MonoBehaviour
{
    public TextMeshProUGUI info;
    // Start is called before the first frame update
    void Start()
    {
        info.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeInfo(string info)
    {
        this.info.text = info;
    }
}
