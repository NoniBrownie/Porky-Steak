using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardUpdate : MonoBehaviour
{       public void UpdatePhysicsInstance(Symbol symbol)
        {
            if (symbol.symbolObject != null)
            {
                SymbolPhysics physics = symbol.symbolObject.GetComponent<SymbolPhysics>();
                if (physics != null)
                {
                    physics.positionInColumn = symbol.positionInColumn;
                    physics.column = symbol.column;
                }
            }
        }
    

}
