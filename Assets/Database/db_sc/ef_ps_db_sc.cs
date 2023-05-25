using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/ef_ps_db")]
public class ef_ps_db_sc : ScriptableObject
{
    public List<string> _ef_name = new();
    public List<Sprite> _ef_art = new();
    public List<int> _ef_power = new();

    public List<string> _ps_name = new();
    public List<Sprite> _ps_art = new();
}
