using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectCharacterManager : MonoBehaviour
{
    private TextMeshProUGUI CharacterName;
    private SpriteRenderer spriteRenderer;

    private CharacterDatabase allCharacters;
    void Start()
    {
        CharacterName.text = allCharacters.characters[0].character_name;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = allCharacters.characters[0].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
