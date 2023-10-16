using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 8f;
    }

    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        if (transform.position.y > max.y)
        {
            gameObject.SetActive(false);  // Desactivar en lugar de destruir
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag")
        {
            gameObject.SetActive(false);  // Desactivar en lugar de destruir
        }
    }
}
