using UnityEngine;
using System.Collections;

public class Enemy_Walk : MonoBehaviour {

    public bool debug_mode_;

    public float minimum_time_taken_ = 1.0f;
    public Vector3 velocity_;
    public Vector3 direction_;

    public bool is_moving_ = true;
    private float delay_ = 0.0f;

    public Vector3 target_position_;
    public Target_Location target_;
    public void Set_Target(Target_Location target_location)
    {
        target_ = target_location;
    }
    public bool diverted_ = false;

    private float actual_speed_ = 1.0f;
    private Health this_health_;

    // Use this for initialization
    void Start () {
        this_health_ = this.gameObject.GetComponent<Health>();

        target_position_ = target_.transform.position;
        actual_speed_ = Vector3.Distance(this.transform.position, target_position_) / (60.0f * minimum_time_taken_);
	}
	
	// Update is called once per frame
	void Update () {
        if (is_moving_)
        {
            float current_time = Time.time;
            if (current_time > delay_) {
                Update_Velocity();

                Vector3 new_position = this.transform.position + velocity_;
                if (debug_mode_) {
                    // Movement line
                    Debug.DrawLine(new_position, target_position_, Color.red, 0.1f);
                    Debug.DrawLine(new_position, new_position + velocity_, Color.blue, 0.1f);
                }
                this.transform.position = new_position;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        Target_Location arrived = collision.gameObject.GetComponent<Target_Location>();
        if (arrived == null) {
            // We need to push out of the object!
            Vector3 push_out_direction = collision.transform.position - this.transform.position;
            push_out_direction.Normalize();
            this.transform.position = this.transform.position - (push_out_direction * 0.1f);
            delay_ = Time.time + 0.2f;
            Health collided = collision.gameObject.GetComponent<Health>();
            if (collided == null) {
                // The enemy is non-destructible
                // We need to change direction

                Divert((collision.collider.bounds.size.z + this.collider.bounds.size.z) - Mathf.Abs(collision.transform.position.z - this.transform.position.z));
            } else {
                if (collided.Is_Faction(this_health_.Current_Faction)) {
                    if (Vector3.Distance(this.transform.position, target_.transform.position) > Vector3.Distance(collision.transform.position, target_.transform.position)) {
                        Divert(collision.collider.bounds.size.z + this.collider.bounds.size.z);
                    }
                } else {
                    // We're hitting into an enemy!
                }
            }
        } else {
            // We've reached the location!
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnCollisionStay(Collision collision) {

    }

    void OnCollisionExit(Collision collision) {

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

    private void Divert(float divert_by) {
        int direction = Random.Range(1, 3);
        if (direction > 1) {
            target_position_ = this.transform.position + new Vector3(0.0f, 0.0f, divert_by);
        } else {
            target_position_ = this.transform.position + new Vector3(0.0f, 0.0f, -divert_by);
        }

        diverted_ = true;
    }
}
