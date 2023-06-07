using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    //tikapuiden yläpään paikka
    public Transform topHandler;
    //tikapuiden alapään paikka
    public Transform bottomHandler;

    // Awake tapahtuu kerran ennen Start funktiota :)
    void Awake(){
        //haetaan tikkaiden pituus
        float height = GetComponent<SpriteRenderer>().size.y;

        //asetetaan tikkaiden yläpää
        topHandler.position = new Vector3(transform.position.x, transform.position.y + (height / 2), 0);

        //asetetaan tikkaiden alapää
        bottomHandler.position = new Vector3(transform.position.x, transform.position.y - (height / 2), 0);
    }
}
