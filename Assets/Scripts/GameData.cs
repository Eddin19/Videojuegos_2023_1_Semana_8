using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int Score;
    public int Vidas;

    public GameData(){
        Score = 0;
        Vidas = 3;
    }
}
