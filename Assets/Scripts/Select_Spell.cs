using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Spell : MonoBehaviour
{
    //public GameObject _hand;
    public GameObject _fireWand;
    public GameObject _waterWand;
    public GameObject _windWand;
    public GameObject _stoneWand;

    GameObject _currrentSpell;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        _currrentSpell = _fireWand;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "FireSpell")
        {
            Debug.Log("Fire");
            _currrentSpell.SetActive(false);
            _currrentSpell = _fireWand;
            _currrentSpell.SetActive(true);

        }
        else if (collison.tag == "WaterSpell")
        {
            Debug.Log("water");
            _currrentSpell.SetActive(false);
            _currrentSpell = _waterWand;
            _currrentSpell.SetActive(true);
        }
        else if (collison.tag == "WindSpell")
        {
            Debug.Log("Wind");
            _currrentSpell.SetActive(false);
            _currrentSpell = _windWand;
            _currrentSpell.SetActive(true);
        }
        else if (collison.tag == "StoneSpell")
        {
            Debug.Log("Stone");
            _currrentSpell.SetActive(false);
            _currrentSpell = _stoneWand;
            _currrentSpell.SetActive(true);
        }
    }
}
