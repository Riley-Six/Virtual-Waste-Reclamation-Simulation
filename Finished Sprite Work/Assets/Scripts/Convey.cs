using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convey : MonoBehaviour
{
    public float speed;
    public float angle;
    Vector2 oldSpot;
    Vector2 NewSpot;
    public string direction;




    /*
    void OnCollisionStay(Collision obj)
    {
        float beltVelocity = speed * Time.deltaTime;
        obj.gameObject.GetComponent<Rigidbody2D>().velocity = beltVelocity * transform.forward;
    }*/
    /*
    void Update() {
        if (direction == "Down")
        {
            
            //other.gameObject.transform.Rotate(Vector3.right, 90);
        }
        else if (direction == "Right")
        {
            
            this.gameObject.transform.Rotate(Vector3.right, angle);
        }
        else if (direction == "Left")
        {
            
            this.gameObject.transform.Rotate(Vector3.right, angle * 2);
        }
        else if (direction == "Up")
        {
            
            this.gameObject.transform.Rotate(Vector3.right, angle * 3);
        }

    }*/

    void OnTriggerStay2D(Collider2D other)
    {
        //other.attachedRigidbody.AddForce(-0.1F * other.attachedRigidbody.velocity);
        Debug.Log(other.gameObject.name + " HELLO YOU ");

        //float step = 0.5f * Time.deltaTime;
        //Vector2 tempSpot = new Vector2(0, 0);
        if(direction == "Down")
        {
            other.gameObject.transform.position = other.gameObject.transform.position + Vector3.down * speed;
            //other.gameObject.transform.Rotate(Vector3.right, 90);
        } else if (direction == "Right")
        {
            other.gameObject.transform.position = other.gameObject.transform.position + Vector3.right * speed;
            //other.gameObject.transform.Rotate(Vector3.right, angle);
        } else if (direction == "Left")
        {
            other.gameObject.transform.position = other.gameObject.transform.position + Vector3.left * speed;
            //other.gameObject.transform.Rotate(Vector3.right, angle * 2);
        } else if (direction == "Up")
        {
            other.gameObject.transform.position = other.gameObject.transform.position + Vector3.up * speed;
            //other.gameObject.transform.Rotate(Vector3.right, angle);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " Bye Bye ");

        //-7.5, 3.5
        //Debug.Log(Mathf.Round(other.gameObject.transform.position.x * 2) / 2);
        //Debug.Log(Mathf.Round(other.gameObject.transform.position.y * 2) / 2);

        Vector2 center = new Vector2(Mathf.Round(other.gameObject.transform.position.x * 2) / 2, Mathf.Round(other.gameObject.transform.position.y * 2) / 2);
        other.gameObject.transform.position = center;


    }


    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trash In start");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Trash In start");
    }
    */

}
