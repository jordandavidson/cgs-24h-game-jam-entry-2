using UnityEngine;
using System.Collections;

public class Spawn_Location : MonoBehaviour {

    public GameObject enemy_;

    public Target_Location target_location_;

    public float spawn_delay_ = 1.0f;
    public float next_spawn_time_ = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float current_time = Time.time;
        if (current_time > next_spawn_time_) {
            Spawn_Enemy();
            next_spawn_time_ = current_time + spawn_delay_;
        }
	}

    public void Spawn_Enemy()
    {
        GameObject new_enemy = (GameObject) GameObject.Instantiate(enemy_, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), this.transform.rotation);
        Enemy_Walk walk = new_enemy.GetComponent<Enemy_Walk>();
        walk.Set_Target(target_location_);
    }
}
