using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolMatch : MonoBehaviour
{
    private SymbolSpawnManager spawnManager;
    int symbol1Counter;
    int symbol2Counter;
    int symbol3Counter;
    int symbol4Counter;
    int symbol5Counter;
    int symbol6Counter;
    int symbol7Counter;
    int symbol8Counter;
    int symbol9Counter;
    int rollsCounter;
    // Start is called before the first frame update
    void Start()
    {
      spawnManager = FindObjectOfType<SymbolSpawnManager>();
    }

    public void matchManager()
    {
        for (int col = 0; col < 6; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                Symbol symbol = spawnManager.symbolsData[col, row];

                switch(symbol.tier)
                {
                    case 1: Debug.LogWarning("tier 1 symbol generated at column: " + symbol.positionInColumn); symbol1Counter++; break;
                    case 2: Debug.LogWarning("tier 2 symbol generated at column: " + symbol.positionInColumn); symbol2Counter++; break;
                    case 3: Debug.LogWarning("tier 3 symbol generated at column: " + symbol.positionInColumn); symbol3Counter++; break;
                    case 4: Debug.LogWarning("tier 4 symbol generated at column: " + symbol.positionInColumn); symbol4Counter++; break;
                    case 5: Debug.LogWarning("tier 5 symbol generated at column: " + symbol.positionInColumn); symbol5Counter++; break;
                    case 6: Debug.LogWarning("tier 6 symbol generated at column: " + symbol.positionInColumn); symbol6Counter++; break;
                    case 7: Debug.LogWarning("tier 7 symbol generated at column: " + symbol.positionInColumn); symbol7Counter++; break;
                    case 8: Debug.LogWarning("tier 8 symbol generated at column: " + symbol.positionInColumn); symbol8Counter++; break;
                    case 9: Debug.LogWarning("tier 9 symbol generated at column: " + symbol.positionInColumn); symbol9Counter++; break;
                }
            }
            rollsCounter++;
        }

        //Debug for symbol appearing check statistics
        Debug.Log("Símbolo 1 ha aparecido: " + symbol1Counter + " veces");
        Debug.Log("Símbolo 2 ha aparecido: " + symbol2Counter + " veces");
        Debug.Log("Símbolo 3 ha aparecido: " + symbol3Counter + " veces");
        Debug.Log("Símbolo 4 ha aparecido: " + symbol4Counter + " veces");
        Debug.Log("Símbolo 5 ha aparecido: " + symbol5Counter + " veces");
        Debug.Log("Símbolo 6 ha aparecido: " + symbol6Counter + " veces");
        Debug.Log("Símbolo 7 ha aparecido: " + symbol7Counter + " veces");
        Debug.Log("Símbolo 8 ha aparecido: " + symbol8Counter + " veces");
        Debug.Log("Símbolo 9 ha aparecido: " + symbol9Counter + " veces");
        Debug.LogWarning("Se ha tirado " + rollsCounter/6 + "veces");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
