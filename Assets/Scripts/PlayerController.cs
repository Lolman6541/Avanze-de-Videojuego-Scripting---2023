using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject GameManagerGO;
    public GameObject PlayerBulletGO;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject ExplosionGO;
    public GameObject LifePickupGO; 
    public Text LivesTMPro;
    const int MaxLives = 3;
    int lives;
    public float velocidadMovimiento = 5f;
    public int bulletPoolSize = 10;
    public List<GameObject> bulletPool;
    private Rigidbody2D rb;

    public float minX, maxX, minY, maxY;

    void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(PlayerBulletGO);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
        rb = GetComponent<Rigidbody2D>();

        
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    public void Init()
    {
        lives = MaxLives;
        LivesTMPro.text = lives.ToString();
        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().Play();
            FireBullet(bulletPosition01.transform.position);
            FireBullet(bulletPosition02.transform.position);
        }

        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");
        Vector2 movimiento = new Vector2(movimientoX, movimientoY) * velocidadMovimiento * Time.deltaTime;

        
        float newX = Mathf.Clamp(transform.position.x + movimiento.x, minX, maxX);
        float newY = Mathf.Clamp(transform.position.y + movimiento.y, minY, maxY);

        rb.velocity = new Vector2(newX - transform.position.x, newY - transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag" || col.tag == "EnemyBulletTag" || col.tag == "AsteroidTag")
        {
            PlayExplosion();
            lives--;
            LivesTMPro.text = lives.ToString();

            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }
        else if (col.tag == "LifePickupTag")
        {
            lives++;
            LivesTMPro.text = lives.ToString();
            Destroy(col.gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }

    void FireBullet(Vector3 position)
    {
        GameObject bullet = bulletPool.Find(b => !b.activeSelf);
        if (bullet != null)
        {
            bullet.transform.position = position;
            bullet.SetActive(true);
        }
    }
}
