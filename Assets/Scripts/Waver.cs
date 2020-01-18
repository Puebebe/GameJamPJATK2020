using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waver : MonoBehaviour
{
    private float WaveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        WaveSpeed = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (WaveSpeed*Time.deltaTime, 0);
    }
}
