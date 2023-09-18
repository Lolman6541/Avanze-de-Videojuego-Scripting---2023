using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        // Obtiene las coordenadas del mundo correspondientes a la esquina superior derecha del viewport de la cámara
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        // Compara la posición Y del objeto con la coordenada Y máxima obtenida de la cámara
        if (transform.position.y > max.y)
        {
           Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "EnemyShipTag")
        {
            Destroy(gameObject);
        }
    }
}
