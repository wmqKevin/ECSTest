using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardObj : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }
}
