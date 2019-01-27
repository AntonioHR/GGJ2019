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
    private bool loop = false;
    [SerializeField]
    private Transform targetRef;
    [SerializeField]
    private float time = .5f;
    [SerializeField]
    private Ease individualEase = Ease.OutQuad;
    [SerializeField]
    private Ease totalEase = Ease.Linear;
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
        seq.Insert(0, transform.DOMove(pos, time)).SetEase(individualEase);
        seq.Insert(0, transform.DORotateQuaternion(rot, time)).SetEase(individualEase);
        seq.SetEase(totalEase);
        seq.OnComplete(OnFinished.Invoke);

        if (loop)
            seq.SetLoops(-1, LoopType.Yoyo);
    }

    [Button]
    private void CreateChildForRef()
    {
        var obj = new GameObject("Simple Move Target");
        obj.transform.parent = transform;
        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        targetRef = obj.transform;
    }

    private void OnDrawGizmosSelected()
    {
        if (targetRef == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetRef.transform.position, .05f);
        Gizmos.DrawLine(transform.position, targetRef.transform.position);
    }
}
