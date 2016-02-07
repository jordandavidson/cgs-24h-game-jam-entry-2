using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject projectilePrefab;

    public Transform firing_point_;

    private Player player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
        if (player.ID == 1 && Input.GetKeyUp(KeyCode.Z) || (player.ID == 2 && Input.GetKeyUp(KeyCode.Slash))) {
            if (!player)
                return;

            var projectile = Instantiate(projectilePrefab,
                                            firing_point_.position,
                                            Quaternion.identity) as GameObject;

            var rigidBody = projectile.GetComponent<Rigidbody>();
            rigidBody.velocity = new Vector3(10.0f, 0.0f, 0.0f);
        }
	}
}
