using UnityEngine;
using System.Collections;

public class PreConstruction : MonoBehaviour {

    public GameObject construction_prefab_;
    public Transform construct_at_;
    public Renderer visualisation_;

    public float construct_delay_ = 1.0f;
    private float next_construct_update_;
    private float start_blueprint_;

    private bool colliding_ = false;
    private bool repair_mode_ = false;

	// Use this for initialization
	void Start () {
	}

    void FixedUpdate() {
        colliding_ = false;
        visualisation_.material = Resources.Load<Material>("Valid_Construction");
        visualisation_.enabled = true;
        repair_mode_ = false;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.CompareTag("Noncollidable")) {

        } else {
            colliding_ = true;
            Health building_health_ = collider.gameObject.GetComponent<Health>();
            if (building_health_ == null) {
                // Collided object has no health, so we can't repair it
                visualisation_.material = Resources.Load<Material>("Invalid_Construction");
            } else if (building_health_.Is_Building()) {
                repair_mode_ = true;
                visualisation_.enabled = false;
                float current_time = Time.time;
                if (current_time > (start_blueprint_ + 0.5f) &&
                    current_time > next_construct_update_) {
                    building_health_.Edit_Health(1);
                    next_construct_update_ = current_time + construct_delay_;
                }
            }
        }
    }

    public void Construct()
    {
        if (colliding_) {

        } else {
            // There are no current collisions!
            var construction = Instantiate(construction_prefab_,
                                           construct_at_.position,
                                           Quaternion.identity) as GameObject;

        }
        this.gameObject.SetActive(false);
    }

    public void Blueprint() {
        this.gameObject.SetActive(true);
        start_blueprint_ = Time.time;
    }
    
}
