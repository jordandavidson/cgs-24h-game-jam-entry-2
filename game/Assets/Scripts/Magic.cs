using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {

    private Player player;

    public Healing_Zone healing_zone_;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.ID == 1 && Input.GetKeyDown(KeyCode.X) || (player.ID == 2 && Input.GetKeyDown(KeyCode.Slash))) {
            if (healing_zone_ != null) {
                healing_zone_.Activate(Health.Faction.PLAYER);
                player.StopMovement();
            }
        } else if (player.ID == 1 && Input.GetKeyDown(KeyCode.Z) || (player.ID == 2 && Input.GetKeyDown(KeyCode.Greater))) {

        }

        if (player.ID == 1 && Input.GetKeyUp(KeyCode.X) || (player.ID == 2 && Input.GetKeyUp(KeyCode.Slash))) {
            if (healing_zone_ != null) {
                healing_zone_.Deactivate();
                player.StartMovement();
            }
        } else if (player.ID == 1 && Input.GetKeyUp(KeyCode.Z) || (player.ID == 2 && Input.GetKeyUp(KeyCode.Greater))) {

        }
    }
}
