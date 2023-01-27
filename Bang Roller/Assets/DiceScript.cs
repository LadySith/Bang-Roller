using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;
    // Default and new color to change to on selected
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color newColor;
    // Is the object selected. Click to select
    private bool isSelected = false;
    private int sideUp = 1;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Use this for initialization
    private void Start()
    {

        // Assign Renderer component
        defaultColor = Color.white;
        newColor = Color.cyan;
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    // If you left click over the dice then RollTheDice coroutine is started
    public void OnRoll()
    {
        if (!isSelected && sideUp != 6)
        {
            StartCoroutine("RollTheDice");
        }
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next iteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;
        sideUp = finalSide;
    }

    public void OnMouseDown()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            rend.color = newColor;
        }
        else
        {
            rend.color = defaultColor;
        }
    }

    public void resetDice()
    {
        sideUp = 1;
        rend.sprite = diceSides[0];
        rend.color = defaultColor;
        isSelected = false;
    }

    public int getSideUp()
    {
        return sideUp;
    }
}
