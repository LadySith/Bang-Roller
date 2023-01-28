using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    private GameObject[] Dice;
    public int maxLife = 6;
    private int curLife;
    private int bangCount;
    private int rollNum;
    private int arrowsHeld;
    private int arrowsInPile;
    public int allArrows = 10;

    void Start()
    {
        curLife = maxLife;
        bangCount = 0;
        rollNum = 0;
        arrowsHeld = 0;
        arrowsInPile = allArrows;
        

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
        checkArrows();
        rollNum++;
    }

    public void checkState()
    {
        Debug.Log("STATE\nLife = " + curLife + "/" + maxLife + "\nRoll #" + rollNum + "\n\nArrows Held = " + arrowsHeld + "\nArrows In Pile = " + arrowsInPile + "\n\n:)\n");
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
        resetAll();
        curLife = maxLife;
        bangCount = 0;
        rollNum = 0;
        arrowsHeld = 0;
        arrowsInPile = allArrows;
    }

    public void gainLife()
    {
        if (curLife < maxLife)
        {
            curLife++;
        }
    }

    public void loseLife()
    {
        if (curLife > 0)
        {
            curLife--;
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
            loseLife();
        }
    }

    public void checkArrows()
    {
        for (int i = 0; i < Dice.Length; i++)
        {
            if (Dice[i].GetComponent<DiceScript>().getSideUp() == 5)
            {
                arrowsHeld++;
                arrowsInPile--;
                if (arrowsInPile == 0)
                {
                    for (int j = 0; j < arrowsHeld; j++)
                    {
                        loseLife();
                    }
                }
            }
        }
    }

    public void endTurn()
    {

        int gatlingCount = 0;

        for (int i = 0; i < Dice.Length; i++)
        {
            if (Dice[i].GetComponent<DiceScript>().getSideUp() == 1)
            {
                Debug.Log("You may shoot a player distance 1 away from you");
            }
            if (Dice[i].GetComponent<DiceScript>().getSideUp() == 2)
            {
                Debug.Log("You may shoot a player distance 2 away from you");
            }
            if (Dice[i].GetComponent<DiceScript>().getSideUp() == 3)
            {
                gainLife();
            }
            if (Dice[i].GetComponent<DiceScript>().getSideUp() == 4)
            {
                gatlingCount++;
                if (gatlingCount > 2)
                {
                    Debug.Log("All players but you lose a life");
                    arrowsInPile += arrowsHeld;
                    arrowsHeld = 0;
                }
                
            }
        }

        Debug.Log("END OF TURN");
    }
}
