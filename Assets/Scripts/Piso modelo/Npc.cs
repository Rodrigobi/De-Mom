using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public DialogTrigger trigger;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            trigger.StartDialogue();
    }
}



