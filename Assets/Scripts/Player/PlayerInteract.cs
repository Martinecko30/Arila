using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 2f;
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E))
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
