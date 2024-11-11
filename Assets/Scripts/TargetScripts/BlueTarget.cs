using UnityEngine;
using System.Collections;

public class BlueTarget : Target
{
    void Start()
    {
        StartCoroutine(WaitForDestroy());
    }

}
