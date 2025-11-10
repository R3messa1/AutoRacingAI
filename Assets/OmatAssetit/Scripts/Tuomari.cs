using UnityEngine;

public class Tuomari : MonoBehaviour
{
    // Tämä varmistaa, että voittaja kirjoitetaan vain kerran
    private bool winnerDeclared = false;
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

        // Tarkistetaan onko voittaja jo ilmoitettu
        if (!winnerDeclared)
        {
            // Jos ei, tulostetaan voittaja ja merkitään että voittaja
            // on jo julistettu
            Debug.Log($"WINNER: {winnerName}");
            winnerDeclared = true;
        }
    }
}
