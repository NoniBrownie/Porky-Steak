using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolFactory
{
    private Maths rng;
    private float[] xPositions = { -7, -5, -3, -1, 1, 3 }; // all X positions every column can have

    public SymbolFactory()
    {
        rng = Object.FindObjectOfType<Maths>();
    }

    public Symbol CreateSymbol(int col, int row)
    {
        float appearingOdds = rng.GenerateRandomNumber();
        int tier = DetermineTier(appearingOdds);
        return new Symbol(xPositions[col], 10 * 1.25f, appearingOdds, tier, row, col, null);
    }

    private int DetermineTier(float appearingOdds)
    {
        if (appearingOdds >= 8400) return 1;
        else if (appearingOdds >= 7000) return 2;
        else if (appearingOdds >= 5700) return 3;
        else if (appearingOdds >= 4500) return 4;
        else if (appearingOdds >= 3400) return 5;
        else if (appearingOdds >= 2400) return 6;
        else if (appearingOdds >= 1500) return 7;
        else if (appearingOdds >= 700) return 8;
        else return 9;
    }
}
