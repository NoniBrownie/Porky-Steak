using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolPhysics : MonoBehaviour
{
    public int hasBounced = 0; // values other  than 0 means it has bounced
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
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }  

    void Update()
    {
  
    }  
    void FixedUpdate()
    {
        

        if (hasBounced == 1)
        {
            Bounce();
            hasBounced = 2;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "symbolPlatform")
        {
            hasBounced++;
        }
    }

    void Bounce()
    {
            rb.AddForce(Vector2.up * 12, ForceMode2D.Impulse);   
            Debug.Log("un objeto ha rebotado");
    }

    
}
