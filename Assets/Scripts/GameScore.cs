using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;
    
    int score;

    public int Score 
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
   
    void Start()
{
    // Asegúrate de que este script esté adjunto a un objeto que tenga un componente Text
    scoreTextUI = GetComponent<Text>();
    
    // Verifica si se encontró el componente Text
    if (scoreTextUI == null)
    {
        Debug.LogError("No se encontró un componente Text adjunto a este objeto.");
    }
}


    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format ("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }

}
