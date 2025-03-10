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
                if (symbol.tier == 1)
                {
                    Debug.LogWarning(" tier 1 symbol generated");
                }
                else
                {
                    Debug.LogWarning("nonas");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
