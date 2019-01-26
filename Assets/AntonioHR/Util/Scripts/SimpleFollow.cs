using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;


    public void LateUpdate()
    {
        if (target != null)
            GoToTarget();
    }

    private void GoToTarget()
    {
        transform.position = target.TransformPoint(Vector3.zero);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
