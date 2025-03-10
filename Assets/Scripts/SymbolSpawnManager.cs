using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolSpawnManager : MonoBehaviour
{
    public GameObject[] symbolPrefabs;
    private float appearingOdds;
    private float[] xPositions = { -7, -5, -3, -1, 1, 3 }; // all X positions every column can have
    public GameObject[,] symbolsMatrix;

    void Start()
    {
    }

    public IEnumerator GenerateSymbol()
    {
        for (int col = 0; col < 6; col++) // 6 columnas
        {
            for (int row = 0; row < 5; row++) // 5 filas
            {
                Symbol newSymbol = new Symbol(0, 0, 0f, 0, 0);
                newSymbol.yPosition = 10 * 1.25f;
                newSymbol.xPosition = xPositions[col]; // sets X position according the column

                Maths rng = FindObjectOfType<Maths>();
                appearingOdds = rng.GenerateRandomNumber();

                //sets symbol tier according to number generated at SymbolMath
                if (appearingOdds >= 8400) newSymbol.tier = 1;
                else if (appearingOdds >= 7000) newSymbol.tier = 2;
                else if (appearingOdds >= 5700) newSymbol.tier = 3;
                else if (appearingOdds >= 4500) newSymbol.tier = 4;
                else if (appearingOdds >= 3400) newSymbol.tier = 5;
                else if (appearingOdds >= 2400) newSymbol.tier = 6;
                else if (appearingOdds >= 1500) newSymbol.tier = 7;
                else if (appearingOdds >= 700) newSymbol.tier = 8;
                else newSymbol.tier = 9;
                Debug.Log("random number: "+ appearingOdds);
                Debug.Log("Assigned Tier: " + newSymbol.tier);

                newSymbol.positionInColumn = row;

                Vector2 position = new Vector2(newSymbol.xPosition, newSymbol.yPosition);
                GameObject symbol = Instantiate(symbolPrefabs[newSymbol.tier - 1], position, Quaternion.identity);

                SymbolPhysics symbolPhysicsInstance = symbol.GetComponent<SymbolPhysics>();
                symbolPhysicsInstance.positionInColumn = newSymbol.positionInColumn;
                symbolPhysicsInstance.column = col;

                SpriteRenderer spriteRenderer = symbol.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;
                symbolPhysicsInstance.enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void RollButton()
    {
        StartCoroutine(GenerateSymbol());
    }
}
