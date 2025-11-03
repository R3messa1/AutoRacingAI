using UnityEngine;

public class PelaajanKierrostarkistus : MonoBehaviour
{
    public int checkpointCount = 3; 
    // Kuinka monta checkpointtia (porttia) pelaajan pitää ohittaa kierroksen aikana.

    private bool[] visited;
    // Taulukko, jossa jokaiselle checkpointille on oma merkintä:
    // false = ei käyty, true = käyty tällä kierroksella.

    private int visitedCount;
    // Montako eri checkpointtia on tähän mennessä käyty (lasketaan vain kerran / checkpoint).

    void Awake()
    // Awake ajetaan heti, kun komponentti aktivoituu (ennen Startia) → alustetaan tila.
    {
        ResetLap();
    }

    public void ResetLap()
    // Nollaa kierroksen: merkit poistetaan ja laskuri nollataan.
    {
        visited = new bool[checkpointCount];
        visitedCount = 0;
    }

    public void MarkVisited(int index)
    // Merkitse tietty checkpoint käydyksi.
    // Jos sama checkpoint merkitään uudestaan, sitä EI lasketa toistamiseen.
    {
        if (!visited[index])
        {
            visited[index] = true;
            visitedCount++;
        }
    }

    public bool AllVisitedThisLap => visitedCount == checkpointCount;
    // Palauttaa true, jos kaikki checkpointit on käyty tällä kierroksella.
}
