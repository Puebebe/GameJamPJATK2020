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
            SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
            sr.flipY = !sr.flipY;
            StartCoroutine(revertPlayerFlipYAfterSeconds(3, sr));

        }
        Destroy(gameObject);
    }
    IEnumerator revertPlayerFlipYAfterSeconds(int seconds, SpriteRenderer sr)
    {
        yield return new WaitForSeconds(seconds);
        sr.flipY = !sr.flipY;
    }
}
