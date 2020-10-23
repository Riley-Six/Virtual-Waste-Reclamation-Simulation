using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{

    public float speed;
    public float angle;



    void OnTriggerStay2D(Collider2D other)
    {
        
        Debug.Log(other.gameObject.name + " Sorted ");

        
        if (other.gameObject.name.Contains("Bottle") || other.gameObject.name.Contains("Cardboard") || other.gameObject.name.Contains("Jug") || other.gameObject.name.Contains("Can"))
        {
            //other.gameObject.transform.position = other.gameObject.transform.position + Vector3.down * speed;
            //other.gameObject.transform.Rotate(Vector3.right, 90);
            other.gameObject.transform.position = other.gameObject.transform.position + Vector3.up * speed;
        } else
        {
            other.gameObject.transform.position = other.gameObject.transform.position + Vector3.down * speed;
        }
        

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " Bye Bye Sorter ");

        //-7.5, 3.5
        //Debug.Log(Mathf.Round(other.gameObject.transform.position.x * 2) / 2);
        //Debug.Log(Mathf.Round(other.gameObject.transform.position.y * 2) / 2);

        //Vector2 center = new Vector2(Mathf.Round(other.gameObject.transform.position.x * 2) / 2, Mathf.Round(other.gameObject.transform.position.y * 2) / 2);
        //other.gameObject.transform.position = center;


    }
}
