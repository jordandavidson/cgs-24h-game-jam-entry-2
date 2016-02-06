using UnityEngine;

public class Player : MonoBehaviour {

    public float MovementSpeed = 10.0f;
    public float TurningSpeed = 60.0f;

    public int ID;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        if (ID == 1) {

            if (Input.GetKey(KeyCode.W))
                rigidbody.MovePosition(rigidbody.position + Vector3.forward * MovementSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.S))
                rigidbody.MovePosition(rigidbody.position - Vector3.forward * MovementSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
                rigidbody.MovePosition(rigidbody.position + Vector3.right * MovementSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
                rigidbody.MovePosition(rigidbody.position - Vector3.right * MovementSpeed * Time.deltaTime);
        }
        else if (ID == 2) {

            if (Input.GetKey(KeyCode.UpArrow))
                rigidbody.MovePosition(rigidbody.position + Vector3.forward * MovementSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.DownArrow))
                rigidbody.MovePosition(rigidbody.position - Vector3.forward * MovementSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                rigidbody.MovePosition(rigidbody.position + Vector3.right * MovementSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
                rigidbody.MovePosition(rigidbody.position - Vector3.right * MovementSpeed * Time.deltaTime);
        }

	}
}
