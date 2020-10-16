using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trivia : MonoBehaviour
{
    private bool shown = false;
    private ArrayList trivia = new ArrayList();
    public TextMeshProUGUI TriviaInfo;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        Read();
        TriviaInfo.text = "";
        button.SetActive(false);
        DeActivate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(){
        gameObject.SetActive(true);
        button.SetActive(true);
        Display(4);
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
        string t1, t2, t3, t4, t5;
        t1 = "Hello";
        t2 = "Heyyo";
        t3 = "Ohayo";
        t4 = "Konbanwa";
        t5 = "Kyoo wa kochi ga ii desu kana";
        trivia.Add(t1);
        trivia.Add(t2);
        trivia.Add(t3);
        trivia.Add(t4);
        trivia.Add(t5);
    }
 }
