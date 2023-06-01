using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Spell : MonoBehaviour
{
    public GameObject _hand;
    public GameObject _fireWand;
    public GameObject _waterWand;
    public GameObject _windWand;
    public GameObject _stoneWand;

    public GameObject _currrentSpell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "FireSpell")
        {
            //_currrentSpell.SetActive(false);
            _currrentSpell = _fireWand;
        }
        else if (collison.tag == "WaterSpell")
        {
            //_currrentSpell.SetActive(false);
            _currrentSpell = _waterWand;
        }
        else if (collison.tag == "WindSpell")
        {
            //_currrentSpell.SetActive(false);
            _currrentSpell = _windWand;
        }
        else if (collison.tag == "StoneSpell")
        {
            //_currrentSpell.SetActive(false);
            _currrentSpell = _stoneWand;
        }
    }
}
