using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {

    private Player player_;

    public Healing_Zone healing_zone_;
    public PreConstruction pre_landmine_;

    private float finish_laying_mine_;
    private bool laying_mine_;

    public Animator this_animator_;

    // Use this for initialization
    void Start () {
        player_ = gameObject.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {

        if (player_.ID == 1 && Input.GetKeyUp(KeyCode.X) || (player_.ID == 2 && Input.GetKeyUp(KeyCode.Slash))) {
            if (healing_zone_ != null) {
                healing_zone_.Deactivate();
                this_animator_.SetBool("healing_", false);
                player_.ResumeMovement();
            }
        }

        if (player_.ID == 1 && Input.GetKeyDown(KeyCode.X) || (player_.ID == 2 && Input.GetKeyDown(KeyCode.Slash))) {
            if (healing_zone_ != null) {
                healing_zone_.Activate(Health.Faction.PLAYER);
                this_animator_.SetBool("healing_", true);
                player_.StopMovement();
            }
        }

        if (laying_mine_) {
            if (Time.time > finish_laying_mine_) {
                laying_mine_ = false;
                this_animator_.SetBool("laying_mine_", false);
                pre_landmine_.Construct();
                player_.ResumeMovement();
            }
        } else {
            if (player_.ID == 1 && Input.GetKeyDown(KeyCode.Z) || (player_.ID == 2 && Input.GetKeyDown(KeyCode.Greater))) {
                pre_landmine_.Blueprint();
                player_.StopMovement();
                finish_laying_mine_ = Time.time + 0.5f;
                laying_mine_ = true;
                this_animator_.SetBool("laying_mine_", true);
            }
        }
        //} else if (player.ID == 1 && Input.GetKeyDown(KeyCode.Z) || (player.ID == 2 && Input.GetKeyDown(KeyCode.Greater))) {

        //    blueprinting_ = true;
        //}
    }
}
