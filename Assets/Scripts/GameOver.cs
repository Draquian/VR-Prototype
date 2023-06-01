using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "Points";
    }


    public void Retry()
    {
        SceneManager.LoadScene("Player");
        Debug.Log("MOlt Loco");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
