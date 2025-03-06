using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SymbolDrop : MonoBehaviour
{

    private GameObject sddFolder;
    // Start is called before the first frame update
    void Start()
    {
        sddFolder = GameObject.Find("SDD");
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

        foreach (BoxCollider2D collider in sddFolder.GetComponentsInChildren<BoxCollider2D>())
        {
            collider.enabled = false;
        }

        yield return new WaitForSeconds(0.5f);

        foreach (BoxCollider2D collider in sddFolder.GetComponentsInChildren<BoxCollider2D>()) 
        {
            collider.enabled = true;
        }

    } 

}
