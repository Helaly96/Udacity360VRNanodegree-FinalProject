using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Goal_Script : MonoBehaviour
{
    public GameManager GM;
    private void OnTriggerEnter(Collider other)
    {
        GM.update_enemy_score();
    }
}
