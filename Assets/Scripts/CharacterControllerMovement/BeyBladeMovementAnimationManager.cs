using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BeyBladeMovementAnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject beyBladeParent;
    [SerializeField]
    private GameObject parentForChangingForwardRotation;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string speedParameter;
    [SerializeField]
    private float rotationLerpSpeed;
    [SerializeField]
    private GameObject trailLine;
    private List<MovementManagerWithCharacterController> movementManagers;

    private void Awake()
    {
        movementManagers = new List<MovementManagerWithCharacterController>();
        movementManagers = beyBladeParent.GetComponents<MovementManagerWithCharacterController>().ToList();
    }

    private void Update()
    {
        var _activeMovementManager = movementManagers.Find(p => p.enabled == true);
        if (_activeMovementManager == null)
        {
            animator.SetFloat(speedParameter, 0);
            trailLine.SetActive(false);
            return;
        }
        if (_activeMovementManager.CurrentVelocity.magnitude >= 0.01f)
            animator.SetFloat(speedParameter, 1);
        else if (_activeMovementManager.CurrentVelocity.magnitude <= 0.01f)
        {
            animator.SetFloat(speedParameter, 0);
            trailLine.SetActive(false);
            return;
        }
        if (_activeMovementManager.Type == typeof(CollisionMovementManagerWithCharacterController))
        {
            trailLine.SetActive(false);
        }
        else
        {
            parentForChangingForwardRotation.transform.forward =
                Vector3.Lerp(parentForChangingForwardRotation.transform.forward,
                _activeMovementManager.CurrentVelocity.normalized, Time.deltaTime * rotationLerpSpeed);
            trailLine.SetActive(true);
        }
    }
}
