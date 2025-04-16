using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script used for symbol repositioning after matched symbols were removed.
public class SymbolRepositioning : MonoBehaviour
{
    private SymbolBoardManager spawnManager;

    void Start()
    {
        spawnManager = FindObjectOfType<SymbolBoardManager>();
    }

    public void RepositionSymbols()
    {
        for (int col = 0; col < 6; col++)
        {
            for (int row = 1; row < 5; row++)
            {
                Symbol currentSymbol = spawnManager.symbolsData[col, row];

                if (currentSymbol != null)
                {
                    int newRow = row;
                    while (newRow > 0 && spawnManager.symbolsData[col, newRow - 1] == null)
                    {
                        spawnManager.symbolsData[col, newRow - 1] = currentSymbol;
                        spawnManager.symbolsData[col, newRow] = null;
                        currentSymbol.positionInColumn = newRow - 1;

                        SymbolPhysics physics = currentSymbol.symbolObject.GetComponent<SymbolPhysics>();
                        if (physics != null)
                        {
                            physics.positionInColumn = currentSymbol.positionInColumn;
                            physics.column = currentSymbol.column;
                        }

                        newRow--;
                    }
                }
            }
        }
    }
}
