using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    //the Rect Transform for the Canvas/Group of cards
    [SerializeField]
    private Transform puzzleField;

    //Create a foreloop(?) 
    [SerializeField]
    private GameObject btn;

    private void Awake()
    {
        //18 Buttons
        for (int i = 0; i < 18; i++)
        {
            //Instantiate creates a COPY of the thing you provide
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
        }

    }


}
