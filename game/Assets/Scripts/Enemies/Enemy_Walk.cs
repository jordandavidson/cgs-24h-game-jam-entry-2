using UnityEngine;
using System.Collections;

public class Enemy_Walk : MonoBehaviour {

    public bool debug_mode_;

    public float minimum_time_taken_ = 1.0f;
    public Vector3 velocity_;
    public Vector3 direction_;

    public bool is_moving_ = true;

    public Vector3 target_position_;
    public Target_Location target_;
    public void Set_Target(Target_Location target_location)
    {
        target_ = target_location;
    }

    private float actual_speed_ = 1.0f;

    // Use this for initialization
    void Start () {
        target_position_ = target_.transform.position;
        actual_speed_ = Vector3.Distance(this.transform.position, target_position_) / (60.0f * minimum_time_taken_);
	}
	
	// Update is called once per frame
	void Update () {
        if (is_moving_)
        {
            Update_Velocity();

            this.transform.position = this.transform.position + velocity_;
            if (debug_mode_)
            {
                // Movement line
                Debug.DrawLine(this.transform.position, target_position_, Color.red, 1.0f);
                Debug.DrawLine(this.transform.position, this.transform.position + velocity_, Color.blue, 1.0f);
            }
        }
    }

    void OnCollisionEnter (Collision collision) {
        Health target_health = collision.gameObject.GetComponent<Health>();
        if (target_health == null) {
            // The enemy is non-destructible
            // We need to change direction
        } else {
            // The enemy is destructible
            // KEEP GOING!
            Debug.Log("COLLIDED WITH DESTRUCTIBLE OBJECT");
        }
    }

    private void Update_Velocity()
    {
        direction_ = target_position_ - this.transform.position;
        direction_.Normalize();

        velocity_ = direction_ * actual_speed_;
    }
}
