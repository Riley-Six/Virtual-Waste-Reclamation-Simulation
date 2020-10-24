using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Phase : MonoBehaviour
{
    public TextMeshProUGUI phase;
    // Start is called before the first frame update
    void Start()
    {
        phase.text = "Build";
    }

    public void SwitchPhase(){
        phase.text = "Work";
    }
}
