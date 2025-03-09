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
        return Random.Range(0, 9999);
    }
}
