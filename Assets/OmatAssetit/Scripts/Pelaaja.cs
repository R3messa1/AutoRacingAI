using UnityEngine;

public class Pelaaja : MonoBehaviour
{
    // Pelaajan auton nopeus
    public float speed = 10f;

    //Pelaajan kääntymisnopeus
    public float turnSpeed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //Ei kirjoiteta vielä starttiin mitään 
    }

    // Update is called once per frame
    void Update()
    {
        // Luetaan pystysuuntainen liike
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Luetaan vaakasuuntainen liike
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        // Liikutetaan pelaajaa eteen- tai taaksepäin z-suunnassa (Unityssa forward)
        transform.Translate(Vector3.forward * move);
        
        // Käännetään pelaajaa Y-akselin ympäri 
        transform.Rotate(Vector3.up * turn);
    }
}
