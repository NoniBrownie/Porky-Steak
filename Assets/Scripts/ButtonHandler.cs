using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private SymbolBoardManager rollButtonRefPlay;
    private SymbolDrop rollButtonRefClean;
    private SymbolMatch matchManagerRef;
    public MatchedSymbolReplacer matchedSymbolReplacer;

    void Start () 
    {
        rollButtonRefPlay = FindObjectOfType<SymbolBoardManager>();
        rollButtonRefClean = FindObjectOfType<SymbolDrop>();
        matchManagerRef = FindObjectOfType<SymbolMatch>();
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

        while(rollButtonRefPlay.boardGenerated == false)
        {
            yield return null;  //Program waits to board generation in order to start matching game symbols
        }

        yield return new WaitForSeconds(3f); 
        matchManagerRef.matchManager(); //Initialize symbol matching proccess 
        matchedSymbolReplacer.SymbolRefill(); //Initialize symbol refilling proccess
    }

}
