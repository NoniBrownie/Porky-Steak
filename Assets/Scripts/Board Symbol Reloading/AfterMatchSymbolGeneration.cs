using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterMatchSymbolGeneration : MonoBehaviour
{
    private SymbolBoardManager spawnManager;
    public GameObject[] symbolPrefabs;
    public Symbol[,] newSymbolGeneration;
    private SymbolFactory symbolFactory;
    private SymbolPlacer symbolPlacer;
    private SymbolMatch symbolMatch;

    // Start is called before the first frame update
    void Start()
    {
        newSymbolGeneration = new Symbol[6,5];
        symbolFactory = new SymbolFactory();
        symbolPlacer = new SymbolPlacer(symbolPrefabs);
        spawnManager = FindObjectOfType<SymbolBoardManager>();
        symbolMatch = FindObjectOfType<SymbolMatch>();
                
    }

    public void generateNewSymbols()
    {
        if(symbolMatch.waitingForRefill == true)
        {
            for (int col = 0; col < 6; col++)
            {
                for (int row = 0; row < 5; row++ )
                {
                    if (spawnManager.symbolsData[col,row] == null)
                    {
                        Symbol newSymbol = symbolFactory.CreateSymbol(col,row);
                        symbolPlacer.PlaceSymbol(newSymbol);
                        newSymbolGeneration[col,row] = newSymbol; 
                        Debug.Log("Generating new symbols after matching process");
                    }
                }
            }
            symbolMatch.waitingForRefill = false;
        }


    }
}
