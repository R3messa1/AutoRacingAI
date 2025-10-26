using UnityEngine;

public class AIauto : MonoBehaviour
{
    // Julkinen taulukko waypointseista
    public Transform[] waypoints;

    //Kertoo seuraavan waypoint indexin
    private int currentWaypointIndex = 0;

    public float speed = 10f;

    public float rotationSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        // haetaan waypoint-taulukosta se piste, jota kohti auto on menossa
        Transform target = waypoints[currentWaypointIndex];

        // Luodaan vektori, joka ottaa kohdepisteen x- ja z-koordinaatit, 
        // mutta säilyttää auton nykyisen y-koordinaatin
        Vector3 targetXZ = new Vector3(target.position.x, transform.position.y, target.position.z);

        // Lasketaan suuntavektori, johon auto haluaa kääntyä
        Vector3 direction = (targetXZ - transform.position).normalized;

        // Lasketaan käännös(rotaatio), joka osoittaa laskettuun suuntaan
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Käännetään autoa pehmeästi(Slerp)
        // kohti laskettua rotaatiota käyttäen rotationSpeed-arvoa
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Liikutetaan autoa sen omaan eteenpäin-suuntaan
        // (Transform.forward = eteenpäin) nopeuden ja ajan mukaan
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Lasketaan etäisyys auton ja nykyisen waypointin välillä
        // Jos etäisyys on pienempi kuin 2 yksikköä...
        if (Vector3.Distance(transform.position, target.position) < 2f)
        {
            // ...Siirrytään seuraavaan waypointiin
            // % (modulo) varmistaa, että kun viimeinen waypoint on saavutettu
            // Aloitetaan taas alusta (reitistä tulee "ympyrä").
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
