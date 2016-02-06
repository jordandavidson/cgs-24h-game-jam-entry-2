using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public enum Faction {
        PLAYER,
        ENEMY
    }

    public Faction faction_;
    public Faction Current_Faction { get { return faction_; } }
    public int health_ = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Edit_Health(int amount)
    {
        health_ += amount;
        if (health_ <= 0) {
            GameObject.Destroy(this.gameObject);
        }
    }

    public bool Is_Faction(Faction faction)
    {
        return faction_ == faction;
    }
}
