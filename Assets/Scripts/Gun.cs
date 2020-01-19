using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] List<Bullet> bullets;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Bullet randomBullet = bullets[Random.Range(0, bullets.Count)];
        Bullet bullet = Instantiate(randomBullet, transform.position, Quaternion.identity);
        bullet.transform.localScale = transform.localScale;
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.force * transform.right);
    }
}
