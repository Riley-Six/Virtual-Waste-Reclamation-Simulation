using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewGridRiley : MonoBehaviour
{
    public int collems;
    public int rows;
    public float tileSize;
    public float offsetX;
    public float offsetY;
    public GameObject tileTexture;
    public GameObject blankSpace;
    public GameObject StartTile;
    public GameObject Sorter;
    public GameObject trashDump;
    public GameObject recycleDump;

    public string mode;
    private int newCounter = 0;

    public int binCost;
    public int conveyCost;
    public int sortCost;
    //private GameObject<List<List>> gridCoordinates;
    //public List<List<GameObject>> mainGrid;

    // Start is called before the first frame update

    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    void Start()
    {
        GenerateGrid();
    }

    void modeSetter(string inModeSet)
    {
        mode = inModeSet;
    }

    private void GenerateGrid()
    {
        var counter = 0;

        for (int runnerX = -collems; runnerX < collems; runnerX++)
        {
            for (int runnerY = -rows; runnerY < rows; runnerY++)
            {
                GameObject tile;
                if ((runnerX == -collems) && (runnerY == -rows)) {
                    tile = (GameObject)Instantiate(StartTile, transform);
                }
                /*
                else if ((runnerX == collems-1) && runnerY == rows/-2)
                {
                    tile = (GameObject)Instantiate(recycleDump, transform);
                }
                else if ((runnerX == collems-1) && runnerY == rows/2)
                {
                    tile = (GameObject)Instantiate(trashDump, transform);
                }*/
                else
                {
                    tile = (GameObject)Instantiate(blankSpace, transform);
                    tile.name = "tempTile" + counter;
                }
                
                //tile.name = "tempTile" + counter;
                counter++;
                float xPos = runnerX * tileSize + offsetX;
                float yPos = runnerY * -tileSize + offsetY;
                tile.transform.position = new Vector2(xPos, yPos);
            }
        }
    }
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (mode == "convey")
            {
                if (hit && hit.collider.gameObject.name.Contains("tempTile"))
                {
                    GameObject.Find("Money").SendMessage("Earned", conveyCost);
                    print(hit.collider.name);
                    //StartCoroutine(conveyRotate());
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                    newTile.name = "Convey (Up)" + newCounter;
                    GameObject.Find(newTile.name).SendMessage("Direction", "Up");
                    newCounter++;
                    newTile.transform.position = center;
                    GameObject.Find(newTile.name).SendMessage("Direction", "Up");
                }
                else if (hit && hit.collider.gameObject.name.Contains("Convey (Up)"))
                {
                    print(hit.collider.name);
                    //StartCoroutine(conveyRotate());
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                    newTile.name = "Convey (Right)" + newCounter;
                    newCounter++;
                    newTile.transform.position = center;
                    GameObject.Find(newTile.name).SendMessage("Direction", "Right");
                }
                else if (hit && hit.collider.gameObject.name.Contains("Convey (Right)"))
                {
                    print(hit.collider.name);
                    //StartCoroutine(conveyRotate());
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                    newTile.name = "Convey (Down)" + newCounter;
                    newCounter++;
                    newTile.transform.position = center;
                    GameObject.Find(newTile.name).SendMessage("Direction", "Down");
                }
                else if (hit && hit.collider.gameObject.name.Contains("Convey (Down)"))
                {
                    print(hit.collider.name);
                    //StartCoroutine(conveyRotate());
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                    newTile.name = "Convey (Left)" + newCounter;
                    newCounter++;
                    newTile.transform.position = center;
                    GameObject.Find(newTile.name).SendMessage("Direction", "Left");


                }
                else if (hit && hit.collider.gameObject.name.Contains("Convey (Left)"))
                {
                    print(hit.collider.name);
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(blankSpace, transform);
                    newTile.name = "tempTile";
                    newCounter++;
                    newTile.transform.position = center;
                }




            }
            else if (mode == "sort")
            {
                if (hit && hit.collider.gameObject.name.Contains("tempTile"))
                {
                    GameObject.Find("Money").SendMessage("Earned", sortCost);
                    print(hit.collider.name);
                    //StartCoroutine(conveyRotate());
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(Sorter, transform);
                    newTile.name = "Sorter" + newCounter;
                    newCounter++;
                    newTile.transform.position = center;
                } 
                else if (hit && hit.collider.gameObject.name.Contains("Sorter"))
                {
                    print(hit.collider.name);
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(blankSpace, transform);
                    newTile.name = "tempTile";
                    newCounter++;
                    newTile.transform.position = center;
                }




            }
            else if (mode == "trash")
            {
                if (hit && hit.collider.gameObject.name.Contains("tempTile"))
                {
                    GameObject.Find("Money").SendMessage("Earned", binCost);
                    print(hit.collider.name);
                    //StartCoroutine(conveyRotate());
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(trashDump, transform);
                    newTile.name = "trashDump" + newCounter;
                    newCounter++;
                    newTile.transform.position = center;
                }
                else if (hit && hit.collider.gameObject.name.Contains("trashDump"))
                {
                    print(hit.collider.name);

                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(blankSpace, transform);
                    newTile.name = "tempTile";
                    newCounter++;
                    newTile.transform.position = center;
                }
            }
            else if (mode == "recycling")
            {
                if (hit && hit.collider.gameObject.name.Contains("tempTile"))
                {
                    GameObject.Find("Money").SendMessage("Earned", binCost);
                    print(hit.collider.name);
                    //StartCoroutine(conveyRotate());
                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(recycleDump, transform);
                    newTile.name = "recycleDump" + newCounter;
                    newCounter++;
                    newTile.transform.position = center;
                }
                else if (hit && hit.collider.gameObject.name.Contains("recycleDump"))
                {
                    print(hit.collider.name);

                    Vector3 center = hit.collider.gameObject.transform.position;
                    Destroy(hit.collider.gameObject);
                    GameObject newTile = (GameObject)Instantiate(blankSpace, transform);
                    newTile.name = "tempTile";
                    newCounter++;
                    newTile.transform.position = center;
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------------------------------------

            /*
        if (hit && hit.collider.gameObject.name.Contains("tempTile"))
        {
            print(hit.collider.name);

            //StartCoroutine(conveyRotate());
            Vector3 center = hit.collider.gameObject.transform.position;
            Destroy(hit.collider.gameObject);
            GameObject newTile = (GameObject)Instantiate(tileTexture, transform);

            newTile.name = "Convey (Up)" + newCounter;
            GameObject.Find(newTile.name).SendMessage("Direction", "Up");

            newCounter++;
            newTile.transform.position = center;
            GameObject.Find(newTile.name).SendMessage("Direction", "Up");

        } else if (hit && hit.collider.gameObject.name.Contains("Convey (Up)")){
            print(hit.collider.name);

            //StartCoroutine(conveyRotate());
            Vector3 center = hit.collider.gameObject.transform.position;
            Destroy(hit.collider.gameObject);
            GameObject newTile = (GameObject)Instantiate(tileTexture, transform);

            newTile.name = "Convey (Right)" + newCounter;

            newCounter++;
            newTile.transform.position = center;
            GameObject.Find(newTile.name).SendMessage("Direction", "Right");


        } else if (hit && hit.collider.gameObject.name.Contains("Convey (Right)"))
        {
            print(hit.collider.name);

            //StartCoroutine(conveyRotate());
            Vector3 center = hit.collider.gameObject.transform.position;
            Destroy(hit.collider.gameObject);
            GameObject newTile = (GameObject)Instantiate(tileTexture, transform);

            newTile.name = "Convey (Down)" + newCounter;
            //GameObject.Find(newTile.name).SendMessage("Direction", "Down");
            //newTile.name = "newTile";
            newCounter++;
            newTile.transform.position = center;
            GameObject.Find(newTile.name).SendMessage("Direction", "Down");


        } else if (hit && hit.collider.gameObject.name.Contains("Convey (Down)"))
        {
            print(hit.collider.name);

            //StartCoroutine(conveyRotate());
            Vector3 center = hit.collider.gameObject.transform.position;
            Destroy(hit.collider.gameObject);
            GameObject newTile = (GameObject)Instantiate(tileTexture, transform);

            newTile.name = "Convey (Left)" + newCounter;

            newCounter++;
            newTile.transform.position = center;
            GameObject.Find(newTile.name).SendMessage("Direction", "Left");


        } else if (hit && hit.collider.gameObject.name.Contains("Convey (Left)"))
        {
            print(hit.collider.name);

            //StartCoroutine(conveyRotate());
            Vector3 center = hit.collider.gameObject.transform.position;
            Destroy(hit.collider.gameObject);
            GameObject newTile = (GameObject)Instantiate(Sorter, transform);

            newTile.name = "Sorter" + newCounter;

            newCounter++;
            newTile.transform.position = center;


        } else if (hit && hit.collider.gameObject.name.Contains("Sorter"))
        {
            print(hit.collider.name);

            Vector3 center = hit.collider.gameObject.transform.position;
            Destroy(hit.collider.gameObject);
            GameObject newTile = (GameObject)Instantiate(blankSpace, transform);
            newTile.name = "tempTile";
            newCounter++;
            newTile.transform.position = center;

        } */



        }
    }

    void placer(string mode)
    {

    }

    


}