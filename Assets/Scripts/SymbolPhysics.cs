using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolPhysics : MonoBehaviour
{
    public int hasBounced = 0;
    private Rigidbody2D rb;
    private GameObject symbol;
    public int verticalBounce = 9;
    public int column;
    public int positionInColumn; 

    void Start()
    {
        symbol = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        UpdateLayer();
    }

    public void UpdateLayer()
    {
        switch (positionInColumn)
        {
            case 0: gameObject.layer = LayerMask.NameToLayer("SBDJ0"); break;
            case 1: gameObject.layer = LayerMask.NameToLayer("SBDJ1"); break;
            case 2: gameObject.layer = LayerMask.NameToLayer("SBDJ2"); break;
            case 3: gameObject.layer = LayerMask.NameToLayer("SBDJ3"); break;
            case 4: gameObject.layer = LayerMask.NameToLayer("SBDJ4"); break;
            case 5: gameObject.layer = LayerMask.NameToLayer("SBDJ5"); break;
        }
    }

    

    void FixedUpdate()
    {   //hasBounced maganages when should a symbol bounce
        if (hasBounced == 1)    
        {
            Bounce();   //when a symbol collision for the first time, it bounces
            hasBounced = 2;
        }
        if (hasBounced == 3)
        {
            secondBounce();     //smaller secound bounce to make animation smoother
            hasBounced = 4;     //when in 4 symbols will no longer bounce
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "symbolPlatform")
        {
            hasBounced++;
        }
    }

    void Bounce()
    {
        rb.AddForce(Vector2.up * verticalBounce, ForceMode2D.Impulse);
    }

    void secondBounce()
    {
        rb.AddForce(Vector2.up * (verticalBounce - 4), ForceMode2D.Impulse);
    }
}
