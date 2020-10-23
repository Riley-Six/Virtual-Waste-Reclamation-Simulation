using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerCode : MonoBehaviour
{
    public int rows;
    public int collems;
    public float tileSize;
    public float offset;
    public GameObject tileTexture;
    public GameObject blankSpace;
    private int newCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();

    }

    private void GenerateGrid()
    {
        //GameObject refTile = (GameObject)Instantiate(Resources.Load("pixil-frame"));
        //Instantiate(tileTexture);
        var counter = 0;
        
        for(int runnerX = -rows; runnerX < rows; runnerX++)
        {
            for (int runnerY = -collems; runnerY < collems; runnerY++)
            {
                GameObject tile = (GameObject)Instantiate(blankSpace, transform);
                tile.name = "tempTile" + counter;
                counter++;
                float xPos = runnerY * tileSize + offset;
                float yPos = runnerX * -tileSize + offset -1;
                tile.transform.position = new Vector2(xPos, yPos);
                //Instantiate(tile);
                //string outing = xPos.ToString() + "-" + yPos.ToString();
                //Debug.Log(outing);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


            if (hit && hit.collider.gameObject.name.Contains("tempTile"))
            {
                print(hit.collider.name);

                Vector3 center = hit.collider.gameObject.transform.position;
                Destroy(hit.collider.gameObject);
                GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                //newTile.name = "newTile" + newCounter;
                newTile.name = "newTile";
                newCounter++;
                newTile.transform.position = center;

                //GameObject newTile = (GameObject)Instantiate(blankSpace, GameObject.Find(hit.collider.gameObject.name.position));
                //Destroy(GameObject.Find(hit.collider.gameObject.name));

                //Destroy(GameObject.Find(hit.collider.gameObject.name));
                //GameObject.Find(hit.collider.gameObject.name) = (GameObject)Instantiate(tileTexture, transform);
                //GameObject tempHolder = GameObject.Find(hit.collider.gameObject.name);
                //tempHolder = (GameObject)Instantiate(tileTexture, transform);
                //transform.position = new Vector2();
                //Vector3 tp = GameObject.Find(hit.collider.gameObject.name).positon;
                //Destroy(GameObject.Find(hit.collider.gameObject.name));
                //GameObject replacing = (GameObject)Instantiate(tileTexture, tp);
            }

            if (hit && hit.collider.gameObject.name.Contains("newTile"))
            {
                print(hit.collider.name);

                Vector3 center = hit.collider.gameObject.transform.position;
                Destroy(hit.collider.gameObject);
                GameObject newTile = (GameObject)Instantiate(blankSpace, transform);
                //newTile.name = "tempTile" + newCounter;
                newTile.name = "tempTile";
                newCounter++;
                newTile.transform.position = center;

                //GameObject newTile = (GameObject)Instantiate(blankSpace, GameObject.Find(hit.collider.gameObject.name.position));
                //Destroy(GameObject.Find(hit.collider.gameObject.name));

                //Destroy(GameObject.Find(hit.collider.gameObject.name));
                //GameObject.Find(hit.collider.gameObject.name) = (GameObject)Instantiate(tileTexture, transform);
                //GameObject tempHolder = GameObject.Find(hit.collider.gameObject.name);
                //tempHolder = (GameObject)Instantiate(tileTexture, transform);
                //transform.position = new Vector2();
                //Vector3 tp = GameObject.Find(hit.collider.gameObject.name).positon;
                //Destroy(GameObject.Find(hit.collider.gameObject.name));
                //GameObject replacing = (GameObject)Instantiate(tileTexture, tp);
            }



            /*
            if (Physics.Raycast(ray, out hit))
            {
                Collider2D bc = hit.collider2D as Collider2D;

                if (bc != null)
                {
                    Destroy(bc.gameObject);
                }
            }*/
        }
    }
    
}
