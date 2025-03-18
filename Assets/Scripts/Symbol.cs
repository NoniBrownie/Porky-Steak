using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol
{
    public float xPosition;
    public float yPosition;
    public float symbolMultiplier;
    public float appearingOdds; 
    public int tier;
    public int positionInColumn;
    public int column;
    public GameObject symbolObject;

    public Symbol(float xPosition, float yPosition, float appearingOdds, int tier, int positionInColumn, int column, GameObject symbolObject)
    {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.appearingOdds = appearingOdds; 
        this.tier = tier;
        this.column = column;
        this.positionInColumn = positionInColumn;
        this.symbolObject = symbolObject;
    }    

}
