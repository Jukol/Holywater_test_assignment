using System.Collections;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static event Action OnPickup;

    [SerializeField] private float _coinLife = 5f;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _rotateSpeed;

    private WaitForSeconds _timeBeforeDectivateYield;
    private bool _canRotate;

    private void Start()
    {
        _timeBeforeDectivateYield = new WaitForSeconds(_coinLife);
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterAWhile());
    }

    private void OnDisable()
    {
        DeactivateCoin();
    }

    private void Update()
    {
        if (_canRotate)
        {
            transform.Rotate(_rotateSpeed * Time.deltaTime, 0, 0);
        }
    }

    private IEnumerator DestroyAfterAWhile()
    {
        yield return _timeBeforeDectivateYield;
        DeactivateCoin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickup?.Invoke();
            DeactivateCoin();
        }
        else if (other.gameObject.name == "Ground")
        {
            _rigidBody.useGravity = false;
            _rigidBody.isKinematic = true;
            _canRotate = true;
        }
    }

    private void DeactivateCoin()
    {
        _canRotate = false;
        _rigidBody.useGravity = true;
        _rigidBody.isKinematic = false;
        gameObject.SetActive(false);
    }
}
