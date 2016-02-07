using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour {

    public float force_ = 20.0f;

    public Health.Faction faction_;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision) {
        Health collided_health_ = collision.gameObject.GetComponent<Health>();
        if (collided_health_ == null) {

        } else if (collided_health_.Is_Faction(faction_)) {

        } else { 
            collision.rigidbody.velocity = collision.rigidbody.velocity + new Vector3(force_, 0.0f, 0);
        }


    }
}
