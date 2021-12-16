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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision);
        switch (gameObject.GetComponent<SpriteRenderer>().sprite.name)
        {

            case ("extra coins"):
                manager.addCoins(100);
                return;
            case ("extra life"):
                manager.addLives(1);
                return;
            case ("extra weapon"):
                manager.doubleWeapon();
                return;
        }
        Destroy(this.gameObject);
    }
}
