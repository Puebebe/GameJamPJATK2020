using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField1;
    [SerializeField] TMP_InputField inputField2;

    public void NewGame()
    {
        SceneManager.LoadScene("NamesColorsMenu");
    }

    public void StartGame()
    {
        if (string.IsNullOrWhiteSpace(inputField1.text) || string.IsNullOrWhiteSpace(inputField2.text))
            return;

        GameState.playerName1 = inputField1.text;
        GameState.playerName2 = inputField2.text;
        Time.timeScale = 1;
        SceneManager.LoadScene("GameplayScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameplayScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
