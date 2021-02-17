using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int _score;
    
    private float _delayDestroy = 3f;

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
            yield return new WaitForSeconds(_delayDestroy);
            Debug.Log("Вы заработали: " + _score);
            Destroy(gameObject);
        }
    }
}
