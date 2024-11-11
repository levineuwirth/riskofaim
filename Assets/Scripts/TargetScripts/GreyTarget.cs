using UnityEngine;
using System.Collections;

public class GreyTarget : Target
{
    void Start()
    {
        StartCoroutine(WaitForDestroy());
    }

}
