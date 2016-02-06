using UnityEngine;

public class Shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
