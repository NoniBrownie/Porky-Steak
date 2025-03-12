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
        List<Symbol> symbolsToDelete = new List<Symbol>();
        symbolsCounter = new int[9];
        for (int col = 0; col < 6; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                Symbol symbol = spawnManager.symbolsData[col, row];
                symbolsCounter[symbol.tier -1]++; //each  symbol has a position at symbolsCounter[] based on col & row
            }
            rollsCounter++;
        }
        
        //repeated symbols removal after repeated symbol counter
        for (int col = 0; col < 6; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                Symbol symbol = spawnManager.symbolsData[col, row];

                if (symbolsCounter[symbol.tier - 1] >= 7)
                {
                    symbolsToDelete.Add(symbol);
                }
            }
        }

        //symbol remover 
        foreach (Symbol symbol in symbolsToDelete)
        {
            Debug.LogWarning("Eliminando símbolo de tier " + symbol.tier);
            Destroy(symbol.symbolObject);
        }

        //Debug for symbol appearing to check statistics
        for (int i = 0; i < symbolsCounter.Length; i++)
        {
            Debug.Log("Symbol tier: " + (i+1) + "has appeared a total of " + symbolsCounter[i] + " times");
        }

        Debug.LogWarning("Game has been rolled " + rollsCounter/6 + " times");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
