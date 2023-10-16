using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets;

    Queue<GameObject> avaliblePlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        avaliblePlanets.Enqueue (Planets [0]);
        avaliblePlanets.Enqueue (Planets [1]);
        avaliblePlanets.Enqueue (Planets [2]);
        
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePlanetDown()
    {
        EnqueuePlanets();


        if(avaliblePlanets.Count == 0)
           return;

        GameObject aPlanet = avaliblePlanets.Dequeue ();

        aPlanet.GetComponent<Planet> ().isMoving = true;



    }

    void EnqueuePlanets()
    {
        foreach(GameObject aPlanet in Planets)
        {
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                aPlanet.GetComponent<Planet>().ResetPosition();

                avaliblePlanets.Enqueue(aPlanet);

            }
        }
    }
}
