using UnityEngine;

public class Target_Location : MonoBehaviour {

    public int enemyHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (enemyHit >= 15)
        {
            Time.timeScale = 0;
        }
	}

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.name.Contains("Enemy"))
        {
            enemyHit++;
        }
    }
}
