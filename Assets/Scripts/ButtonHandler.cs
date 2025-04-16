using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private SymbolBoardManager rollButtonRefPlay;
    private SymbolDrop rollButtonRefClean;
    private SymbolMatch matchManagerRef;
    private SymbolPostMatchHandler symbolPhysicsUpdater;
    private AfterMatchSymbolGeneration newSymbolGeneration;
    void Start () 
    {
        rollButtonRefPlay = FindObjectOfType<SymbolBoardManager>();
        rollButtonRefClean = FindObjectOfType<SymbolDrop>();
    }
    public void rollButtonPlay()
    {
        rollButtonRefClean.RollButton(); //This method guarantee the already placed symbols in board to fall
        StartCoroutine(WaitAndRoll()); //Wait a few in order to clean the board and generate the next round of symbols
    }

    private IEnumerator WaitAndRoll()
    {
        yield return new WaitForSeconds(0.25f); 
        rollButtonRefPlay.RollButton();
    }

}
