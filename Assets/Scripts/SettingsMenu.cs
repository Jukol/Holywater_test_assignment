using UnityEngine;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _moveTime = 0.5f;
    private Vector2 _startPosition, _targetPosition;

    private void Start()
    {
        _startPosition = new Vector2(_canvas.transform.position.x + Screen.width, _canvas.transform.position.y);
        _rectTransform.position = _startPosition;
        _targetPosition = new Vector2(_canvas.transform.position.x, _canvas.transform.position.y);
        gameObject.SetActive(false);
    }

    public void MoveOut()
    {
        Tween moveTween = _rectTransform.DOMove(_startPosition, _moveTime).SetEase(Ease.Linear);
        moveTween.OnComplete(() => gameObject.SetActive(false));
    }

    public void MoveIn()
    {
        gameObject.SetActive(true);
        _rectTransform.DOMove(_targetPosition, _moveTime).SetEase(Ease.Linear);
    }
}
