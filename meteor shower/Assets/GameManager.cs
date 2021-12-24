using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public int lives = 3;
    public int weapon = 1;
    public Image life1;
    public Image life2;
    public Image life3;
    public Sprite life;
    public Sprite lifeless;
    public GameObject meteorSprite;
    public GameObject secondWeapon;
    public Text score;
    public GameObject player;
    public Image gameOverImage;
    // Start is called before the first frame update
    void Start()
    {
        secondWeapon.SetActive(false);

        StartCoroutine(spawnMeteorites(3f, 2, 20, 0.05f));
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
        updateLives();
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
        secondWeapon.SetActive(true);
        StartCoroutine(stopDoubleWeapon());
    }
    IEnumerator stopDoubleWeapon()
    {
        yield return new WaitForSeconds(3);
        secondWeapon.SetActive(false);
    }

    private void updateScore()
    {
        score.text = coins.ToString();
    }

    private void updateLives()
    {
        switch (lives)
        {
            case (1):
                life1.sprite = life;
                life1.SetNativeSize();
                life2.sprite = lifeless;
                life2.SetNativeSize(); 
                life3.sprite = lifeless;
                life3.SetNativeSize(); 
                break;
            case (2):
                life1.sprite = life;
                life1.SetNativeSize();
                life2.sprite = life;
                life2.SetNativeSize();
                life3.sprite = lifeless;
                life3.SetNativeSize();
                break;
            case (3):
                life1.sprite = life;
                life1.SetNativeSize();
                life2.sprite = life;
                life2.SetNativeSize();
                life3.sprite = life;
                life3.SetNativeSize();
                break;
            case (0):
                gameOver();
                break;
        }
    }
    private void gameOver()
    {
        Destroy(player);
        Color gameOverColor = gameOverImage.GetComponent<Image>().color;
        gameOverColor.a = 1;
        gameOverImage.GetComponent<Image>().color = gameOverColor;
    }
}
