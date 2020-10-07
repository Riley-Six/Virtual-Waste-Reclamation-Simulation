using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] trash;
    public Vector3 spawnValue;
    public float spawnWait;
    public float spawnMaxWait;
    public float spawnMinWait;
    public int startWait;
    public bool stop;

    int randTrash;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds (startWait);

        while (true)
        {
            randTrash = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 1, Random.Range(-spawnValue.z, spawnValue.z));

            Instantiate(trash[randTrash], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
