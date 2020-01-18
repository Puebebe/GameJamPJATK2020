using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scorePlayer1;
    [SerializeField] TextMeshProUGUI scorePlayer2;

    [Header("Game Over Screen")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI GOSplayerName1;
    [SerializeField] TextMeshProUGUI GOSplayerName2;
    [SerializeField] TextMeshProUGUI GOSplayerScore1;
    [SerializeField] TextMeshProUGUI GOSplayerScore2;

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

    public void UpdateGameOverScreen()
    {
        GOSplayerName1.text = GameState.playerName1;
        GOSplayerName2.text = GameState.playerName2;
        GOSplayerScore1.text = "" + GameState.playerScore1;
        GOSplayerScore2.text = "" + GameState.playerScore2;
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
