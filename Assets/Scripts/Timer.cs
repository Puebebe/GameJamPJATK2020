using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float time = 60;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        time += 0.99f;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        text.text = "" + (int)time;

        if (time < 1)
        {
            //Game ended
            Time.timeScale = 0;
            
        }
    }
}
