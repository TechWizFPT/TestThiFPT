using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterPanel : MonoBehaviour
{

    public CharacterData characterData;

    public Image characterImage;
    public Image characterImageBorder;

    bool player1Seleted;
    bool player2Seleted;


    [SerializeField] ButtonCustom buttonSelect;

    private void Awake()
    {
        //characterImage = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        characterImage.sprite = characterData.characterImg;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        //characterData = _characterData;
        
    }

    public void PickHero()
    {

    }

    public void Seleted(int playerID)
    {
        if(playerID == 0)
        {
            player1Seleted = true;
        }
        if(playerID == 1)
        {
            player2Seleted = true;
        }
        characterImageBorder.gameObject.SetActive(true);
        if(player1Seleted && player2Seleted)
        {
            characterImageBorder.color = Color.red;
        }
        else
        {
            if (player2Seleted)
            {
                characterImageBorder.color = Color.green;
            }
            else
            {
                characterImageBorder.color = Color.blue;
            }
        }
    }

    public void UnSeleted(int playerID)
    {
        if (playerID == 0)
        {
            player1Seleted = false;
        }
        if (playerID == 1)
        {
            player2Seleted = false;
        }

        if (!player1Seleted && !player2Seleted)
        {
            characterImageBorder.gameObject.SetActive(false);
        }
        else
        {
            if (player1Seleted)
            {
                characterImageBorder.color = Color.blue;

            }
            else
            {
                characterImageBorder.color = Color.green;

            }
        }

    }
}
