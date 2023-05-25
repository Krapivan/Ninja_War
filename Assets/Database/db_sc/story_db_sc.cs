using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/story_db")]
public class story_db_sc : ScriptableObject
{
    public List<string> _chapter = new();
    public List<int> _chapter_comp = new();

    public List<string> _part = new();
    public List<int> _part_comp = new();

    public List<Sprite> _part_point_art = new();

    public List<string> _part_enemy = new();
    public List<int> _part_enemy_lv = new();
    public List<int> _part_enemy_bonus = new();
}
