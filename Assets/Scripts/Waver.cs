using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waver : MonoBehaviour
{
    private float WaveSpeed;
    private float timer;
    private float changeDirectionTime;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        WaveSpeed = Random.Range(-0.4f, 0.4f);
        direction = (int)Mathf.Sign(WaveSpeed);
        changeDirectionTime = Random.Range(1, 4);
        timer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction *= -1;
            timer = changeDirectionTime;
        }
        
        transform.position += new Vector3 (WaveSpeed*Time.deltaTime*direction, 0);
    }
}
