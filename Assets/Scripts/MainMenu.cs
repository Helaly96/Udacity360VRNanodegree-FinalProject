using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Door;
    public GameObject Waypoint_door;
    //public UnityEngine.AI.NavMeshAgent agent;
    public GameObject waypoint_for_player;
    public GameObject Canvas;
    float distance_to_move;
    public CharacterMovement player;

    public void Start_Game_BTN()
    {
        Canvas.transform.gameObject.SetActive(false);

        distance_to_move = Door.transform.position.y - Waypoint_door.transform.position.y;
     iTween.MoveBy(Door, iTween.Hash(
     "y", distance_to_move,
     "time", 0.5f
    ));

     //agent.SetDestination(waypoint_for_player.transform.position);

    }

    public void Start()
    {
        player.ChoseTheHero(1);
    }
    void change_to_game()
    {
        Debug.Log("Clicked*");
        SceneManager.LoadScene("MainGame");
    }
    public void SelectFlying()
    {
        player.ChoseTheHero(1);
        change_to_game();
    }

    public void SelectEngineer()
    {
        player.ChoseTheHero(2);
        change_to_game();
    }

    public void SelectFlash()
    {
        player.ChoseTheHero(3);
        change_to_game();
    }
}
