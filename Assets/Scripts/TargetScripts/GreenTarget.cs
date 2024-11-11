using UnityEngine;
using System.Collections;

public class GreenTarget : Target
{
    void Start()
    {
        StartCoroutine(WaitForDestroy());
    }

}
