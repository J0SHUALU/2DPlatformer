using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this to the Player. Reports to GameManager when the player touches water.
public class WaterDeath : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Water") {
			GameManager.instance.PlayerEnteredWater();
		}
	}

} // class