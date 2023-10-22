using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitleGO;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    public GameManagerState GMState;

    public GameManagerState GetGameManagerState()
    {
        return GMState;
    }

    
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);
                GameTitleGO.SetActive(true);
                playButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                GameTitleGO.SetActive(false);
                playButton.SetActive(false);
                playerShip.GetComponent<PlayerController>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();

                break;
            case GameManagerState.GameOver:
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                enemySpawner.GetComponent<EnemySpawner>().UnScheduleEnemySpawner();
                GameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
