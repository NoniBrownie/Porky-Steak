using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolPhysics : MonoBehaviour
{
    public int hasCollided = 0; //0 para no colisionado y el resto para colisionado
    private Rigidbody2D rb;
    private GameObject symbol;
    public float speed = 0.2f;
    public GameBoard gameBoard;
    public int i;
    public int j;

void Start()
{

    //Symbol and symbol drop interaction
    gameBoard = FindObjectOfType<GameBoard>();
    symbol = gameBoard.board[i,j];
    rb = GetComponent<Rigidbody2D>();



    switch(j)
    {
        case 0:
        symbol.layer = LayerMask.NameToLayer("SBDJ0");
        break;
        case 1:
        symbol.layer = LayerMask.NameToLayer("SBDJ1");
        break;
        case 2:
        symbol.layer = LayerMask.NameToLayer("SBDJ2");
        break;
        case 3:
        symbol.layer = LayerMask.NameToLayer("SBDJ3");
        break;
        case 4:
        symbol.layer = LayerMask.NameToLayer("SBDJ4");
        break;
    }
}
    void Update()
    {
    transform.Translate(Vector3.up * -speed * Time.deltaTime);

    }
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }    
    void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = hasCollided +1;
        if (hasCollided == 1)
        {
            setSpeed(0);
            Bounce();

            switch(j)
            {
                case 0:
                symbol.layer = LayerMask.NameToLayer("SDDJ0");
                break;
                case 1:
                symbol.layer = LayerMask.NameToLayer("SDDJ1");
                break;
                case 2:
                symbol.layer = LayerMask.NameToLayer("SDDJ2");
                break;
                case 3:
                symbol.layer = LayerMask.NameToLayer("SDDJ3");
                break;
                case 4:
                symbol.layer = LayerMask.NameToLayer("SDDJ4");
                break;
            }

        }
 
        
    }

    void Bounce()
    {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);   

    }

    
}
