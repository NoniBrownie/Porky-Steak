using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class only manages the generation and positioning of symbols. Board status is managed at BoardUpdate class
public class SymbolBoardManager : MonoBehaviour
{
    public GameObject[] symbolPrefabs;
    private SymbolFactory symbolFactory;
    private SymbolPlacer symbolPlacer;
    public Symbol[,] symbolsData;
    public bool boardGenerated = false;

    void Start()
    {
        symbolsData = new Symbol[6, 5];
        symbolFactory = new SymbolFactory();
        symbolPlacer = new SymbolPlacer(symbolPrefabs);
    }

    public IEnumerator GenerateSymbol()
    {
        for (int col = 0; col < 6; col++) // 6 columns
        {
            for (int row = 0; row < 5; row++) // 5 rows
            {
                Symbol newSymbol = symbolFactory.CreateSymbol(col, row);
                symbolPlacer.PlaceSymbol(newSymbol);
                symbolsData[col, row] = newSymbol;
            }
            yield return new WaitForSeconds(0.1f);
        }
        boardGenerated = true;
    }

    public void RollButton()
    {
        StartCoroutine(GenerateSymbol());
    }
}
