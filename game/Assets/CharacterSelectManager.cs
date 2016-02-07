using UnityEngine;
using System.Collections;

public class CharacterSelectManager : MonoBehaviour {

    public GameObject Hunter;
    public GameObject Wizard;
    public GameObject Builder;
    public GameObject Knight;

    public GameObject spawnLocation;
    public int playerID;

    private bool characterSelected;
    private GameObject currentCharacter;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void SelectHunter()
    {
        InstantiateCharacter(Hunter);
    }

    public void SelectWizard()
    {
        InstantiateCharacter(Wizard);
    }

    public void SelectBuilder()
    {
        InstantiateCharacter(Builder);
    }

    public void SelectKnight()
    {
        InstantiateCharacter(Knight);
    }

    private void InstantiateCharacter(Object character)
    {
        if (currentCharacter) {

            Destroy(currentCharacter);
        }

        currentCharacter = Instantiate(character, spawnLocation.transform.position, Quaternion.identity) as GameObject;
        currentCharacter.SetActive(true);
        currentCharacter.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        var player = currentCharacter.GetComponent<Player>();
        player.ID = playerID;
    }
}
