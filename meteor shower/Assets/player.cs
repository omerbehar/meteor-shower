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
        Camera cam = Camera.main;
        float width = 2f * cam.orthographicSize * cam.aspect - (GetComponent<SpriteRenderer>().bounds.size.x);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed, -width/2, width/2), transform.position.y, 0);
        if (Input.GetKeyDown(KeyCode.Space)) spawnBullet();
    }

    private void spawnBullet()
    {
        GameObject clone = Instantiate(bullet);
        float playerHeight = clone.GetComponent<SpriteRenderer>().bounds.size.y;
        clone.transform.position = new Vector3(transform.position.x, transform.position.y + playerHeight * 2, 0);
    }
}
