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
    public GameObject symbolObject;

    public Symbol(float xPosition, float yPosition, float appearingOdds, int tier, int positionInColumn, GameObject symbolObject)
    {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.appearingOdds = appearingOdds;
        this.tier = tier;
        this.positionInColumn = positionInColumn;
        this.symbolObject = symbolObject;
    }    

}
