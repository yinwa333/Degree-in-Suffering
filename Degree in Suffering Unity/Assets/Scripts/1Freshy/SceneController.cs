using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //Shows how the cards will be placed on the screen
    public const int gridRows = 3;
    public const int gridCols = 6;
    public const float offsetX = 2.5f;
    public const float offsetY = 3f;

    [SerializeField]
    private MainCard originalCard;

    [SerializeField]
    private Sprite[] images;

    public GameObject Canvas;
   

    private void Start()
    {
        //The position of the first card. All other cards are offset from here.
        Vector3 startPos = originalCard.transform.position; 

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        numbers = ShuffleArray(numbers); 

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    //Copy of the first card
                    card = Instantiate(originalCard) as MainCard;
                    card.transform.SetParent(Canvas.transform);
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                //set the image and id of the card displayed
                card.ChangeSprite(id, images[id]);

                //set the positions
                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    void Update()
    {
        if (_score == 9)
            Canvas.SetActive(false);
    }



    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    private int _score = 0;

    [SerializeField]
    private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(0.3f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;

    }

}