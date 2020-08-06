using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCard : MonoBehaviour
{
    [SerializeField]
    private SceneController controller;

    [SerializeField]
    private GameObject Card_Back;

    public void OnMouseDown()
    {
        if (Card_Back.activeSelf)
        {
            Card_Back.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        //This gets the sprite renderer component and changes the property of it's sprite!
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
        
    }

    public void Unreveal()
    {
        Card_Back.SetActive(true);
    }

}


