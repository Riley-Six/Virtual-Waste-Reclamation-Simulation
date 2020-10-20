using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Trivia : MonoBehaviour
{
    private ArrayList trivia = new ArrayList();
    public TextMeshProUGUI TriviaInfo;
    public GameObject button;
    public string filename;
    // Start is called before the first frame update
    void Start()
    {
        Read();
        TriviaInfo.text = "";
        Display(0);
        //DeActivate();
    }

    public void Activate(int num){
        gameObject.SetActive(true);
        button.SetActive(true);
        Display(num);
    }

    public void DeActivate(){
        button.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Display(int rng){
        string temp = null;
        int i = 0;
        foreach(string t in trivia){
            if (i == rng){
                temp = t;
                break;
            }
            i++;
        }
        TriviaInfo.text = temp;
    }

    private void Read() {
        string fileToParse = string.Format(Application.dataPath + "/Resources/" + filename + ".txt");
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";

            while((line = sr.ReadLine()) != null){
                trivia.Add(line);
            }
            sr.Close();
        }
    }
 }
