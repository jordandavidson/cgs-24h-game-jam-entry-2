using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private float timeAlive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (timeAlive > 8.0f)
        {
            Destroy(gameObject);
        }

        timeAlive += Time.deltaTime;
	}
}
