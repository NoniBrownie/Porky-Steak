using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolMatch : MonoBehaviour
{
    private SymbolSpawnManager spawnManager;

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
                    case 1: Debug.LogWarning("tier 1 symbol generated at column: " + symbol.positionInColumn); break;
                    case 2: Debug.LogWarning("tier 2 symbol generated at column: " + symbol.positionInColumn); break;
                    case 3: Debug.LogWarning("tier 3 symbol generated at column: " + symbol.positionInColumn); break;
                    case 4: Debug.LogWarning("tier 4 symbol generated at column: " + symbol.positionInColumn); break;
                    case 5: Debug.LogWarning("tier 5 symbol generated at column: " + symbol.positionInColumn); break;
                    case 6: Debug.LogWarning("tier 6 symbol generated at column: " + symbol.positionInColumn); break;
                    case 7: Debug.LogWarning("tier 7 symbol generated at column: " + symbol.positionInColumn); break;
                    case 8: Debug.LogWarning("tier 8 symbol generated at column: " + symbol.positionInColumn); break;
                    case 9: Debug.LogWarning("tier 9 symbol generated at column: " + symbol.positionInColumn); break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
