using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPooler : MonoBehaviour
{
    public GameObject fireballPF;
    public int poolSize;
    public float spawnRate = 4f;
    public float min = -7f; //range
    public float max = 7f;

    private GameObject[] fireballs;
    private Vector2 objectPoolPos = new Vector2(-15f, -25f);
    private float timeSinceLastSpawn;
    private float y =10f; //y stays same
    private int current = 0;

    //use for initialization
    void Start()
    {
        fireballs = new GameObject[poolSize];
        for(int i=0; i< poolSize; i++)
        {
            fireballs[i] = (GameObject)Instantiate(fireballPF, objectPoolPos, Quaternion.identity);

        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (GameManage.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0; //reset time 
            float x = Random.Range(min, max); //place randomly along x
            fireballs[current].transform.position = new Vector2(x, y); 
            current++;
            if(current >= poolSize)
            {
                current = 0;
            }
        }
    }


}

