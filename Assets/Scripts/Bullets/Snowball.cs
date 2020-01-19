using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
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
        if(collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.speed /= 2;
            player.StartCoroutine(revertPlayerSpeedAfterSeconds(3, player));

        }
        Destroy(gameObject);
    }

    IEnumerator revertPlayerSpeedAfterSeconds(int seconds, Player player)
    {
        yield return new WaitForSeconds(seconds);
        player.speed *= 2;
    }
}
