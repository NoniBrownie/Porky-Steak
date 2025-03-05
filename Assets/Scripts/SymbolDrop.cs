using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SymbolDrop : MonoBehaviour


{
    // Start is called before the first frame update
    void Start()
    {
  
    }

    public void RollButton() //Pal botón
    {
        StartCoroutine(removeBoard());
    } 

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "symbolKiller")
        {
            Destroy(gameObject);
        } 
    }
    
    public IEnumerator removeBoard() 
    {
        for (int i = 0; i <= 4; i++)
        {
            //poner J LUEGO DE SDD PARA QUE FUNCIONE
            string tag = "SDD " + i;
            GameObject[] symbolDropDrivers = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject symbolDropDriver in symbolDropDrivers)
            {
                BoxCollider2D boxColliderSDD = symbolDropDriver.GetComponent<BoxCollider2D>();
                if (boxColliderSDD != null)
                {
                    boxColliderSDD.enabled = false;
                      yield return new WaitForSeconds(0.1f);
                    
                }
            }
        }
        
    } 

}
