using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [field: SerializeField] public float timerDuration {get; private set;}
    [field: SerializeField] public TextMeshPro TimerText {get; private set;}
    private bool _timerOn = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
