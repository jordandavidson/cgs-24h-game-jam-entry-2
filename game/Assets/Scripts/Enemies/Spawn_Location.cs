using UnityEngine;
using System.Collections;

public class Spawn_Location : MonoBehaviour {

    public GameObject enemy_;

    public Target_Location target_location_;

	// Use this for initialization
	void Start () {
        Spawn_Enemy();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn_Enemy()
    {
        Debug.Log("SPAWNING ENEMY");
        GameObject new_enemy = (GameObject) GameObject.Instantiate(enemy_, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), this.transform.rotation);
        Enemy_Walk walk = new_enemy.GetComponent<Enemy_Walk>();
        walk.Set_Target(target_location_);
    }
}
