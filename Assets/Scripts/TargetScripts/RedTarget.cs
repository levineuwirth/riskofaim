using UnityEngine;
using System.Collections;

public class RedTarget : Target
{
    void Start()
    {
        StartCoroutine(WaitForDestroy());
    }

}
