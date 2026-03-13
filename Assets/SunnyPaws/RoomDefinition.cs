using UnityEngine;

[CreateAssetMenu(fileName = "RoomDefinition", menuName = "SunnyPaws/RoomDefinition")]
public class RoomDefinition : ScriptableObject
{
    public string room_name;
    public long room_id;
    public int room_width;
    public int room_depth;
    public int room_floor_visual_height;

    public float room_scale_close;
    public float room_scale_far;

    public string scene_id;
}
