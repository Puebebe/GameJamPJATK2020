using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinach : MonoBehaviour
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
            player.transform.localScale *= 2;
<<<<<<< Updated upstream
            player.StartCoroutine(revertPlayerScaleAfterSeconds(3, player));
=======
            StartCoroutine(revertPlayerScaleAfterSeconds(3, player));
            Debug.Log(player.gameObject.name);

>>>>>>> Stashed changes
        }
        Destroy(gameObject);
    }

    IEnumerator revertPlayerScaleAfterSeconds(int seconds, Player player)
    {
        yield return new WaitForSeconds(seconds);
        player.transform.localScale /= 2;
    }
}
