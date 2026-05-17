using Mics;
using UnityEngine;

public class RoadChange : MonoBehaviour
{
    public GameObject[] pattern;
    public GameObject nowPattern;
    public GameObject nextPattern;

    private void Start()
    {
        nowPattern = Instantiate(pattern[0]);
        nowPattern.transform.position = Vector3.zero;
        nextPattern = Instantiate(pattern[1]);
        nextPattern.transform.position = Vector3.zero + Vector3.forward * 160;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Road))
        {
            int index = Random.Range(0, pattern.Length);
            GameObject patternInstance = GameObject.Instantiate(pattern[index]);
            patternInstance.transform.position = nextPattern.transform.position + Vector3.forward * 160;
            nowPattern = nextPattern;
            nextPattern = patternInstance;
        }
    }
}