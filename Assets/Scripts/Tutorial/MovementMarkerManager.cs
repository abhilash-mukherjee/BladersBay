using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMarkerManager : MonoBehaviour
{
    public delegate void TargetReachedHandler();
    public static event TargetReachedHandler OnTargetReached;
    private void OnEnable()
    {
        TeachMovement.OnMarkerDestroyed += DestroyMarker;
    }
    private void OnDisable()
    {
        TeachMovement.OnMarkerDestroyed -= DestroyMarker;
        
    }

    private void DestroyMarker()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Target Reached");
            OnTargetReached?.Invoke();
            AudioManager.Instance.PlaySoundOneShot("MovementMarkerReached");
            Destroy(gameObject);
        }
    }
}
