using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disposal : MonoBehaviour
{
    //public GameObject healthBarSystem;
    public GameObject[] trash;
    public GameObject[] recycling;
    public int mode1trash2recycle;
    private int correct = 0;
    //public int startHealth;
    //public int currentHealth;


    void OnTriggerEnter2D(Collider2D junk)
    {

        Debug.Log("THUNK");
        if (mode1trash2recycle == 1)
        {
            //trash check for recycling
            for(int runner = 0; runner < recycling.Length; runner++)
            {
                if (junk.gameObject.name.Contains(recycling[runner].name.ToString())){
                    correct += 1;
                }
            }
            
        } else if (mode1trash2recycle == 2)
        {
            //recycling check for trash
            for (int runner = 0; runner < trash.Length; runner++)
            {
                if (junk.gameObject.name.Contains(trash[runner].name.ToString()))
                {
                    correct += 1;
                }
            }
        }

        if (correct != 0)
        {
            GameObject.Find("HealthBar").SendMessage("LoseHealth");
            GameObject.Find("Money").SendMessage("Earned", -5);
        } else
        {
            GameObject.Find("Money").SendMessage("Earned", 5);
        }
        correct = 0;


        Destroy(junk.gameObject);





    }


}
