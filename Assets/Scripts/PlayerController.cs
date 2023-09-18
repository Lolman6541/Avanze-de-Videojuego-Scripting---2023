using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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

    public void Init()
    {
        lives = MaxLives;

        LivesTMPro.text = lives.ToString ();

        gameObject.SetActive (true);

    }

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO);
            bullet01.transform.position = bulletPosition01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate (PlayerBulletGO);
            bullet02.transform.position = bulletPosition02.transform.position;
        }
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movimientoX, movimientoY) * velocidadMovimiento * Time.deltaTime;

        rb.velocity = movimiento;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "EnemyShipTag") ||(col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            lives--;
            LivesTMPro.text = lives.ToString();
            
            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);



             gameObject.SetActive (false);
            }
            
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }
}