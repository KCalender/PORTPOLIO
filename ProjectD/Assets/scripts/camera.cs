using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]
    Transform CameraLook;

    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.back * 2.0f + Vector3.up * 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mouseScrollDelta);

        distance += new Vector3(0, 0, Input.mouseScrollDelta.y / 10.0f);

        if (distance.z <= -8.0f)
            distance.z = -7.9f;
        else if (distance.z >= -1.0f)
            distance.z = -1.1f;

        transform.position = CameraLook.transform.position + distance;

        transform.LookAt(CameraLook);
    }
}
