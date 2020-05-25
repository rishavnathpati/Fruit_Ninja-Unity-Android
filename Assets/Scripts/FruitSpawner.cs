﻿using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSpawning",1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnFruitsGroups",1,6f);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnFruitsGroups");
        StopCoroutine("SpawnFruit");
    }

    public void SpawnFruitsGroups()
    {
        StartCoroutine("SpawnFruit");
    }

    IEnumerator SpawnFruit()
    {
        for (int i = 0; i < 5; i++)
        {
            float Rand = Random.Range(-maxX, maxX);
            Vector3 pos = new Vector3(Rand, transform.position.y, 0);
            GameObject f = Instantiate(fruit, pos, Quaternion.identity) as GameObject;
            f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,15f),ForceMode2D.Impulse);
            f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-20f,20f));

            yield return new WaitForSeconds(0.5f);
        }

    }
}