using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float time = 60;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        GameState.isOver = false;
        time += 0.99f;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        text.text = "" + (int)time;

        if (!GameState.isOver && time < 1)
        {
            GameState.isOver = true;
            Time.timeScale = 0;
            var uiManager = FindObjectOfType<UIManager>();
            uiManager.UpdateGameOverScreen();
            uiManager.ShowGameOverScreen();
        }
    }
}
