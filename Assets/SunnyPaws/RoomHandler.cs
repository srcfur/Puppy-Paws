using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomHandler : MonoBehaviour
{
    public static RoomHandler singleton;
    public RoomDefinition room_definition;
    private Scene? scene = null;
    private void Awake()
    {
        singleton = this;
        DontDestroyOnLoad(singleton);
        LoadRoomDefinition(room_definition);
    }
    private IEnumerator HandleLoadNextRoom(Scene? old, string scene_id)
    {
        AsyncOperation unloadOperation = null;
        if (old.HasValue)
        {
            unloadOperation = SceneManager.UnloadSceneAsync(old.Value);
        }
        AsyncOperation loading = SceneManager.LoadSceneAsync(scene_id, new LoadSceneParameters() { loadSceneMode = LoadSceneMode.Additive, localPhysicsMode = LocalPhysicsMode.None });

        SceneManager.sceneLoaded += (newscene, loadmode) => { if (loadmode == LoadSceneMode.Additive) { scene = newscene; } };
        yield return loading;
        if (unloadOperation != null)
        {
            if (!unloadOperation.isDone)
            {
                yield return unloadOperation;
            }
        }
        Debug.Log("Completed scene swap!");
    }
    public void LoadRoomDefinition(RoomDefinition new_room_definition)
    {
        room_definition = new_room_definition;
        StartCoroutine(HandleLoadNextRoom(scene, new_room_definition.scene_id));
    }
}
