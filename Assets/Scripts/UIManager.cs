using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scorePlayer1;
    [SerializeField] TextMeshProUGUI scorePlayer2;

    private void Start()
    {
        GameState.playerScore1 = 0;
        GameState.playerScore2 = 0;
        scorePlayer1.text = "" + GameState.playerScore1;
        scorePlayer2.text = "" + GameState.playerScore1;
    }

    public void AddScorePlayer(int player)
    {
        if(player == 1)
        {
            GameState.playerScore1++;
            scorePlayer1.text = "" + GameState.playerScore1;
        }
        else if (player == 2)
        {
            GameState.playerScore2++;
            scorePlayer2.text = "" + GameState.playerScore2;
        }
    }
}
