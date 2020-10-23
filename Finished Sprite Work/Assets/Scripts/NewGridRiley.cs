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
    public GameObject Dump;
    private int newCounter = 0;
    //private GameObject<List<List>> gridCoordinates;
    public List<List<GameObject>> mainGrid;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
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
                else if ((runnerX == collems-1) && runnerY == rows/-2)
                {
                    tile = (GameObject)Instantiate(Dump, transform);
                }
                else if ((runnerX == collems-1) && runnerY == rows/2)
                {
                    tile = (GameObject)Instantiate(Dump, transform);
                }
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


            if (hit && hit.collider.gameObject.name.Contains("tempTile"))
            {
                print(hit.collider.name);
                //conveyRotate();
                //while (!Input.GetKeyDown(KeyCode.Return)) yield;
                StartCoroutine(conveyRotate());
                Vector3 center = hit.collider.gameObject.transform.position;
                Destroy(hit.collider.gameObject);
                GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                //newTile.name = "Convey (" + newCounter + ")";
                //newTile.Direction("Up");
                newTile.name = "Convey (Up)" + newCounter;
                GameObject.Find(newTile.name).SendMessage("Direction", "Up");
                //newTile.name = "newTile";
                newCounter++;
                newTile.transform.position = center;
                GameObject.Find(newTile.name).SendMessage("Direction", "Up");

                //conveyRotate();
                /*
                if (Input.GetKeyUp(KeyCode.W))
                {
                    newTile.transform.Rotate(Vector3.forward * 90 * Random.Range(0, 4));
                }
                */
                //newTile.transform.Rotate(Vector3.forward*90*Random.Range(0, 4));
            } else if (hit && hit.collider.gameObject.name.Contains("Convey (Up)")){
                print(hit.collider.name);
                //conveyRotate();
                //while (!Input.GetKeyDown(KeyCode.Return)) yield;
                StartCoroutine(conveyRotate());
                Vector3 center = hit.collider.gameObject.transform.position;
                Destroy(hit.collider.gameObject);
                GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                //newTile.name = "Convey (" + newCounter + ")";
                //newTile.Direction("Up");
                newTile.name = "Convey (Right)" + newCounter;
                //GameObject.Find(newTile.name).SendMessage("Direction", "Right");
                //newTile.name = "newTile";
                newCounter++;
                newTile.transform.position = center;
                GameObject.Find(newTile.name).SendMessage("Direction", "Right");


            } else if (hit && hit.collider.gameObject.name.Contains("Convey (Right)"))
            {
                print(hit.collider.name);
                //conveyRotate();
                //while (!Input.GetKeyDown(KeyCode.Return)) yield;
                StartCoroutine(conveyRotate());
                Vector3 center = hit.collider.gameObject.transform.position;
                Destroy(hit.collider.gameObject);
                GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                //newTile.name = "Convey (" + newCounter + ")";
                //newTile.Direction("Up");
                newTile.name = "Convey (Down)" + newCounter;
                //GameObject.Find(newTile.name).SendMessage("Direction", "Down");
                //newTile.name = "newTile";
                newCounter++;
                newTile.transform.position = center;
                GameObject.Find(newTile.name).SendMessage("Direction", "Down");


            } else if (hit && hit.collider.gameObject.name.Contains("Convey (Down)"))
            {
                print(hit.collider.name);
                //conveyRotate();
                //while (!Input.GetKeyDown(KeyCode.Return)) yield;
                StartCoroutine(conveyRotate());
                Vector3 center = hit.collider.gameObject.transform.position;
                Destroy(hit.collider.gameObject);
                GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                //newTile.name = "Convey (" + newCounter + ")";
                //newTile.Direction("Up");
                newTile.name = "Convey (Left)" + newCounter;
                //GameObject.Find(newTile.name).SendMessage("Direction", "Left");
                //newTile.name = "newTile";
                newCounter++;
                newTile.transform.position = center;
                GameObject.Find(newTile.name).SendMessage("Direction", "Left");


            } else if (hit && hit.collider.gameObject.name.Contains("Convey (Left)"))
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
    }

    IEnumerator conveyRotate()
    {
        
        while (!Input.GetKeyDown(KeyCode.Space))
        {

            yield return null;
        }
        /*
        for (; ; )
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //gameController.minusQuestion‌​Score();
                break;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                //gameController.addQuestionSc‌​ore();
                break;
            }
            yield return null;
        }*/

        //yield return new WaitForSeconds(10);
        /*bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }*/
        /*
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));*/
        Debug.Log("Hello?");
    }


}