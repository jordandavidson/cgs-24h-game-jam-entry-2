﻿using UnityEngine;
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
        Attack_Target(collision.gameObject.GetComponent<Health>());
    }

    private void Attack_Target(Health target_health) {
        if (target_health == null) {
            // The collided target does not have health.
        } else {
            if (target_health.Is_Faction(faction_)) {
                // Is the same faction, so should not hit
            } else {
                target_health.Edit_Health(-damage_);
            }
        }
    }
}
