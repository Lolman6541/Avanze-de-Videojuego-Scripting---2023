using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    void Start()
    {
        GMState =  GameManagerState.Opening;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

              GameOverGO.SetActive(false);

              playButton.SetActive(true);
              
               break;
            case GameManagerState.Gameplay:
             
               playButton.SetActive(false);

               playerShip.GetComponent<PlayerController>().Init();
               
               enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
               break;
            case GameManagerState.GameOver:

              enemySpawner.GetComponent<EnemySpawner>().UnScheduleEnemySpawner();
               
               GameOverGO.SetActive(true);


                Invoke("ChangeToOpeningState", 8f);
               break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState ();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState ();
    }
    public void ChangeToOpeningState()
    {
        SetGameManagerState (GameManagerState.Opening);
    }
}
