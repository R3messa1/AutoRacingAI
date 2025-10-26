using UnityEngine;

public class Tuomari : MonoBehaviour
{
    private void OnTriggerEnter(Collider auto)
    {
        // Haetaan CarIndentify-komponentti osuneesta GameObjectista
        CarIdentify id = auto.GetComponent<CarIdentify>();

        // Jos komponentti ei ole tällä objektilla (esim osuma tuli renkaasta)
        // etsitään se hierarkiassa ylöspäin ( auton pääobjekti)
        if (id == null)
        {

            id = auto.GetComponentInParent<CarIdentify>();
        }

        // Jos tunnistetta ei löydy, ei tiedetä kuka osui -> lopetetaan
        if (id == null)
        {
            return;
        }

        // Luetaan näkyvä nimi ja ilmoitetaan voittaja konsoliin
        string winnerName = id.displayName;
        Debug.Log($"WINNER: {winnerName}");
    }
}
