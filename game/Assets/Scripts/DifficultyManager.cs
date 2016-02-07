using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public GameObject gameManager;
    public GameObject gameTimer;

    private GameManager game;
    private Timer timer;

    void Start () {

        game = gameManager.GetComponent<GameManager>();
        timer = gameTimer.GetComponent<Timer>();
	}
	
	void Update () {

        if (timer.gameTime > 10.0f)
        {


        }
	}

    private void Reset()
    {

    }
}
