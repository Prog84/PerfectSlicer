using UnityEngine;

public class Obstacle : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
        if (other.TryGetComponent(out Slicer slicer))
        {
            slicer.Stun();
        }
   }
}
