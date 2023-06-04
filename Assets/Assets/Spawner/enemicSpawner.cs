using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemicSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private int counter;
    [SerializeField] float spawnTimerSpeed =1 ;
    [SerializeField] int roundNumber = 1;
    private GameObject waveControllerRef;

    [SerializeField] GameObject[] enemies;
    private bool started=true;
    void Start()
    {
        waveControllerRef = GameObject.FindGameObjectWithTag("WaveController");
        roundNumber = waveControllerRef.GetComponent<WaveController>().roundNumber;
        counter = waveControllerRef.GetComponent<WaveController>().enemiesNumber;
    }

    private void Update()
    {
        if (waveControllerRef.GetComponent<WaveController>().roundStarted && started)
        {
            started = false;
            counter = waveControllerRef.GetComponent<WaveController>().enemiesNumber;
            roundNumber = waveControllerRef.GetComponent<WaveController>().roundNumber;

            InvokeRepeating("SpawnEnemy", 0, spawnTimerSpeed);

            
        }
     


    }
    // Update is called once per frame
    public void SpawnEnemy()
    {
        if (--counter == 0)
        {
            CancelInvoke("SpawnEnemy");
            waveControllerRef.GetComponent<WaveController>().roundStarted = false;
            started = true;

        }
        Instantiate(enemies[Random.Range(0, enemies.Length)],   
        new Vector3(Random.Range(gameObject.transform.position.x-5, gameObject.transform.position.x + 5), gameObject.transform.position.y, Random.Range(gameObject.transform.position.z - 5, gameObject.transform.position.z + 5)), Quaternion.identity);

    }
}
