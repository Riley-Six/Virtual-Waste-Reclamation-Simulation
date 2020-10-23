using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private GameObject[] Trash;
    //Trash Kids
    public GameObject Bottle;
    public GameObject Cardboard;
    public GameObject MilkJug;
    public GameObject Carton;
    public GameObject Wrapper;
    public GameObject Can;
    public GameObject Bag;
    public GameObject GreenWaste;
    public float delay;

    //private List<GameObject> Trash;

    // Start is called before the first frame update
    void Start(){
        Trash = new GameObject[8];

        Trash[0] = Bottle; //
        Trash[1] = Cardboard;
        Trash[2] = MilkJug;
        Trash[3] = Carton;
        Trash[4] = Wrapper;
        Trash[5] = Can;
        Trash[6] = Bag;
        Trash[7] = GreenWaste;
        //Update();
        /*
        int rndTrshIndex = Random.Range(0, 8);

        GameObject Junk = (GameObject)Instantiate(Trash[rndTrshIndex], transform);

        Debug.Log(Trash[rndTrshIndex]);
        var xCordinate = this.gameObject.transform.position.x;
        var yCordinate = this.gameObject.transform.position.y;

        Junk.transform.position = new Vector2(xCordinate, yCordinate);
        Junk.transform.localScale = new Vector3(0.5f, 0.5f, 0);*/

        //yield return new WaitForSeconds(5);

        StartCoroutine(delayStart());

        //InvokeRepeating("SpawnIn", 0.0f, delay);

    }

    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(5);

        InvokeRepeating("SpawnIn", 0.0f, delay);
    }


    void SpawnIn()
    {
        int rndTrshIndex = Random.Range(0, 8);

        GameObject Junk = (GameObject)Instantiate(Trash[rndTrshIndex], transform);

        Debug.Log(Trash[rndTrshIndex]);
        var xCordinate = this.gameObject.transform.position.x;
        var yCordinate = this.gameObject.transform.position.y;

        Junk.transform.position = new Vector2(xCordinate, yCordinate);
        Junk.transform.localScale = new Vector3(0.5f, 0.5f, 0);
    }

    //void OnCollisionEnter2D(Collision2D collision2D)
    //{
        //Debug.Log("PLEASE");
    //}


    /*
    void Awake(){
        // adfaf
        int rndTrshIndex = Random.Range(0, 255);

        GameObject tile = (GameObject)Instantiate(Trash[rndTrshIndex], transform);
        tile.transform.position = new Vector2(0, 0);

    }*/


    // Update is called once per frame
    /*
void Update()
{
    int rndTrshIndex = Random.Range(0, 7);

    GameObject Junk = (GameObject)Instantiate(Trash[rndTrshIndex], transform); // 
    GameObject Junk = (GameObject)Instantiate(Trash[rndTrshIndex], transform);

    Debug.Log(Trash[rndTrshIndex]);
    var xCordinate = this.gameObject.transform.position.x;
    var yCordinate = this.gameObject.transform.position.y;

    Junk.transform.position = new Vector2(xCordinate, yCordinate);
}*/
}
