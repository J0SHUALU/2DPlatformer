using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private Text lifeText;
	private int lifeCount = 3;

	private Transform player;
	private Rigidbody2D playerBody;

	// Tracks the last safe ground position so respawn happens near the water (extra mark).
	private Vector3 lastSafePosition;

	public GameObject endScenePanel; // Panel with Replay and Quit buttons (assign in Inspector).

	void Awake() {
		if (instance == null) instance = this;
		else { Destroy(gameObject); return; }
	}

	void Start() {
		Time.timeScale = 1f;

		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerBody = player.GetComponent<Rigidbody2D>();
		lastSafePosition = player.position;

		lifeText = GameObject.Find("LifeText").GetComponent<Text>();
		lifeText.text = "x" + lifeCount;

		if (endScenePanel != null) endScenePanel.SetActive(false);
	}

	void Update() {
		// Remember the last grounded, dry spot so we respawn close to where the player drowned.
		if (player != null && Mathf.Abs(playerBody.linearVelocity.y) < 0.05f) {
			lastSafePosition = player.position;
		}
	}

	// Called by the water trigger (see WaterDeath.cs) when the player enters water.
	public void PlayerEnteredWater() {
		lifeCount--;
		if (lifeCount >= 0) lifeText.text = "x" + lifeCount;

		if (lifeCount > 0) {
			Respawn();
		} else {
			GameOver();
		}
	}
    
	// Called when the player takes a hit from an enemy.
	public void TakeEnemyDamage() {
		lifeCount--;
		if (lifeCount >= 0) lifeText.text = "x" + lifeCount;

		if (lifeCount > 0) {
			Respawn();
		} else {
			GameOver();
		}
	}

	void Respawn() {
		// Respawn near the water the player entered, not at the start (extra mark).
		Vector3 respawnPos = lastSafePosition + Vector3.up * 1.5f;
		player.position = respawnPos;
		playerBody.linearVelocity = Vector2.zero;
	}

	void GameOver() {
		Time.timeScale = 0f;
		if (endScenePanel != null) endScenePanel.SetActive(true);
	}

	// Hook to the Replay button.
	public void Replay() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Hook to the Quit button.
	public void Quit() {
		Application.Quit();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

} // class