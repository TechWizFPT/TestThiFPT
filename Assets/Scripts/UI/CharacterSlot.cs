using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSlot : MonoBehaviour
{
    public CharacterData characterData;
    [SerializeField] Button button;
    [SerializeField] Image characterImage;
    [SerializeField] Image imageBorder;


    public int Test;
    private void Awake()
    {
        button = GetComponent<Button>();
        //characterImage = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //imageBorder.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Seleted()
    {
        Debug.Log("Seleted character slot");
        imageBorder.gameObject.SetActive(true);
    }

    public void UnSeleted()
    {
        imageBorder.gameObject.SetActive(false);

    }

    public void AddCharacter(CharacterData _characterData)
    {
        characterData = _characterData;
        characterImage.sprite = characterData.characterImg;
    }
}
