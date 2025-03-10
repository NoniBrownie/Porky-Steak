using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private SymbolSpawnManager rollButtonRefPlay;
    private SymbolDrop rollButtonRefClean;
    private SymbolMatch matchManagerRef;

    void Start () 
    {
        rollButtonRefPlay = FindObjectOfType<SymbolSpawnManager>();
        rollButtonRefClean = FindObjectOfType<SymbolDrop>();
        matchManagerRef = FindObjectOfType<SymbolMatch>();
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

        while(rollButtonRefPlay.boardGenerated == false)
        {
            yield return null;
        }
        matchManagerRef.matchManager(); 
    }

}
