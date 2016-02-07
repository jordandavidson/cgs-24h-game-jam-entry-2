using UnityEngine;

public class Projectile : MonoBehaviour {

    private float timeAlive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (timeAlive > 2.0f)
        {
            Destroy(gameObject);
        }

        timeAlive += Time.deltaTime;
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
