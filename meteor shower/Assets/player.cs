using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 6;
    public GameObject bullet;
    public float bulletSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space)) spawnBullet();
    }

    private void spawnBullet()
    {
        GameObject clone = Instantiate(bullet);
        float playerHeight = clone.GetComponent<SpriteRenderer>().bounds.size.y;
        print(playerHeight);
        clone.transform.position = new Vector3(transform.position.x, transform.position.y + playerHeight, 0);
    }
}
