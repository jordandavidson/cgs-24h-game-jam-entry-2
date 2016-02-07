using UnityEngine;
using System.Collections;

public class AutoDestroyParticleSystem : MonoBehaviour {

    private ParticleSystem particle_system_;

	// Use this for initialization
	void Start () {
        particle_system_ = this.gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (particle_system_ != null) {
            if (particle_system_.IsAlive()) {
                // Keep going...
            } else {
                // Destroy this particle system.
                GameObject.Destroy(this.gameObject);
            }
        }
	}
}
