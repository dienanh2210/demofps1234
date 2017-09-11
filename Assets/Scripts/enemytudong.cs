using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytudong : MonoBehaviour
{
    public GameObject Zombie;
     GameObject[] SpawnPoint1;
    public float minspawn = 2f;
    public float maxspawn = 4f;
    private float lastspawntime = 0;
    private float spawntime = 0;



    // Use this for initialization
    void Start()
    {
        Updatespawntime();
        SpawnPoint1 = GameObject.FindGameObjectsWithTag("spawn");
       // Zombie = GameObject.FindGameObjectWithTag("Enemy");
    }
    void Updatespawntime()
    {
        lastspawntime = Time.time;
        spawntime = Random.Range(minspawn, maxspawn);
    }
    void Zom()
    {
        int Point = Random.Range(0, SpawnPoint1.Length);
        Instantiate(Zombie,SpawnPoint1[Point].transform.position, Quaternion.identity);
        Updatespawntime();

    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastspawntime + spawntime)
        {
            Zom();
        }
    }
}
