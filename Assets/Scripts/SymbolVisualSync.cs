using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolVisualSync : MonoBehaviour
{
    public void UpdatePhysicsInstance(Symbol symbol)
    {
        if (symbol != null && symbol.symbolObject != null)
        {
            SymbolPhysics physics = symbol.symbolObject.GetComponent<SymbolPhysics>();
            if (physics != null)
            {
                physics.positionInColumn = symbol.positionInColumn;
                physics.column = symbol.column;
                physics.UpdateLayer();
            }
        }
    }
}