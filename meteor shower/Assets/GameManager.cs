using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public int lives = 3;
    public int weapon = 1;
    public GameObject meteorSprite;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMeteorites(3, 2, 10, 0.05f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnMeteorites(float delayTime, float size, int amount, float gravity)
    {
        for (int i = 0; i < amount; i++)
        {
            spawnMeteorite(size, gravity);
            yield return new WaitForSeconds(delayTime);
        }
    }

    private void spawnMeteorite(float size, float gravity)
    {
        GameObject clone = Instantiate(meteorSprite);
        clone.transform.localScale = new Vector3(size / 10, size / 10, size / 10);
        Vector3 startPosition = getStartPosition(clone.GetComponent<SpriteRenderer>().bounds.size);
        clone.transform.position = startPosition;
        clone.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    private Vector3 getStartPosition(Vector3 meteoriteSize)
    {
        Camera cam = Camera.main;
        float ySize = meteoriteSize.magnitude;
        float height = 2f * cam.orthographicSize;
        float width = Random.Range(-height * cam.aspect + ySize/2, height * cam.aspect - ySize/2);
        return new Vector3(width/2, height/2 + ySize/2, 0);
    }
    public void addCoins(int amount)
    {
        coins += amount;
    }

    public void addLives(int amount)
    {
        if (lives + amount > 3) lives = 3; else lives += amount;
    }

    public void doubleWeapon()
    {
        if (weapon == 1)
        {

        }
    }
}
