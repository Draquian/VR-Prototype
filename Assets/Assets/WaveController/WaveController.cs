using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public int roundNumber = 1;
    public bool roundStarted;
    public int enemiesNumber = 20;
    [SerializeField] float startRoundTimer=0;
    public float spawnTimerController = 3;
    // Start is called before the first frame update
    void Start()
    {
        roundNumber = 1;
        roundStarted = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(!roundStarted)
        {
            startRoundTimer += 1 * Time.deltaTime;
            if (startRoundTimer >= 10.0f)
            {
                roundNumber++;
                startRoundTimer = 0;
                roundStarted = true;
                enemiesNumber +=  roundNumber;
                spawnTimerController -= 0.1f;
            }
        }

    }

    
}
