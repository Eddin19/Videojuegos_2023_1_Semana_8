using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextPlayer : MonoBehaviour
{
    public SpriteRenderer Character;
    public Sprite[] Sprites;
    private GameManager gm;

    public int currentImage = 0;

    private void Start()
    {
        SetCharacterSprite(currentImage);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
       
    }

    public void PrePlayer()
    {
        currentImage--;
        if (currentImage < 0)
            currentImage = Sprites.Length - 1;

        SetCharacterSprite(currentImage);
        PlayerPrefs.SetInt("SelectedCharacter", currentImage);
        //Debug.Log(currentImage);
    }

    public void PosPlayer()
    {
        currentImage++;
        if (currentImage >= Sprites.Length)
            currentImage = 0;

        SetCharacterSprite(currentImage);
        PlayerPrefs.SetInt("SelectedCharacter", currentImage);
        //Debug.Log(currentImage);
    }

    private void SetCharacterSprite(int index)
    {
        Character.sprite = Sprites[index];
    }

    public void NextScene()
    {
        
        GuardarPartida();
        //Debug.Log("Se guardó la partida en la escena 1");
        SceneManager.LoadScene("Scene1");
    }

    private void GuardarPartida()
    {
        gm.GuardarPartida1();
    }
}
