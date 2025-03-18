using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maths : MonoBehaviour
{
    public int randomNumber;
    void Start()
    {
        int randomNumber = GenerateRandomNumber();
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(0, 9999);      //Generating 1 random number from 0 to 9999 range to stablish symbol's tier 
    }
}
