using UnityEngine;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _moveTime = 0.5f;
    private float _canvasWidth;
    private Vector2 _startPosition, _targetPosition;

    private void Start()
    {
        var myWidth = _rectTransform.rect.width;
        _canvasWidth = _canvas.GetComponent<RectTransform>().rect.width;
        _startPosition = new Vector2(_canvas.transform.position.x + Screen.width, _canvas.transform.position.y);
        _rectTransform.position = _startPosition;
        _targetPosition = new Vector2(_canvas.transform.position.x, _canvas.transform.position.y);
        this.gameObject.SetActive(false);
    }

    public void MoveOut()
    {
        Tween moveTween = _rectTransform.DOMove(_startPosition, _moveTime).SetEase(Ease.Linear);
        moveTween.OnComplete(() => this.gameObject.SetActive(false));
    }

    public void MoveIn()
    {
        this.gameObject.SetActive(true);
        _rectTransform.DOMove(_targetPosition, _moveTime).SetEase(Ease.Linear);
    }
}
