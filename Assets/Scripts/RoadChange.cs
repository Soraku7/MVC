using Global;
using Mics;
using UnityEngine;

public class RoadChange : MonoBehaviour
{
    private string relativePath = "Pattern_";
    private int roadNum = 5;

    public GameObject nowPattern;
    public GameObject nextPattern;

    private void Start()
    {
        Debug.Log(relativePath + "1");
        nowPattern = GameManager.Instance.objectPool.Spawn(relativePath + "1");
        nowPattern.transform.position = Vector3.zero;
        nextPattern = GameManager.Instance.objectPool.Spawn(relativePath + "2");
        nextPattern.transform.position = Vector3.zero + Vector3.forward * 160;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Road))
        {
            int index = Random.Range(1, roadNum);
            GameObject patternInstance = GameManager.Instance.objectPool.Spawn(relativePath + index);
            patternInstance.transform.position = nextPattern.transform.position + Vector3.forward * 160;
            GameManager.Instance.objectPool.Recycle(nowPattern);
            nowPattern = nextPattern;
            nextPattern = patternInstance;
        }
    }
}