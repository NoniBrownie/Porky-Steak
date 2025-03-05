using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : GameBoard
{
    void Start()
    {
        StartCoroutine(rollSymbols());
    }

    protected override IEnumerator rollSymbols()
    {
        // Llamamos al método base para llenar el tablero
        yield return base.rollSymbols();

        // Ahora verifica si el tablero ha sido llenado correctamente
        for (int i = 0; i < width; i++) // i = eje x
        {
            for (int j = 0; j < height; j++) // j = eje y
            {
                // Verifica que el símbolo no sea nulo
                GameObject symbol = board[i, j];
                if (symbol != null)
                {
                    Vector2 newPos = new Vector2(1, 1); // Establece una nueva posición
                    symbol.transform.position = newPos; // Cambia la posición del símbolo
                    Debug.Log($"Símbolo en [{i}, {j}] movido a {newPos}"); // Agrega un log para verificar
                }
                else
                {
                    Debug.LogWarning($"Símbolo en la posición {i}, {j} es nulo.");
                }
            }
        }
    }
}
