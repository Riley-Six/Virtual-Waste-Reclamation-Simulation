using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class BinSelection : MonoBehaviour
{
    public GameObject glass;
    public GameObject juice;
    public GameObject plastic;
    public GameObject trash;
    public GameObject wrapper;
    public GameObject yard;
    public GameObject aluminum;
    public GameObject cardboard;
    private string type = "None";
    // Start is called before the first frame update
    void Start()
    {
        DeActivate();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        glass.SetActive(true);
        juice.SetActive(true);
        yard.SetActive(true);
        wrapper.SetActive(true);
        aluminum.SetActive(true);
        trash.SetActive(true);
        plastic.SetActive(true);
        cardboard.SetActive(true);
        Debug.Log(type);
    }

    public void DeActivate()
    {
        glass.SetActive(false);
        juice.SetActive(false);
        yard.SetActive(false);
        wrapper.SetActive(false);
        aluminum.SetActive(false);
        trash.SetActive(false);
        plastic.SetActive(false);
        cardboard.SetActive(false);
        gameObject.SetActive(false);
    }

    public void SetType(string choice){
        switch (choice){
            case "Juice":
                Debug.Log("Juice");
                type = "Juice";
                break;
            case "Yard":
                Debug.Log("Yard");
                type = "Yard";
                break;
            case "Wrapper":
                Debug.Log("Wrapper");
                type = "Wrapper";
                break;
            case "Plastic":
                Debug.Log("Plastic");
                type = "Plastic";
                break;
            case "Trash":
                Debug.Log("Trash");
                type = "Trash";
                break;
            case "Aluminum":
                Debug.Log("Aluminum");
                type = "Aluminum";
                break;
            case "Cardboard":
                Debug.Log("Cardboard");
                type = "Cardboard";
                break;
            case "Glass":
                Debug.Log("Glass");
                type = "Glass";
                break;
            default:
                break;
        }
    }

    public string GetType(){
        string temp = type;
        return temp;
    }
}
