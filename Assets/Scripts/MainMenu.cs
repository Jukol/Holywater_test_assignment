using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _moveTime = 0.5f;
    private float _canvasWidth;
    private Vector2 _startPosition, _hidePosition;

    private void Start()
    {
        _canvasWidth = _canvas.GetComponent<RectTransform>().rect.width;
        _startPosition = _rectTransform.position;
        _hidePosition = new Vector2(_canvas.transform.position.x - Screen.width, _canvas.transform.position.y);
    }

    public void MoveOut()
    {
        Tween moveTween = _rectTransform.DOMove(_hidePosition, _moveTime).SetEase(Ease.Linear);
        moveTween.OnComplete(() => this.gameObject.SetActive(false));
    }

    public void MoveIn()
    {
        this.gameObject.SetActive(true);
        _rectTransform.DOMove(_startPosition, _moveTime).SetEase(Ease.Linear);
    }
}
