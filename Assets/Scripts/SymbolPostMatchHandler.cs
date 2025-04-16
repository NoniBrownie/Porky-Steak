using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolPostMatchHandler : MonoBehaviour
{
    private SymbolRepositioning symbolRepositioning;
    private SymbolBoardManager spawnManager;
    private SymbolVisualSync symbolVisualSync;
    private SymbolMatch symbolMatch;
    private AfterMatchSymbolGeneration generateNewSymbols;

    void Start()
    {
        symbolRepositioning = FindObjectOfType<SymbolRepositioning>();
        spawnManager = FindObjectOfType<SymbolBoardManager>();
        symbolVisualSync = FindObjectOfType<SymbolVisualSync>();
        symbolMatch = FindObjectOfType<SymbolMatch>();
        generateNewSymbols = FindObjectOfType<AfterMatchSymbolGeneration>();
    }

    public void SymbolPhysicsUpdate()
    {
        if (symbolMatch != null && symbolMatch.matchFound)
        {
            symbolRepositioning.RepositionSymbols();

            for (int col = 0; col < 6; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    Symbol symbol = spawnManager.symbolsData[col, row];
                    if (symbol != null)
                    {
                        symbolVisualSync.UpdatePhysicsInstance(symbol);
                    }
                }
            }

            symbolMatch.matchFound = false;
            StartCoroutine(generateNewSymbols.generateNewSymbols());

        }
    }
}
