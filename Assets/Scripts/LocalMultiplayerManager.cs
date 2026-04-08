using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class LocalMultiplayerManager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoin(PlayerInput player)
    {
        players.Add(player);
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        localMultiplayerController controller = player.GetComponent<localMultiplayerController>();
        controller.manager = this;
    }

    public void PlayerAttacking(PlayerInput attackingPlayer) 
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position) < 0.5f && attackingPlayer != players[i]) 
            {
                localMultiplayerController playerObject = players[i].GetComponent<localMultiplayerController>();
                playerObject.HP -= 1;
                if (playerObject.HP > 0)
                {
                    Debug.Log("Player " + attackingPlayer.playerIndex + " hit player " + players[i].playerIndex +
                              "\nPlayer " + players[i].playerIndex + " has " + playerObject.HP + " HP left");
                }
                else 
                {
                    Debug.Log("Player " + attackingPlayer.playerIndex + " hit player " + players[i].playerIndex +
                              "\nPlayer " + players[i].playerIndex + " is out");
                }
            }
            
        }
    }
}
