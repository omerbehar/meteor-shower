using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float bulletSpeed = 15;
    public GameObject booster;
    public Sprite[] boosterArray;
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((-transform.up * bulletSpeed * Time.deltaTime));
    }

    private void OnEnable()
    {
        GameObject[] boosters = GameObject.FindGameObjectsWithTag("booster");
        foreach (GameObject booster in boosters)
        {
            if (booster.GetComponent<Collider2D>() != null)
                Physics2D.IgnoreCollision(booster.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "booster")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        } 
        else if (collision.transform.tag == "edge")
        {
            Destroy(gameObject);
        }
        else
        {
            manager.addCoins(100);
            boosterSpawn(boosterSelector());
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        
    }

    private int boosterSelector()
    {
        if (Random.Range(0f, 1f) < 0.8f)
        {
            return Random.Range(1, 4);
        }
        else return 0;
    }
    private void boosterSpawn(int selection)
    {
        if (selection != 0)
        {
            GameObject clone = Instantiate(booster);
            clone.GetComponent<SpriteRenderer>().sprite = boosterArray[selection - 1];
            clone.transform.position = transform.position;
        }
    }
}
