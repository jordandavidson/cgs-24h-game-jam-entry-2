using UnityEngine;
using System.Collections;

public class BuildConstruct : MonoBehaviour {

    
    private Player player;

    private float construction_finished_ = 0.0f;
    private bool blueprinting_ = false;

    public PreConstruction pre_wall_;
    public PreConstruction pre_tower_;

    //private Vector3 pre_wall_offset_;
    //private Vector3 pre_tower_offset_;

    // Use this for initialization
    void Start () {
        player = gameObject.GetComponent<Player>();
        //pre_wall_offset_ = pre_wall_.transform.localPosition;
        //pre_tower_offset_ = pre_tower_.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        float current_time = Time.time;
        if (current_time > construction_finished_) {
            Attempt_Build();
        }
	}

    void Attempt_Build() {
        if (!player)
            return;



        if (blueprinting_) {
            // Already preparing to build
            if (player.ID == 1 && Input.GetKeyUp(KeyCode.X) || (player.ID == 2 && Input.GetKeyUp(KeyCode.Slash))) {

                pre_wall_.Construct();
                blueprinting_ = false;
            } else if (player.ID == 1 && Input.GetKeyUp(KeyCode.Z) || (player.ID == 2 && Input.GetKeyUp(KeyCode.Greater))) {

                pre_tower_.Construct();
                blueprinting_ = false;
            }
        } else {
            if (player.ID == 1 && Input.GetKeyDown(KeyCode.X) || (player.ID == 2 && Input.GetKeyDown(KeyCode.Slash))) {
                pre_wall_.Blueprint();
                //pre_wall_.transform.position = this.transform.position + pre_wall_offset_;
                blueprinting_ = true;
            } else if (player.ID == 1 && Input.GetKeyDown(KeyCode.Z) || (player.ID == 2 && Input.GetKeyDown(KeyCode.Greater))) {
                pre_tower_.Blueprint();
                //pre_tower_.transform.position = this.transform.position + pre_wall_offset_;
                blueprinting_ = true;
            }
        }
    }
}
