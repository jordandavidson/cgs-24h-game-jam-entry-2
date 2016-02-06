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
    public bool diverted_ = false;

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

            Vector3 new_position = this.transform.position + velocity_;
            if (debug_mode_)
            {
                // Movement line
                Debug.DrawLine(new_position, target_position_, Color.red, 0.1f);
                Debug.DrawLine(new_position, new_position + velocity_, Color.blue, 0.1f);
            }
            this.transform.position = new_position;
        }
    }

    void OnCollisionEnter(Collision collision) {
        Target_Location arrived = collision.gameObject.GetComponent<Target_Location>();
        if (arrived == null) {
            // There is nothing to do, really
        } else {
            // We've reached the location!
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnCollisionStay(Collision collision) {
        if (!diverted_) {
            Health target_health = collision.gameObject.GetComponent<Health>();
            if (target_health == null) {
                // The enemy is non-destructible
                // We need to change direction

                int direction = Random.Range(1, 3);
                float divert_by = (collision.collider.bounds.size.z + this.collider.bounds.size.z);
                if (direction > 1) {
                    target_position_ = this.transform.position + new Vector3(0.0f, 0.0f, divert_by);
                } else {
                    target_position_ = this.transform.position + new Vector3(0.0f, 0.0f, -divert_by);
                }

                diverted_ = true;
            } else {
                // The enemy is destructible
                // KEEP GOING!
                Debug.Log("COLLIDED WITH DESTRUCTIBLE OBJECT");
            }
        }
    }

    private void Update_Velocity() {
        direction_ = target_position_ - this.transform.position;
        direction_.Normalize();

        if (diverted_) {
            // We're having to dodge stuff at the moment
            float distance = Vector3.Distance(this.transform.position, target_position_);
            if (distance < actual_speed_) {
                // We've just reached the diverted destination, so let's re-target
                velocity_ = direction_ * distance;
                target_position_ = target_.transform.position;
                diverted_ = false;
            } else {
                // We're still travelling to the destination
                velocity_ = direction_ * actual_speed_;
            }
        } else {
            float distance = Vector3.Distance(this.transform.position, target_position_);
            if (distance < actual_speed_) {
                velocity_ = direction_ * distance;
                // ARRIVED AT TARGET LOCATION
            } else {
                velocity_ = direction_ * actual_speed_;
            }
        }
    }
}
