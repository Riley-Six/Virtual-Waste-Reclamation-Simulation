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
    public List<List<int[]>> paths; //this is a 2D array so as to support multiple paths
    public List<List<int>> findPath; //use it to find out which path
    public Dictionary<float, int> findX;
    public Dictionary<float, int> findY;
    private int newCounter = 0;
    private int endCounter = 0;
    private List<List<GameObject>> grid;
    //private List<List<GameTile>> grid;

    public class Something {
        public int hi;
    }

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

        grid = new List<List<GameObject>>();
        findX = new Dictionary<float, int>();
        findY = new Dictionary<float, int>();
        //grid = new List<List<GameTile>>();


        bool firstTile = true;

        float xPos, yPos;

        findPath = new List<List<int>>();

        for (int runnerX = 0; runnerX < rows; runnerX++)
        {
            //List<GameTile> temp = new List<GameTile>();
            grid.Add(new List<GameObject>());

            GameObject temp = new GameObject();

            xPos = (runnerX * -tileSize + offset - 1 + rows/2) * -1;

            findPath.Add(new List<int>());

            findX.Add(xPos,runnerX);

            //findPath = new List<List<int>>();

            for (int runnerY = 0; runnerY < columns; runnerY++)
            {
                yPos = (runnerY * tileSize + offset - columns/2) * -1;

                //grid.Add(new List<GameObject>());
                if (firstTile) {
                    grid[0].Add((GameObject)Instantiate(circle, transform));
                    grid[0][0].name = "OpenTile " + "(" + counter + ")";
                    //fancy instantiation of paths
                    paths = new List<List<int[]>>();
                    paths.Add(new List<int[]>());
                    paths[0].Add(new int[] { 0, 0 });
                    //fancy instantiation of paths
                    
                    
                    findPath[0].Add(0);
                    grid[0][0].transform.position = new Vector2(xPos, yPos);
                    //grid[0][0] = tile;
                    firstTile = false;
                    if (runnerX == 0) {
                        findY.Add(yPos, runnerY);
                    }
                }
                else {
                    findPath[runnerX].Add(0);

                    grid[runnerX].Add((GameObject)Instantiate(blankSpace, transform));
                    grid[runnerX][runnerY].name = "BlockedTile " + "(" + counter + ")";
                    grid[runnerX][runnerY].transform.position = new Vector2(xPos, yPos);

                    if (runnerX == 0)
                    {
                        findY.Add(yPos, runnerY);
                    }
                }
                
                counter++;
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


            if (hit && hit.collider.gameObject.name.Contains("OpenTile"))
            {
                Vector2 center = GameObject.Find(hit.collider.gameObject.name).transform.position;

                print(hit.collider.name);

                int[] clickPlace = { findX[center.x], findY[center.y] };

                int[][] upDownLeftRight = {
                    new int[] {clickPlace[0], clickPlace[1] - 1}, //up
                    new int[] {clickPlace[0], clickPlace[1] + 1}, //down
                    new int[] {clickPlace[0] - 1, clickPlace[1]}, //left
                    new int[] {clickPlace[0] + 1, clickPlace[1]}  //right
                };

                foreach (int[] i in upDownLeftRight)
                {
                    if (i[0] < 0 ||
                        i[0] >= rows ||
                        i[1] < 0 ||
                        i[1] >= columns
                    ) { continue; } 

                    if (grid[i[0]][i[1]].name.Contains("BlockedTile"))
                    {
                        Vector2 temp = grid[i[0]][i[1]].transform.position;
                        Destroy(grid[i[0]][i[1]]);
                        
                        GameObject tempTile = (GameObject)Instantiate(circle, transform);
                        grid[i[0]][i[1]] = tempTile;
                        grid[i[0]][i[1]].name = "OpenTile " + "(" + newCounter + ")";

                        newCounter++;
                        grid[i[0]][i[1]].transform.position = temp;
                    }
                    else if (grid[i[0]][i[1]].name.Contains("FilledTileEnd"))
                    {
                        Vector2 temp = grid[i[0]][i[1]].transform.position;
                        //Vector3 newPos = currentTile2.transform.position;
                        Destroy(grid[i[0]][i[1]]);
                        GameObject tempTile = (GameObject)Instantiate(tileTexture, transform);
                        grid[i[0]][i[1]] = tempTile;
                        grid[i[0]][i[1]].name = "FilledTileConduit " + "(" + endCounter + ")";
                        grid[i[0]][i[1]].transform.position = temp;
                        //findPath.Add();
                        findPath[clickPlace[0]][clickPlace[1]] = findPath[i[0]][i[1]];
                        //findPath.Add(clickPlace, findPath[i]);

                        endCounter++;
                        //newTile2.transform.position = currentTile2.transform.position;

                        int[][] upDownLeftRight2 = {
                            new int[] {i[0], i[1] - 1}, //up
                            new int[] {i[0], i[1] + 1}, //down
                            new int[] {i[0] - 1, i[1]}, //left
                            new int[] {i[0] + 1, i[1]}  //right
                        };

                        foreach (int[] j in upDownLeftRight2)
                        {
                            //RaycastHit2D hit3 = Physics2D.Raycast(j.origin, i.direction);

                            //if (!hit3 || hit3.transform.position.Equals(hit.collider.gameObject.transform.position) || hit3.collider.gameObject.name.Contains("FilledTileConduit"))
                            //continue;

                            if (j[0] < 0 ||
                                j[0] >= rows ||
                                j[1] < 0 ||
                                j[1] >= columns ||
                                (j[0] == clickPlace[0] && j[1] == clickPlace[1])
                            ) { continue; }

                            //GameObject currentTile3 = GameObject.Find(hit3.collider.gameObject.name);

                            if (grid[j[0]][j[1]].name.Contains("OpenTile"))
                            {
                                Vector2 temp2 = grid[j[0]][j[1]].transform.position;
                                Destroy(grid[j[0]][j[1]]);
                                GameObject tempTile2 = (GameObject)Instantiate(blankSpace, transform);
                                grid[j[0]][j[1]] = tempTile2;
                                grid[j[0]][j[1]].name = "BlockedTile " + "(" + newCounter + ")";

                                newCounter++;
                                grid[j[0]][j[1]].transform.position = temp2;
                            }
                        }
                    }
                }

                Vector2 newPosition = grid[clickPlace[0]][clickPlace[1]].transform.position;
                Destroy(grid[clickPlace[0]][clickPlace[1]]);
                GameObject newTile = (GameObject)Instantiate(tileTexture, transform);
                grid[clickPlace[0]][clickPlace[1]] = newTile;
                newTile.name = "FilledTileEnd " + "(" + newCounter + ")";

                newCounter++;
                newTile.transform.position = newPosition;
            }
        }
    }

}