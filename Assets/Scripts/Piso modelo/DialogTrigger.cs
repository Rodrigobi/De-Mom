using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        Vector3 scaleAmount = new Vector3(5f, 1f, 1f); // set the scale amount
        FindObjectOfType<DialogManager>().OpenDialogue(messages, actors, Vector3.one);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialogue();
        }
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Material material;
    public GameObject mesh;

    public Actor(string name, Material material, GameObject mesh)
    {
        this.name = name;
        this.material = material;
        this.mesh = mesh;
    }
}
