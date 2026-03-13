using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naninovel;
using UnityEngine;

public class NPCDialog : MonoBehaviour, InteractionInterest
{
    public float interactionDistance = 1;
    public bool canInteract(PlayerController controller)
    {
        return (transform.position - controller.transform.position).magnitude < interactionDistance;
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }

    public void interact(PlayerController controller)
    {
        Debug.Log("UwU");
        Naninovel.Engine.GetService<IScriptPlayer>().MainTrack.LoadAndPlay("TEST_NPC_DIALOG").GetAwaiter().GetResult();
    }
    public void Start()
    {
        InteractionRegistry.singleton.Register(this);
        Naninovel.RuntimeInitializer.Initialize().GetAwaiter().GetResult();
    }
}