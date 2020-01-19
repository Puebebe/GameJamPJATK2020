using UnityEngine;
using UnityEngine.Video;

public class DemoController : MonoBehaviour
{
    [SerializeField]
    GameObject demo;
    [SerializeField]
    GameObject canvas;

    float timeWithoutAction;
    bool demoIsPlaying;

    void Start()
    {
        timeWithoutAction = 0;
        Time.timeScale = 1;
        demoIsPlaying = false;
    }

    void Update()
    {
        timeWithoutAction += Time.deltaTime;

        if (!demoIsPlaying && timeWithoutAction > 10)
        {
            demoIsPlaying = true;
            //Instantiate(demo);
            demo.SetActive(true);
            canvas.SetActive(false);
        }

        if (Input.anyKey)
        {
            timeWithoutAction = 0;

            var vp = GameObject.FindObjectOfType<VideoPlayer>();

            if (vp != null)
            {
                demoIsPlaying = false;
                //Destroy(vp.gameObject);
                vp.gameObject.SetActive(false);
                canvas.SetActive(true);
            }
        }
    }
}
