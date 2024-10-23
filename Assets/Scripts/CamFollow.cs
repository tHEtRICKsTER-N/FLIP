using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private Transform objectToFollow;

    [SerializeField] private float _yOffset;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, objectToFollow.localPosition.y + _yOffset, transform.localPosition.z);
    }
}
