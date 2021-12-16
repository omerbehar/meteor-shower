using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float bulletSpeed = 15;
    public GameObject booster;
    public Sprite[] boosterArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((-transform.up * bulletSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boosterSpawn(boosterSelector());
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }

    private int boosterSelector()
    {
        if (Random.Range(0f, 1f) < 1f)
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
