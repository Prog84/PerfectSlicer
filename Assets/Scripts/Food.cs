using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int _score;
    
    private float _delayDestroy = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Slicer slicer))
        {
            StartCoroutine(DestroyFood());
        }
    }

    private IEnumerator DestroyFood()
    {
        while (true)
        {
            Debug.Log("Вы заработали: " + _score);
            yield return new WaitForSeconds(_delayDestroy);
            Destroy(gameObject);
        }
    }
}
