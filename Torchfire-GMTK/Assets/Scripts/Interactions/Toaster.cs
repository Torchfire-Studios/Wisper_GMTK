using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        Debug.Log("Turn on Toaster");
        return true;
    }
}
