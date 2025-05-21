using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class pathNodes : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private List<Transform> nodes = new List<Transform>();

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float reachThreshold = 0.1f;
    public float distance;
    private int currentSegment = 0;
    private float t = 0f; // Progress between currentSegment and next

    // Called in Editor when values are changed in Inspector
    private void OnValidate()
    {
        if (parentObject == null) return;
        nodes.Clear();
        // Only immediate children
        foreach (Transform child in parentObject.transform)
        {
            nodes.Add(child.gameObject.transform);
        }
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            Transform obj = nodes[i];

            if (obj != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(obj.position,0.33f);
            #if UNITY_EDITOR
                Handles.color = Color.green;
                Handles.Label(obj.position + Vector3.up * 0.2f, $"Node {i}");
            #endif
            }
            if (nodes.Count>0 && i != 0)
                Gizmos.DrawLine(nodes[i-1].position, nodes[i].position);

        }
    }


    void Update()
    {
        if (nodes.Count < 2) return;

        float direction = 0f;

        if (Input.GetKey(KeyCode.E)) direction = 1f;
        else if (Input.GetKey(KeyCode.Q)) direction = -1f;

        // Move along current segment
        if (direction != 0f)
        {
            Vector3 start = nodes[currentSegment].position;
            Vector3 end = nodes[currentSegment + 1].position;

            // Keep Z fixed
            start.y = transform.position.y;
            end.y = transform.position.y;

            // Move progress (t) along segment
            float distance = Vector3.Distance(start, end);
            t += (moveSpeed / distance) * direction * Time.deltaTime;

            // Clamp or move to next/prev segment
            if (t > 1f && currentSegment < nodes.Count - 2)
            {
                t = t - 1f;
                currentSegment++;
            }
            else if (t < 0f && currentSegment > 0)
            {
                t = t + 1f;
                currentSegment--;
            }

            t = Mathf.Clamp01(t);
            Vector3 temp=  Vector3.Lerp(start, end, t);
            transform.position = new Vector3(temp.x, transform.position.y, temp.z);
        }
    }
}


