using DG.Tweening;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleMove : MonoBehaviour
{
    [SerializeField]
    private bool triggerAtStart;
    [SerializeField]
    private Transform targetRef;
    [SerializeField]
    private float time = .5f;
    [SerializeField]
    private UnityEvent OnFinished;


    void Start()
    {

        if (triggerAtStart)
            StartMove();
    }

    [Button]
    public void StartMove()
    {
        var pos = targetRef.transform.position;
        var rot = targetRef.transform.rotation;

        var seq = DOTween.Sequence();
        seq.Insert(0, transform.DOMove(pos, time));
        seq.Insert(0, transform.DORotateQuaternion(rot, time));
        seq.OnComplete(OnFinished.Invoke);
    }

    [Button]
    private void CreateChildForRef()
    {
        var obj = new GameObject();
        obj.transform.parent = transform;
        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        targetRef = obj.transform;
    }
}
