using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public GameObject gameManager;
    public GameObject gameTimer;
    public GameObject enemySpawner;

    private GameManager game;
    private Timer timer;
    private Spawn_Location spawner;

    void Start () {

        game = gameManager.GetComponent<GameManager>();
        timer = gameTimer.GetComponent<Timer>();
        spawner = enemySpawner.GetComponent<Spawn_Location>();
	}
	
	void Update () {

        if (timer.gameTime > 20.0f && timer.gameTime < 35.0f)
        {
            spawner.spawn_delay_ = 0.8f;
        }
        else if (timer.gameTime > 35.0f && timer.gameTime < 50.0f)
        {
            spawner.spawn_delay_ = 0.6f;
        }
        else if (timer.gameTime > 50.0f)
        {
            spawner.spawn_delay_ = 0.45f;
        }
	}

    private void Reset()
    {

    }
}
