using UnityEngine;
using System.Collections;

public class TowerProjectile : MonoBehaviour {

    public GameObject projectilePrefab;

    public Transform attack_target_;

    public Transform attack_spawn_;
    public SphereCollider attack_range_;
    public float attack_cooldown_ = 0.5f;
    public float next_attack_ = 0.0f;

    public float range_ = 5.0f;

    private Health this_health_;

    // Use this for initialization
    void Start () {
        this_health_ = this.gameObject.GetComponent<Health>();
        attack_range_.radius = range_;
	}
	
	// Update is called once per frame
	void Update () {
        if (attack_target_ == null) {

        } else {
            Fire_Projectile();
        }
    }

    void OnTriggerStay(Collider collider) {
        if (attack_target_ == null) {
            // We're looking for a new target!
            Health collided_health = collider.gameObject.GetComponent<Health>();
            if (collided_health == null) {
                // The collided object can't be hit so don't bother attacking it
            } else {
                if (collided_health.Is_Faction(this_health_.Current_Faction)) {
                    // The collided object is the same faction as this, so do not target it
                } else {
                    // The collided object is an enemy! Attack it!
                    attack_target_ = collider.transform;
                }
            }
        }
    }

    void Fire_Projectile() {
        float current_time = Time.time;
        if (current_time > next_attack_) {
            if (attack_target_ == null) {
                // We shouldn't fire because our target is null!
            } else if (Vector3.Distance(this.transform.position, attack_target_.position) > range_) {
                // The target is now out of range.
                attack_target_ = null;
            } else {
                // The target is in range, so attack it!
                next_attack_ = current_time + attack_cooldown_;

                GameObject projectile = Instantiate(projectilePrefab,
                                                    attack_spawn_.position,
                                                    Quaternion.identity) as GameObject;
                Rigidbody rigidBody = projectile.GetComponent<Rigidbody>();
                Vector3 direction = attack_target_.position - attack_spawn_.position;
                direction.Normalize();

                rigidBody.velocity = direction * 10.0f;
            }
        }
    }
}
