using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolPlacer
{
    private GameObject[] symbolPrefabs;

    public SymbolPlacer(GameObject[] symbolPrefabs)
    {
        this.symbolPrefabs = symbolPrefabs;
    }

    public void PlaceSymbol(Symbol symbol)
    {
        Vector2 position = new Vector2(symbol.xPosition, symbol.yPosition);
        GameObject symbolObject = Object.Instantiate(symbolPrefabs[symbol.tier - 1], position, Quaternion.identity);

        SymbolPhysics symbolPhysicsInstance = symbolObject.GetComponent<SymbolPhysics>();
        symbolPhysicsInstance.positionInColumn = symbol.positionInColumn;
        symbolPhysicsInstance.column = symbol.column;

        // Sprite settings
        SpriteRenderer spriteRenderer = symbolObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        symbolPhysicsInstance.enabled = true;
        symbol.symbolObject = symbolObject;
    }
}
