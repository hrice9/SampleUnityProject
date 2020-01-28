using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Interactable : MonoBehaviour
{
    public bool requireInputInteraction = true; // by default the player should press a button to interact with an object
    [SerializeField] private float interactRadius = .5f; // by default the interact radius is set to .5 units
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }

    public virtual void Interact()
    {
        // override this method with the interaction code
        Debug.Log("Interacting with: " + transform.name);
    }
}

// derive from this script to add interactability to an object in the game world