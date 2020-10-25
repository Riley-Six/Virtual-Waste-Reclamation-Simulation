using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDoug : MonoBehaviour
{
    public GameObject[] trash;
    public Vector3 spawnValue;
    public float spawnWait;
    //public float spawnMaxWait;
    //public float spawnMinWait;
    public int startWait;
    public bool stop;

    //public indexer tashNumber;

    public int randTrash;


    //public int tashNumber;
    public int counterTrash;


    // Start is called before the first frame update
    /*
    void Start()
    {
        //StartCoroutine(waitSpawner());
        Debug.Log("Start Made");
        StartCoroutine(delayStart());
    }*/


    void StartTheGame()
    {
        //StartCoroutine(waitSpawner());
        Debug.Log("Start Made");
        StartCoroutine(delayStart());
        GameObject.Find("TrashInfo").SendMessage("StartAmount", counterTrash);
    }

    IEnumerator delayStart()
    {
        Debug.Log("Starting to wait");
        yield return new WaitForSeconds(startWait);
        Debug.Log("Done Waiting");


        InvokeRepeating("waitSpawner", 0.0f, spawnWait);
    }

        // Update is called once per frame
    void Update()
    {
        //spawnWait = Random.Range(spawnMinWait, spawnMaxWait);

        //GameObject.Find("TrashInfo").SendMessage("Spawned");


        if (counterTrash <= 0)
            CancelInvoke("waitSpawner");
    }

    void waitSpawner()
    {
        Debug.Log("Spawner Started");
        //yield return new WaitForSeconds(startWait);

        //while (true)
        //{
            randTrash = Random.Range(0, trash.Length + 1);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0, Random.Range(-spawnValue.z, spawnValue.z));

            Instantiate(trash[randTrash], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            counterTrash -= 1;

            GameObject.Find("TrashInfo").SendMessage("Spawned");
        //yield return new WaitForSeconds(spawnWait);
        //}
    }
}
