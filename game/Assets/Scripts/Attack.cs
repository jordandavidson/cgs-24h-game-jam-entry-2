using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public Health.Faction faction_;
    public int damage_;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision) {
        Health target = collision.gameObject.GetComponent<Health>();
        if (target == null) {
            // The collided target does not have health.
        } else {
            if (target.Is_Faction(faction_)) {
                // Is the same faction, so should not hit
            } else {
                target.Edit_Health(-damage_);
            }
        }
    }
}
