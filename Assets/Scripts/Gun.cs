using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] List<Bullet> bullets;
    private float fireRate;
    private float nextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFireTime = Time.time + fireRate;
    }

    public void Fire()
    {
        if (Time.time < nextFireTime)
            return;

        Bullet randomBullet = bullets[Random.Range(0, bullets.Count)];
        Bullet bullet = Instantiate(randomBullet, transform.position, Quaternion.identity);
        bullet.transform.localScale = transform.localScale;
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.force * transform.right);

        nextFireTime = Time.time + fireRate;
    }
}
