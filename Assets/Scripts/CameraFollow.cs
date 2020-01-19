using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject playerOne;
    [SerializeField]
    GameObject playerTwo;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = playerTwo.transform.position - playerOne.transform.position;
        Vector3 newPosition = 0.5f * distance + playerOne.transform.position;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); 

    }
}
