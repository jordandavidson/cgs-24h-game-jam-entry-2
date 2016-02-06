using UnityEngine;
using System.Collections;

public class Enemy_Walk : MonoBehaviour {

    public bool debug_mode_;

    public float minimum_time_taken_ = 1.0f;
    public Vector3 velocity_;
    public Vector3 direction_;

    public bool is_moving_ = true;

    public Target_Location target_;
    public void Set_Target(Target_Location target_location)
    {
        target_ = target_location;
    }

    private float actual_speed_ = 1.0f;

    // Use this for initialization
    void Start () {
        actual_speed_ = Vector3.Distance(this.transform.position, target_.transform.position) / (60.0f * minimum_time_taken_);
	}
	
	// Update is called once per frame
	void Update () {
        if (is_moving_)
        {
            Update_Velocity();
            if (debug_mode_)
            {
                Debug.DrawLine(this.transform.position, this.transform.position + velocity_);
            }
            this.transform.position = this.transform.position + velocity_;
        }
    }

    void Fixed_Update() {

    }

    private void Update_Velocity()
    {
        direction_ = target_.transform.position - this.transform.position;
        direction_.Normalize();

        velocity_ = direction_ * actual_speed_;
    }
}
