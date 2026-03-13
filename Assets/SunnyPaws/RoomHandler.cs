using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomHandler : MonoBehaviour
{
    public RoomDefinition room_definition;
    private void Awake()
    {
        if(room_definition != null)
        {
            Scene s = SceneManager.LoadScene(room_definition.scene_id, new LoadSceneParameters() { loadSceneMode = LoadSceneMode.Additive, localPhysicsMode = LocalPhysicsMode.None});
            
        }
    }
}
