using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{
    public GameManager manager;
    public int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed, 0);
    }
    private void OnEnable()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject bullet in bullets)
        {
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            switch (gameObject.GetComponent<SpriteRenderer>().sprite.name)
            {
                case ("extra coins"):
                    manager.addCoins(500);
                    break;
                case ("extra life"):
                    manager.addLives(1);
                    break;
                case ("extra weapon"):
                    manager.doubleWeapon();
                    break;
            }
            Destroy(GetComponent<CircleCollider2D>());
            speed = 0;
            GetComponent<Animator>().SetTrigger("onBoosterTaken");
            Destroy(this.gameObject, 0.25f);
        }
        if (collision.transform.tag == "edge")
        {
            Destroy(this.gameObject);
        }
    }
}
