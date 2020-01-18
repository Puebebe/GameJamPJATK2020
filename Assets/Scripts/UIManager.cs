using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scorePlayer1;
    [SerializeField] TextMeshProUGUI scorePlayer2;

    int score1 = 0;
    int score2 = 0;

    private void Start()
    {
        scorePlayer1.text = "" + score1;
        scorePlayer2.text = "" + score2;
    }

    public void AddScorePlayer(int player)
    {
        if(player == 1)
        {
            score1++;
            scorePlayer1.text = "" + score1;
        }
        else if (player == 2)
        {
            score2++;
            scorePlayer2.text = "" + score2;
        }
    }
}
