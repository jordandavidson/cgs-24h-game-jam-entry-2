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

    public Renderer flash_target_;

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

        if (amount > 0) {
            StartCoroutine(Flash_Colour(Color.blue, Color.white));
        } else if (amount < 0) {
            StartCoroutine(Flash_Colour(Color.red, Color.white));
        }
    }

    public bool Is_Faction(Faction faction)
    {
        return faction_ == faction;
    }

    public bool Is_At_Max_Health() {
        return health_ == max_health_;
    }

    IEnumerator Flash_Colour (Color flash_colour, Color normal_colour) {
        for (int i = 0; i < 10; ++i) {
            float weight = (float) i / 10.0f;
            flash_target_.material.color = new Color(Mathf.Lerp(flash_colour.r, normal_colour.r, weight),
                                                     Mathf.Lerp(flash_colour.g, normal_colour.g, weight),
                                                     Mathf.Lerp(flash_colour.b, normal_colour.b, weight));
            yield return new WaitForSeconds(0.1f);
        }
    }

}
