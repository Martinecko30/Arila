using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private InputAction interactButton;

    private void FixedUpdate()
    {
        if(interactButton.triggered)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliders)
            {
                if(collider.TryGetComponent(out QuestGiver questGiver)) {
                    questGiver.Interact();
                }
            }
        }
    }
}
