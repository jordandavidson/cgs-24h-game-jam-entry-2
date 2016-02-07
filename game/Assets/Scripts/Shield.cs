using UnityEngine;

public class Shield : MonoBehaviour {

    public GameObject shield_;

    public Animator this_animator_;

    public Player player_;

	void Start () {

        player_ = this.gameObject.GetComponent<Player>();
	}
	
	void Update () {
        if (player_.ID == 1 && Input.GetKeyDown(KeyCode.Z) || (player_.ID == 2 && Input.GetKeyDown(KeyCode.RightShift))) {
            shield_.SetActive(true);
            this_animator_.SetBool("marching_", true);
            player_.ReduceMovement();
        }
        else if (player_.ID == 1 && Input.GetKeyUp(KeyCode.Z) || (player_.ID == 2 && Input.GetKeyUp(KeyCode.RightShift)))
        {
            player_.ResumeMovement();
            shield_.SetActive(false);
            this_animator_.SetBool("marching_", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Health collided_health = collision.gameObject.GetComponent<Health>();
        if (collided_health == null) {
            //if (collision.transform.name.Contains("Projectile")) {
            //    //if (Input.GetKeyDown(KeyCode.RightShift))
            //    //{
            //    collision.rigidbody.velocity -= new Vector3(10.0f, 0.0f, 0.0f);
            //    //}



            //    //Destroy(collision.gameObject);
            //}
        } else {
            if (collided_health.Is_Faction(Health.Faction.PLAYER)) {
                // They're on our side, so ignore them...
            } else {
                // Knock the enemies back!
                collision.rigidbody.velocity += new Vector3(20.0f, 0.0f, 0.0f);
            }
        }




    }
}
