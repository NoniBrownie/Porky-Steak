using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private SymbolSpawnManager rollButtonRefPlay;
    private SymbolDrop rollButtonRefClean;

    void Start () 
    {
        rollButtonRefPlay = FindObjectOfType<SymbolSpawnManager>();
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
