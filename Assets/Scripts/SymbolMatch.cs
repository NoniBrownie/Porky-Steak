using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolMatch : MonoBehaviour
{
    private SymbolSpawnManager spawnManager;
    private int[] symbolsCounter = new int[9];
    private int rollsCounter = 0;
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
                symbolsCounter[symbol.tier -1]++; //each  symbol has a position at symbolsCounter[] based on col & row
                Debug.Log("Symbol tier" + symbol.tier + " generatad  at column: " + symbol.positionInColumn);
                
            }
            rollsCounter++;
        }

        //Debug for symbol appearing to check statistics
        for (int i = 0; i < symbolsCounter.Length; i++)
        {
            Debug.LogWarning("Symbol tier: " + (i+1) + "has appeared a total of " + symbolsCounter[i] + " times");
        }

        Debug.LogWarning("Game has been rolled " + rollsCounter/6 + " times");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
