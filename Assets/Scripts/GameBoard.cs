using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{

    protected int width = 6;
    protected int height = 5;  
    public GameObject[] symbols;
    public GameObject[,] board;
    
    private SpriteRenderer spriteRenderer;
    private SymbolPhysics symbolPhysics;



    void Start()
    {
        board = new GameObject[width,height];
    }

    public void RollButton() //Para crear el botón
    {
        StartCoroutine(rollSymbols());
    }

    protected virtual IEnumerator rollSymbols()
    {
    int contador = 0;

    for (int i = 0; i < width; i++) // i = eje x
    {
            Vector2 position = new Vector2(0,10);
            if (i == 0)
            {
                position.x=-7;
            }
            else if (i == 1)
            {
                position.x=-5;
            }
            else if (i == 2)
            {
                position.x=-3;
            }
            else if (i == 3)
            {
                position.x=-1;
            }
            else if (i == 4)
            {
                position.x=1;
            }
            else if (i == 5)
            {
                position.x=3;
            }

        for (int j = 0; j < height; j++) // j = eje y
        {
            position.y = position.y + j*1.05f;
            int randomIndex = Random.Range(0, symbols.Length);
            GameObject symbol = Instantiate(symbols[randomIndex], position, Quaternion.identity);

            //para adjuntar las fisicas a cada simbolo independientemente
            SymbolPhysics symbolPhysicsInstance = symbol.GetComponent<SymbolPhysics>();
            symbolPhysicsInstance.i = i;
            symbolPhysicsInstance.j = j;
   
            board[i, j] = symbol;
            contador++;
            
            //propiedades de los simbolos
            
            SpriteRenderer spriteRenderer = symbol.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled=true;
            symbolPhysicsInstance.enabled=true;
  
            BoxCollider2D boxcollider = symbol.GetComponent<BoxCollider2D>();
            boxcollider.enabled=true;
            
                Debug.Log($"Símbolo generado en [{i}, {j}]: {symbol.name}");
            //esperar x segundos para generar la siguiente columna
                if (contador==5)
                {
                yield return new WaitForSeconds(0.1f);
                contador= 0;
                }  
                yield return new WaitForSeconds(0.02f);

        }
    }

    }

}


