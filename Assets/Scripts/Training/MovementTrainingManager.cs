using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrainingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject markerPrefab;
    [SerializeField]
    private List<Vector3> positions = new List<Vector3>();
    [SerializeField]
    private Collider playerCollider;
    [SerializeField]
    private string prefix;
    [SerializeField]
    private Animator animator;
    private int m_index = 0;
    private void OnEnable()
    {
        MovementMarkerManager.OnTargetReached += MarkerReached;
    }
    private void OnDisable()
    {
        MovementMarkerManager.OnTargetReached -= MarkerReached;
        
    }
    public void SpawnPrefab(int _index)
    {
        var _gO = Instantiate(markerPrefab, positions[_index], Quaternion.identity);
        _gO.GetComponent<MovementMarkerManager>().SetCollider(playerCollider);
    }

    private void MarkerReached()
    {
        m_index++;
        animator.SetBool(prefix + m_index, true);
    }

}
