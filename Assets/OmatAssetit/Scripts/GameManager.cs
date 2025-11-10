using UnityEngine;

// Pelivaiheiden luettelo (enum)
public enum RacePhase { Countdown, Racing, Finished }
public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }


    // Pelin nykyinen vaihe
    public RacePhase Phase { get; set; } = RacePhase.Countdown;

    void Awake()
    {
        // Jos instance on jo asetettu johonkin muuhun gamemanageriin
        // ja se toinen ei ole "tämä"
        // tarkoittaa että meillä on duplikaatti
        // Tuhotaan tämä uusi, jotta säilyy vain yksi instanssi
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Poistetaan ylimääräinen
            return;              // lopetetaan ettei alla oleva koodi enää ajaudu
        }

        // Jos tänne päädytään, yhtään muuta instanssia ei ole
        // Rekisteroidään tämä singletoniksi
        Instance = this;

        // DontDestroyOnLoad tekee Gameobjektista "persistentin"
        // kun scene vaihtuu, tätä GameObjectia ei tuhota
        // Näin GameManager ja sen Phase säilyvät
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
