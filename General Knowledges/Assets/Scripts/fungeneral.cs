using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class fungeneral : MonoBehaviour
{
    private Vector3 _orginalScale;
    private Vector3 scaleTo;
    void Start()
    {
        _orginalScale = this.transform.localScale;
        scaleTo = _orginalScale / 1.1f;
        this.transform.DOScale(scaleTo, 2.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

   
}
