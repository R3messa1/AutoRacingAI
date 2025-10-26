using UnityEngine;

// Enum = oma keksitty tietotyyppi, joka sisältää listan nimettyjä vaihtoehtoja
// Se on vähän kuin valikko, josta voi valita yhden arvon
// Tämä enum kertoo onko auto pelaajan vai tekoälyn ohjaama
public enum CarKind
{
    Player, // Pelaajan auto

    AI // Tekoälyauto
}

// Tämän skriptin avulla voidaan tunnistaa auto (nimi + tyyppi) esim voittajaa varten
public class CarIdentify : MonoBehaviour
{
    //Näkyvä nimi, joka voidaan näyttää UI:ssa tai konsolissa
    public string displayName = "Player";
    // Enum näkyy Unityn inspectorissa
    // Näin voimme helposti valita kumpaa tyyppiä auto on
    public CarKind kind = CarKind.Player;
}
