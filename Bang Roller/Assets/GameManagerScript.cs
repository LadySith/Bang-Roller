using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    private GameObject[] Dice;
    public int maxLife;
    private int curLife;
    private int bangCount;

    void Start()
    {
        curLife = maxLife;
        bangCount = 0;

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

        checkBang();
    }

    public void resetAll()
    {
        foreach (GameObject x in Dice)
        {
            x.GetComponent<DiceScript>().resetDice();
        }
    }

    public void resetGame()
    {
        //reset all numbers in the game
    }

    public void gainLife()
    {
        if (curLife < maxLife)
        {
            maxLife++;
        }
    }

    public void loseLife()
    {
        if (curLife > 0)
        {
            maxLife--;
        }

        if (curLife == 0)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        Debug.Log("GAME OVER");
    }

    public void checkBang()
    {

        for (int i = 0; i < Dice.Length; i++)
        {
            if (Dice[i].GetComponent<DiceScript>().getSideUp() == 6)
            {
                bangCount++;
            }
        }

        if (bangCount > 2)
        {

            Debug.Log("BANG!");
            //Lose a life
        }
    }
}
