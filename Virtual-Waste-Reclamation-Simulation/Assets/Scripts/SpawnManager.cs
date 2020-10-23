using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private string spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = "";   
    }

    public void SetSpawn(string ots){
        spawn = ots;
        Debug.Log(spawn);
    }

    public string GetObject(){
        string temp = spawn;
        return temp;
    }
}
