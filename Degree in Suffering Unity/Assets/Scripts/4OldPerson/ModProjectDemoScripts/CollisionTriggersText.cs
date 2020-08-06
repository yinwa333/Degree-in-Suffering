using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

//this script detects a collision between the player character and any gameobject tagged as "character"
//when the collision is detected, it activates a UI Canvas, which is parented to the player character and shows dialogue
//there are two dialogues which can be shown, dialogue1 and dialogue 2. these can we written within the inspector
public class CollisionTriggersText : MonoBehaviour
{
    public Canvas myDialogueBox;
    private Text myDialogue;
    private int currentText;
    public string dialogue1;
    public string dialogue2;


    // Start is called before the first frame update
    void Start()
    {
        currentText = 1;
        myDialogue = myDialogueBox.GetComponentInChildren<Text>();
        myDialogueBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print (collision.gameObject.tag);
        if (collision.gameObject.tag == "character")
        {
            myDialogueBox.gameObject.SetActive(true);

            if (currentText == 1)
            {
                myDialogue.text = dialogue1;
            }
            if (currentText == 2)
            {
                myDialogue.text = dialogue2;
            }
        }
    }

    //when exiting the collision, the UI Canvas is disabled, and the dialogue is cycled
    //which dialogue we're on is tracked by an integer (int). 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "character")
        {
            myDialogueBox.gameObject.SetActive(false);
            //every time we exit the collision, the currentText is increased by 1
            currentText += 1;
            //if the integer is larger than the number of available dialogues (2), then it resets to 1.
            if (currentText >= 3)
            {
                currentText = 1;
            }
        }

    }
}
