using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GridManagerCode : MonoBehaviour
{
    public int rows;
    public int columns;
    public float tileSize;
    public float offset;
    public GameObject tileTexture;
    public GameObject blankSpace;
    public GameObject circle;
    private int newCounter = 0;
    private List<GameObject> grid;
    //private List<List<GameTile>> grid;

    public class Something {
        public int hi;
    }

    /*public class GameTile
    {
        private int xPos { get; }
        private int yPos { get; }
        private GameObject tile;

        public GameTile(int x, int y, GameObject newTile)
        {
            xPos = x;
            yPos = y;
            tile = newTile;
        }
    }*/

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

        grid = new List<GameObject>();
        //grid = new List<List<GameTile>>();


        bool first = true;

        for (int runnerX = -rows; runnerX < rows; runnerX++)
        {
            //List<GameTile> temp = new List<GameTile>();
            GameObject temp = new GameObject();

            for (int runnerY = -columns; runnerY < columns; runnerY++)
            {
                GameObject tile;
                if (first) {
                    tile = (GameObject)Instantiate(circle, transform);
                    tile.name = "OpenTile " + "(" + counter + ")";
                    first = false;
                }
                else {
                    tile = (GameObject)Instantiate(blankSpace, transform);
                    tile.name = "BlockedTile " + "(" + counter + ")";
                }
                
                counter++;
                float xPos = runnerY * tileSize + offset;
                float yPos = runnerX * -tileSize + offset - 1;
                tile.transform.position = new Vector2(xPos, yPos);
                //Instantiate(tile);
                //string outing = xPos.ToString() + "-" + yPos.ToString();
                //Debug.Log(outing);

                grid.Add(temp);
                //temp.Add(new GameTile(runnerX,runnerY,tile));
            }

            //grid.Add(temp);
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


            if (hit && hit.collider.gameObject.name.Contains("OpenTile"))
            {
                    
                Vector2 center = hit.point;
                Ray[] UpDownLeftRight = {
                    new Ray(new Vector3(ray.origin.x, ray.origin.y + tileSize, ray.origin.z), ray.direction),
                    new Ray(new Vector3(ray.origin.x, ray.origin.y - tileSize, ray.origin.z), ray.direction),
                    new Ray(new Vector3(ray.origin.x - tileSize, ray.origin.y, ray.origin.z), ray.direction),
                    new Ray(new Vector3(ray.origin.x + tileSize, ray.origin.y, ray.origin.z), ray.direction),
                };

                print(hit.collider.name);

                GameObject currentTile = GameObject.Find(hit.collider.gameObject.name);

                foreach (Ray i in UpDownLeftRight) {
                    /*if (i.x > columns || i.x < -columns || i.y > rows || i.y < -rows) {
                        continue;
                    }*/
                    RaycastHit2D hit2 = Physics2D.Raycast(i.origin, i.direction);

                    if (!hit2)
                        continue;

                    GameObject currentTile2 = GameObject.Find(hit2.collider.gameObject.name);

                    if (hit2.collider.gameObject.name.Contains("BlockedTile"))
                    {
                        Destroy(GameObject.Find(hit2.collider.gameObject.name));
                        GameObject newTile2 = (GameObject)Instantiate(circle, transform);
                        newTile2.name = "OpenTile " + "(" + newCounter + ")";

                        newCounter++;
                        newTile2.transform.position = new Vector2(currentTile2.transform.position.x, currentTile2.transform.position.y);
                    }
                    else if (hit2.collider.gameObject.name.Contains("FilledTileEnd"))
                    {
                        Vector3 newPos = currentTile2.transform.position;

                        Destroy(GameObject.Find(hit2.collider.gameObject.name));
                        GameObject newTile2 = (GameObject)Instantiate(tileTexture, transform);
                        newTile2.name = "FilledTileConduit " + "(" + newCounter + ")";

                        newCounter++;
                        newTile2.transform.position = currentTile2.transform.position;

                        Ray[] UpDownLeftRight2 = {
                            new Ray(new Vector3(newPos.x, newPos.y + 1, newPos.z), ray.direction),
                            new Ray(new Vector3(newPos.x, newPos.y - 1, newPos.z), ray.direction),
                            new Ray(new Vector3(newPos.x - 1, newPos.y, newPos.z), ray.direction),
                            new Ray(new Vector3(newPos.x + 1, newPos.y, newPos.z), ray.direction),
                        };

                        foreach (Ray j in UpDownLeftRight2)
                        {
                            RaycastHit2D hit3 = Physics2D.Raycast(j.origin, i.direction);

                            if (!hit3 || hit3.transform.position.Equals(hit.collider.gameObject.transform.position) || hit3.collider.gameObject.name.Contains("FilledTile"))
                                continue;

                            GameObject currentTile3 = GameObject.Find(hit3.collider.gameObject.name);

                            if (hit3.collider.gameObject.name.Contains("OpenTile"))
                            {
                                Destroy(GameObject.Find(hit3.collider.gameObject.name));
                                GameObject newTile3 = (GameObject)Instantiate(blankSpace, transform);
                                newTile3.name = "BlockedTile " + "(" + newCounter + ")";

                                newCounter++;
                                newTile3.transform.position = new Vector2(currentTile3.transform.position.x, currentTile3.transform.position.y);
                            }
                        }
                    }
                }

                Vector2 newPosition = GameObject.Find(hit.collider.gameObject.name).transform.position;
                Destroy(GameObject.Find(hit.collider.gameObject.name));
                GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                newTile.name = "FilledTileEnd " + "(" + newCounter + ")";

                newCounter++;
                newTile.transform.position = newPosition;

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