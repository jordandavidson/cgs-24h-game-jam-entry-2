using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public enum Faction {
        PLAYER,
        ENEMY
    }

    public bool is_building_;
    public bool Is_Building() { return is_building_; }
    public Faction faction_;
    public Faction Current_Faction { get { return faction_; } }

    public int health_ = 1;
    public int max_health_ = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Edit_Health(int amount)
    {
        health_ += amount;
        if (health_ > max_health_) {
            health_ = max_health_;
        } else if (health_ <= 0) {
            GameObject.Destroy(this.gameObject);
            if (Is_Faction(Faction.ENEMY)) {
                var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                gameManager.remainingEnemies--;
            }
        }
    }

    public bool Is_Faction(Faction faction)
    {
        return faction_ == faction;
    }

    public bool Is_At_Max_Health() {
        return health_ == max_health_;
    }

}
