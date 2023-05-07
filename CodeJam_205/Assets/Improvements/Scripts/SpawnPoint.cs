using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int index;
    [SerializeField] private bool isCollected;

    private void Start()
    {
        if (PlayerPrefs.HasKey($"SpawnPoint{index}"))
        {
            Boolean.TryParse(PlayerPrefs.GetString($"SpawnPoint{index}"), out isCollected);
        }
        SpawnObject();
    }

    public void SpawnObject()
    {
        if (!isCollected)
        {
            GameObject g = prefab;
            CollectibleControls cc = g.GetComponent<CollectibleControls>();
            cc.SetIndex(index);
            Instantiate(prefab,transform.localPosition, Quaternion.identity);
        }
    }

    public void SetCollection(bool input)
    {
        isCollected = input;
        PlayerPrefs.SetString($"SpawnPoint{index}",input.ToString());
    }
}
