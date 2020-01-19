using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.speed = -player.speed;
            StartCoroutine(revertPlayerControlsAfterSeconds(3, player));

        }
        Destroy(gameObject);
    }
    IEnumerator revertPlayerControlsAfterSeconds(int seconds, Player player)
    {
        yield return new WaitForSeconds(seconds);
        player.speed = -player.speed;
    }
}
