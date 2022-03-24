using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactOnTouch : MonoBehaviour
{

    private AudioSource _audio;

    public OperatorControl Operator { get; internal set; }

    private void OnTriggerEnter(Collider other)
    {
        if (Operator) return;
        _audio.Play();
        other.GetComponent<OperatorControl>().CurrentPos = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
