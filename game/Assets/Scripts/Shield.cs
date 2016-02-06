using UnityEngine;

public class Shield : MonoBehaviour {

    public GameObject shieldBash;

    private Player player;

	void Start () {

        player = gameObject.transform.parent.gameObject.GetComponent<Player>();
	}
	
	void Update () {
	
        
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("Projectile"))
        {
            //if (Input.GetKeyDown(KeyCode.RightShift))
            //{
                collision.rigidbody.velocity -= new Vector3(10.0f, 0.0f, 0.0f);
            //}
            
            
            
            //Destroy(collision.gameObject);
        }


        if (collision.transform.name.Contains("Enemy"))
        {
            collision.rigidbody.velocity += new Vector3(20.0f, 0.0f, 0.0f);
        }

        if (collision.transform.name.Contains("Player1"))
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.RightShift))
            {


                //collision.rigidbody.velocity += new Vector3(10.0f, 0.0f, 0.0f);
            }
        }
    }
}
