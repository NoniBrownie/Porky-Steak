using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MatchedSymbolReplacer : MonoBehaviour
{

    [SerializeField] private SymbolBoardManager symbolBoardManager;
    // Start is called before the first frame update
    IEnumerator Start()
    {

        if (symbolBoardManager == null)
        {
            Debug.Log("SymbolBoard Manager isn't loaded correctly");
        }

        while (symbolBoardManager.boardGenerated == false)
        {
            yield return null;      //Ininite while loop that only stops when board is generated.
                                    //This looks for board's generation in order to check board changes (to evaluate if it is needed to refill)
        }

    }

    public void SymbolRefill()
    {
        for (int col = 0; col < 6; col++) // 6 columns
        {
            for (int row = 0; row < 5; row++) // 5 rows
            {
                if (symbolBoardManager.symbolsData[col,row] != null)
                {
                    Debug.Log("Detected symbol at column: " + col +" and row: "+ row);
                }
                else
                {
                    Debug.Log("Symbol at column "+ col + "and row: " +row + " DOESN'T EXIST");
                }
            }
                
        }
    }
}
