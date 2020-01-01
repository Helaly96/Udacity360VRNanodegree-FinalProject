using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Goal_Script : MonoBehaviour
{
    public GameManager GM;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOAL FOR PLAYER");
        GM.update_player_score();
    }
}
