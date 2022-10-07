using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundHolder : MonoBehaviour
{
    private float m_spawnInterval = 2f;
    private float m_remainingSpawnInterval;
    private int m_currentChild;

    // Start is called before the first frame update
    void OnEnable()
    {
        m_remainingSpawnInterval = m_spawnInterval; //Unnecessary if the enemies need to be spawned straight away
        m_currentChild = 0;

        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_remainingSpawnInterval -= Time.deltaTime;

        if (m_remainingSpawnInterval <= 0f) 
        {
            transform.GetChild(m_currentChild).gameObject.SetActive(true);
            
            m_currentChild = Mathf.Clamp(m_currentChild + 1, 0, transform.childCount - 1);
            m_remainingSpawnInterval = m_spawnInterval;
        }
    }
}
