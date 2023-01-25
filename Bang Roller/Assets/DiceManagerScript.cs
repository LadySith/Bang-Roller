using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManagerScript : MonoBehaviour
{

    private GameObject[] Dice;
    
    void Start()
    {
        if (Dice == null)
        {
            Dice = GameObject.FindGameObjectsWithTag("dice");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rollAll()
    {
        foreach (GameObject x in Dice)
        {
            x.GetComponent<DiceScript>().OnRoll();
        }
    }
}
