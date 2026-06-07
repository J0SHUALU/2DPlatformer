using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	private bool canDamage;

	void Awake () {
		canDamage = true;
	}

	public void DealDamage() {
		if (canDamage) {
			GameManager.instance.TakeEnemyDamage();

			canDamage = false;
			StartCoroutine (WaitForDamage ());
		}
	}

	IEnumerator WaitForDamage() {
		yield return new WaitForSeconds (2f);
		canDamage = true;
	}

} // class