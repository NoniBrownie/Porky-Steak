using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SymbolDrop : MonoBehaviour
{

    private GameObject bouncePlatformFolder;
    // Start is called before the first frame update
    void Start()
    {
        bouncePlatformFolder = GameObject.Find("bouncePlatform");
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

        foreach (BoxCollider2D collider in bouncePlatformFolder.GetComponentsInChildren<BoxCollider2D>())
        {
            collider.enabled = false;
        }

        yield return new WaitForSeconds(0.5f);

        foreach (BoxCollider2D collider in bouncePlatformFolder.GetComponentsInChildren<BoxCollider2D>()) 
        {
            collider.enabled = true;
        }

    } 

}
