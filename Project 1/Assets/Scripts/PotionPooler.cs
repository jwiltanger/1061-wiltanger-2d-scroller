using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPooler : MonoBehaviour
{
    //same as fireball pooler but with different names
    public GameObject potion;
    public int poolSize;
    public float spawnRate = 4f;
    public float min = -1f;
    public float max = 3.5f;

    private GameObject[] potions;
    private Vector2 poolPos = new Vector2(-15f, -25f);
    private float timeSinceLastSpawn;
    private float y = 10f;
    private int current = 0;

    //use for initialization
    void Start()
    {
        potions = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            potions[i] = (GameObject)Instantiate(potion, poolPos, Quaternion.identity);

        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (GameManage.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float x = Random.Range(min, max);
            potions[current].transform.position = new Vector2(x, y); //place randomly along x
            current++;
            if (current >= poolSize)
            {
                current = 0;
            }
        }
    }
}
