using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Sequence _pointerEnterSequence;

    private void Awake()
    {
        _pointerEnterSequence = DOTween.Sequence();
        _pointerEnterSequence
            .Append(transform.DOScale(Vector3.one * 1.1f, 0.5f))
            .Append(transform.DOScale(Vector3.one, 0.5f))
            .SetLoops(-1)
            .SetEase(Ease.InSine)
            .OnPause(() =>
            {
                transform.DOScale(Vector3.one, 0f).Play();
            });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pointerEnterSequence.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pointerEnterSequence.Pause();
    }
}
