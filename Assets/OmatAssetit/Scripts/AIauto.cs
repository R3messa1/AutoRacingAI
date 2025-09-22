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
        // haetaan waypoint-listasta se piste, jota kohti auto on menossa
        Transform target = waypoints[currentWaypointIndex];
    }
}
