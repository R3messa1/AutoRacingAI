using UnityEngine;

public class CheckpointTarkistus : MonoBehaviour
{
    // Tämän checkpointin järjestysnumero radalla 0
    public int orderIndex = 0;

    // Kutsutaan, kun jokin collider kulkee tämän objektin trigger-collider läpi
    // "other" on osuneen objektin collider (esim. auton runko tai sen osa)
    private void OnTriggerEnter(Collider other)
    {
        // Lokitetaan debugia: mikä portti ja mikä objekti osui.
        Debug.Log($"Portti {orderIndex} osui: {other.name}");

        // Haetaan osujan hierarkiasta pelaajan kierrostarkistin
        var validator = other.GetComponentInParent<PelaajanKierrostarkistus>();

        // Jos tarkistin löytyy, merkitään tämä portti käydyksi
        if (validator != null)
        {
            validator.MarkVisited(orderIndex);
        }
        // Jos validator on null, mitään ei tehdä: 
        // osuja ei ollut pelaaja tai siltä puuttuu tarkistin

    }

}
