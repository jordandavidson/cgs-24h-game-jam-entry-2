using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int remainingEnemies;
    public int spawnedEnemies;

    public GameObject remainingUI;
    public GameObject spawnedUI;

    private Text remainingText;
    private Text spawnedText;

	void Start () {

        remainingText = remainingUI.GetComponent<Text>();
        spawnedText = spawnedUI.GetComponent<Text>();
	}
	
	void Update () {

        remainingText.text = remainingEnemies.ToString();
        spawnedText.text = spawnedEnemies.ToString();
	}
}
