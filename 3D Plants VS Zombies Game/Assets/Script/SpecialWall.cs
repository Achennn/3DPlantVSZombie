using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWall : MonoBehaviour
{
    [SerializeField] GameObject[] specialWall;

    void TouchSpecialWall(Collider other)
    {
        foreach (GameObject wall in specialWall)
        {
            wall.SendMessage("Touched");
        }
    }
}
