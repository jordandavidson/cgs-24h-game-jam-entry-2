using UnityEngine;
using System.Collections;

public class Landmine : MonoBehaviour {

    public Health.Faction faction_ = Health.Faction.PLAYER;
    public int damage_ = 5;

    public GameObject particles_;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider) {
        Attack_Target(collider.gameObject.GetComponent<Health>());
    }

    private void Attack_Target(Health target_health) {
        if (target_health == null) {
            // The collided target does not have health.
        } else {
            if (target_health.Is_Faction(faction_)) {
                // Is the same faction, so should not hit
            } else {
                target_health.Edit_Health(-damage_);
                if (particles_ != null) {
                    GameObject.Instantiate(particles_, this.transform.position, Quaternion.identity);
                }
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
