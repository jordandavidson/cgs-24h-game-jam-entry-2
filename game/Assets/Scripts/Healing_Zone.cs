using UnityEngine;
using System.Collections;

public class Healing_Zone : MonoBehaviour {

    Health.Faction healing_faction_ = Health.Faction.PLAYER;

    public float heal_delay_ = 1.0f;
    public float next_healing_wave_ = 0.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider collider) {
        float current_time = Time.time;
        if (current_time > next_healing_wave_) {
            Health collided_health = collider.gameObject.GetComponent<Health>();
            if (collided_health == null) {
                // No health to heal, so ignore it!
            } else if (collided_health.Is_Building()) {
                // The collided object is a building, so ignore it!
            } else if (collided_health.Is_Faction(healing_faction_)) {
                // It's an ally! Let's heal them.
                collided_health.Edit_Health(1);
                next_healing_wave_ = current_time + heal_delay_;
            }
        }
    }

    public void Activate(Health.Faction heal_faction) {
        next_healing_wave_ = Time.time + heal_delay_;
        healing_faction_ = heal_faction;
        this.gameObject.SetActive(true);
    }

    public void Deactivate() {
        this.gameObject.SetActive(false);
    }
}
