using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private GameBoard rollButtonRefPlay;
    private SymbolDrop rollButtonRefClean;

    void Start () 
    {
        rollButtonRefPlay = FindObjectOfType<GameBoard>();
        rollButtonRefClean = FindObjectOfType<SymbolDrop>();
    }
    public void rollButtonPlay()
    {
        rollButtonRefClean.RollButton();
        StartCoroutine(WaitAndRoll());
    }

    private IEnumerator WaitAndRoll()
    {
        yield return new WaitForSeconds(0.25f); 
        rollButtonRefPlay.RollButton(); 
    }

}
