﻿using UnityEngine;
using System.Collections;

public class PlayersEstablish : MonoBehaviour {
	public GameObject player1Spawn;
	public GameObject player2Spawn;
	public int naturalFluffCount = -1;
	public int startFluffCount = -1;
	private bool setPlayer1Fluff = false;
	private bool setPlayer2Fluff = false;

	void Awake()
	{
		if (Globals.Instance != null)
		{
			/* TODO check if players already exist in scene.*/
			PlayerInput player1 = null;
			PlayerInput player2 = null;
			GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
			for (int i = 0; i < characters.Length; i++)
			{
				PlayerInput player = characters[i].GetComponent<PlayerInput>();
				if (player != null)
				{
					if (player.playerNumber == PlayerInput.Player.Player1)
					{
						player1 = player;
					}
					else if (player.playerNumber == PlayerInput.Player.Player2)
					{
						player2 = player;
					}
				}
			}
			

			// Place player 1.
			if (Globals.Instance.player1 != null)
			{
				if (player1 == null)
				{
					Globals.Instance.player1.transform.parent = player1Spawn.transform.parent;
					Globals.Instance.player1.transform.position = player1Spawn.transform.position;
					Globals.Instance.player1.transform.rotation = player1Spawn.transform.rotation;
					Globals.Instance.player1.transform.localScale = player1Spawn.transform.localScale;
					player1 = Globals.Instance.player1;
					player1.gameObject.SetActive(true);
					setPlayer1Fluff = true;
				}
				else
				{
					Destroy(Globals.Instance.player1.gameObject);
					Globals.Instance.player1 = player1;
					player1.canvasPaused = Globals.Instance.canvasPaused;
				}
			}

			// Place player 2.
			if (Globals.Instance.player2 != null)
			{
				if (player2 == null)
				{
					Globals.Instance.player2.transform.parent = player2Spawn.transform.parent;
					Globals.Instance.player2.transform.position = player2Spawn.transform.position;
					Globals.Instance.player2.transform.rotation = player2Spawn.transform.rotation;
					Globals.Instance.player2.transform.localScale = player2Spawn.transform.localScale;
					player2 = Globals.Instance.player2;
					player2.gameObject.SetActive(true);
					setPlayer2Fluff = true;
				}
				else
				{
					Destroy(Globals.Instance.player2.gameObject);
					Globals.Instance.player2 = player2;
					player2.canvasPaused = Globals.Instance.canvasPaused;
				}
			}
		}

		if (player1Spawn != null)
		{
			Destroy(player1Spawn);
		}
		if (player2Spawn != null)
		{
			Destroy(player2Spawn);
		}
	}

	void Start()
	{
		if (Globals.Instance != null)
		{
			PlayerInput player1 = Globals.Instance.player1;
			PlayerInput player2 = Globals.Instance.player2;

			if (setPlayer1Fluff && player1 != null)
			{
				FluffHandler fluffHandler1 = player1.GetComponent<FluffHandler>();
				if (naturalFluffCount >= 0)
				{
					fluffHandler1.naturalFluffCount = naturalFluffCount;
				}
				if (startFluffCount >= 0)
				{
					fluffHandler1.startingFluff = startFluffCount;
					fluffHandler1.SpawnStartingFluff();
				}
			}

			if (setPlayer2Fluff && player2 != null)
			{
				FluffHandler fluffHandler2 = player2.GetComponent<FluffHandler>();
				if (naturalFluffCount >= 0)
				{
					fluffHandler2.naturalFluffCount = naturalFluffCount;
				}
				if (startFluffCount >= 0)
				{
					fluffHandler2.startingFluff = startFluffCount;
					fluffHandler2.SpawnStartingFluff();
				}
			}
		}
	}
}
