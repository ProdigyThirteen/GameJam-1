using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyPawBobbing : MonoBehaviour
{
    public float bobbingHeight = 0.5f; 

    public float bobbingSpeed = 2f;     

    private Vector3 initialPosition;

    void Start()
    {
        
        initialPosition = transform.position;
    }

    void Update()
    {
        
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
