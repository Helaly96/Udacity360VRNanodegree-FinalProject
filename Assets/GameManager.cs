using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerScore;
    public TextMeshProUGUI GladiatorScore;

    public static int Player_int_Score = 0;
    public static int Gladiator_int_Score = 0;

    private void Awake()
    {
       Player_int_Score = 0;
       Gladiator_int_Score = 0;
    }

    void Start()
    {
        Player_int_Score = 0;
        Gladiator_int_Score = 0;
        PlayerScore.text = Player_int_Score.ToString() ;
        GladiatorScore.text = Gladiator_int_Score.ToString();
    }

    public void update_player_score()
    {
        Debug.Log("??");
        Player_int_Score = Player_int_Score + 1;
    }

    public void update_enemy_score()
    {
        Gladiator_int_Score = Gladiator_int_Score + 1;
    }


    void Update()
    {
        PlayerScore.text = Player_int_Score.ToString();
        GladiatorScore.text = Gladiator_int_Score.ToString();

        if(Mathf.Abs(Player_int_Score-Gladiator_int_Score)>4)
        {
            Debug.Log("Game Ends");
            SceneManager.LoadScene("Restart");
        }
    }
}
