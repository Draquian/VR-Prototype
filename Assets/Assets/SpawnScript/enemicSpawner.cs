using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemicSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public int counter;
    [SerializeField] float spawnTimerSpeed = 0;
    

    [SerializeField] GameObject[] enemies;
    void Start()
    {
        
        InvokeRepeating("SpawnEnemy", 0, spawnTimerSpeed);
    }

    // Update is called once per frame
    public void SpawnEnemy()
    {
        if (--counter == 0) CancelInvoke("SpawnEnemy");
        Instantiate(enemies[Random.Range(0, enemies.Length)],   
        new Vector3(Random.Range(gameObject.transform.position.x-5, gameObject.transform.position.x + 5), gameObject.transform.position.y, Random.Range(gameObject.transform.position.z - 5, gameObject.transform.position.z + 5)), Quaternion.identity);
       
        
    }
}
