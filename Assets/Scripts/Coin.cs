using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Coin : MonoBehaviour
{
    private float _rotationDegree = 3f;
    private Vector3 _rotation;
    private Vector3 _startPosition, _targetPosition;
    private WaitForSeconds _timeBeforeDectivateYield;
    private Tween _moveMe, _rotateMe;
    [SerializeField] private float _coinLife = 5f;

    public static event Action OnPickup;

    private void Start()
    {
        _rotation = new Vector3(0, _rotationDegree, 90);
        _startPosition = transform.position;
        _targetPosition = new Vector3(_startPosition.x, 1.32f, _startPosition.z);
        _timeBeforeDectivateYield = new WaitForSeconds(_coinLife);
        MoveDown();
    }

    private void OnDisable()
    {
        DestroyCoin();
    }

    private void MoveDown()
    {
        _moveMe = transform.DOMove(_targetPosition, 1f);
        _moveMe.SetEase(Ease.InSine);
        _moveMe.OnComplete(() => RotateMe());
        StartCoroutine(DestroyAfterAWhile());
    }

    private void RotateMe()
    {
        _rotateMe = transform.DORotate(_rotation, 0.2f);
        _rotateMe.SetEase(Ease.Linear);
        _rotateMe.SetLoops(-1, LoopType.Incremental);
    }

    private IEnumerator DestroyAfterAWhile()
    {
        yield return _timeBeforeDectivateYield;
        DestroyCoin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickup?.Invoke();
            DestroyCoin();
        }
    }

    private void DestroyCoin()
    {
        _moveMe.Kill();
        _rotateMe.Kill();
        Destroy(gameObject);
    }
}
