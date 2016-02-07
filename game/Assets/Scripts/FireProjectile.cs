using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject projectilePrefab;

    private Player player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
        if (player.ID == 1 && Input.GetKeyUp(KeyCode.Space) || (player.ID == 2 && Input.GetKeyUp(KeyCode.RightShift))) {
            if (!player)
                return;

            var projectile = Instantiate(projectilePrefab,
                                            transform.position + new Vector3(1.0f, 0.0f, 0.0f),
                                            Quaternion.identity) as GameObject;

            var rigidBody = projectile.GetComponent<Rigidbody>();
            rigidBody.velocity = new Vector3(10.0f, 0.0f, 0.0f);
        }
	}
}
