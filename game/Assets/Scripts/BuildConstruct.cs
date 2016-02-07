using UnityEngine;
using System.Collections;

public class BuildConstruct : MonoBehaviour {

    
    private Player player_;

    public float build_delay_ = 1.0f;
    public float construction_finished_ = 0.0f;
    private bool blueprinting_ = false;
    private bool building_ = false;

    public PreConstruction pre_wall_;
    public PreConstruction pre_tower_;

    public Animator this_animator_;

    // Use this for initialization
    void Start () {
        player_ = gameObject.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        Attempt_Build();
	}

    void Attempt_Build() {
        if (!player_)
            return;

        float current_time = Time.time;
        if (building_ &&
            current_time > construction_finished_) {
            pre_wall_.Construct();
            pre_tower_.Construct();
            building_ = false;
            this_animator_.SetBool("building_", false);
            player_.ResumeMovement();
        } else {
            if (blueprinting_) {
                // Already preparing to build
                if ((player_.ID == 1 && Input.GetKeyUp(KeyCode.X) || (player_.ID == 2 && Input.GetKeyUp(KeyCode.Slash))) ||
                    (player_.ID == 1 && Input.GetKeyUp(KeyCode.Z) || (player_.ID == 2 && Input.GetKeyUp(KeyCode.RightShift)))) {
                    blueprinting_ = false;
                    building_ = true;
                    this_animator_.SetBool("repairing_", false);
                    this_animator_.SetBool("building_", true);
                    construction_finished_ = current_time + build_delay_;
                    player_.StopMovement();
                }
            } else {
                if (player_.ID == 1 && Input.GetKeyDown(KeyCode.X) || (player_.ID == 2 && Input.GetKeyDown(KeyCode.Slash))) {
                    player_.ReduceMovement();
                    this_animator_.SetBool("repairing_", true);
                    pre_wall_.Blueprint();
                    blueprinting_ = true;
                }
                else if (player_.ID == 1 && Input.GetKeyDown(KeyCode.Z) || (player_.ID == 2 && Input.GetKeyDown(KeyCode.RightShift)))
                {
                    player_.ReduceMovement();
                    this_animator_.SetBool("repairing_", true);
                    pre_tower_.Blueprint();
                    blueprinting_ = true;
                }
            }
        }
    }
}
