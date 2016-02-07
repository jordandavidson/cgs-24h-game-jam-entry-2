using UnityEngine;

public class Player : MonoBehaviour {

    public float MovementSpeed = 10.0f;
    public float DesiredSpeed = 10.0f;
    public float TurningSpeed = 60.0f;

    public int ID;

    public Animator this_animator_;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        if (ID == 1) {

            if (Input.GetKey(KeyCode.W)) {
                rigidbody.MovePosition(rigidbody.position + Vector3.forward * MovementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S)) {
                rigidbody.MovePosition(rigidbody.position - Vector3.forward * MovementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D)) {
                rigidbody.MovePosition(rigidbody.position + Vector3.right * MovementSpeed * Time.deltaTime);
                this_animator_.SetBool("moving_forwards_", true);
            }

            if (Input.GetKey(KeyCode.A)) {
                rigidbody.MovePosition(rigidbody.position - Vector3.right * MovementSpeed * Time.deltaTime);
                this_animator_.SetBool("moving_forwards_", false);
            }
        }
        else if (ID == 2) {

            if (Input.GetKey(KeyCode.UpArrow)) {
                rigidbody.MovePosition(rigidbody.position + Vector3.forward * MovementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow)) {
                rigidbody.MovePosition(rigidbody.position - Vector3.forward * MovementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                rigidbody.MovePosition(rigidbody.position + Vector3.right * MovementSpeed * Time.deltaTime);
                this_animator_.SetBool("moving_forwards_", true);
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                rigidbody.MovePosition(rigidbody.position - Vector3.right * MovementSpeed * Time.deltaTime);
                this_animator_.SetBool("moving_forwards_", false);
            }
        }

	}

    public void ResumeMovement() {
        MovementSpeed = DesiredSpeed;
    }

    public void StopMovement() {
        MovementSpeed = 0.0f;
    }

    public void ReduceMovement() {
        MovementSpeed = DesiredSpeed * 0.5f;
    }
}
