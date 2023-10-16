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
    public Text LivesTMPro;
    const int MaxLives = 3;
    int lives;
    public float velocidadMovimiento = 5f;
    public int bulletPoolSize = 10;  // Tamaño del pool de balas
    public List<GameObject> bulletPool;  // Lista de balas en el pool

    void Start()
    {
        // Inicializar el pool de balas
        bulletPool = new List<GameObject>();
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(PlayerBulletGO);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        lives = MaxLives;
        LivesTMPro.text = lives.ToString();
        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }

    private Rigidbody2D rb;


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
        rb.velocity = movimiento;
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
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }

    void FireBullet(Vector3 position)
    {
        // Buscar una bala inactiva en el pool
        GameObject bullet = bulletPool.Find(b => !b.activeSelf);

        // Si encontramos una bala inactiva, la reutilizamos
        if (bullet != null)
        {
            bullet.transform.position = position;
            bullet.SetActive(true);
        }
    }
}
