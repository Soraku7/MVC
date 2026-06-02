using Mics;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.Rotate(Vector3.up * (120 * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            other.SendMessage("PickCoin");
            Destroy(gameObject);
        }
    }
}