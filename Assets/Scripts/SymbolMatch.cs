using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolMatch : MonoBehaviour
{
    private SymbolBoardManager spawnManager;
    private int[] symbolsCounter = new int[9];
    private int rollsCounter = 0;
    public bool matchFound;
    // Start is called before the first frame update
    void Start()
    {
      spawnManager = FindObjectOfType<SymbolBoardManager>();
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
        
        //For iteration to add Match-7 symbols to symbolsToDelete list
        for (int col = 0; col < 6; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                Symbol symbol = spawnManager.symbolsData[col, row];

                if (symbol != null && symbolsCounter[symbol.tier - 1] >= 8)   //Evaluating with 8 so only symbols with 8 or more matches will be added to symbolsToDelete list
                {
                    symbolsToDelete.Add(symbol);
                
                }
            }
        }

        if (symbolsToDelete.Count > 0)
        {
            matchFound = true;
        }
        else
        {
            matchFound = false;
        }

        //symbol remover 
        foreach (Symbol symbol in symbolsToDelete)
        {
            Debug.LogWarning("Removing symbol of tier " + symbol.tier); 
            Destroy(symbol.symbolObject);
            spawnManager.symbolsData[symbol.column,symbol.positionInColumn] =null;
         }
        

        //Debug for symbol appearing to check statistics
        for (int i = 0; i < symbolsCounter.Length; i++)
        {
            Debug.Log("Symbol tier: " + (i+1) + "has appeared a total of " + symbolsCounter[i] + " times");
        }

        Debug.LogWarning("Game has been rolled " + rollsCounter/6 + " times");
        
    }
}
