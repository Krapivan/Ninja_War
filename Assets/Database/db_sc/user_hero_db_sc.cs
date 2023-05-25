using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "db/user_hero_db")]
public class user_hero_db_sc : ScriptableObject
{
    //team
    public List<string> _team = new(5);
    public List<string> _team_preset = new(15);

    //hero
    public int _count;

    public List<string> _name = new();

    public List<int> _dubl = new();

    public List<int> _star = new();
    public List<int> _ev_star = new();
    public List<int> _lv = new();
    public List<int> _xp = new();
    public List<int> _xp_nd = new();

    public List<int> _rune_1_id = new();
    public List<int> _rune_2_id = new();
    public List<int> _rune_3_id = new();
    public List<int> _rune_4_id = new();
    public List<int> _rune_5_id = new();
    public List<int> _rune_6_id = new();

    public List<int> _aa_lv = new();
    public List<int> _sk_lv = new();
    public List<int> _ul_lv = new();
    public List<int> _ps_lv = new();
}
