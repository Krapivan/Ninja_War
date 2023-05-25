using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/fight_db")]
public class fight_db_sc : ScriptableObject
{
    //story_fight
    public int _part_num;

    //general_dop_inf
    public string _spawn_hero_name;
    public bool _spawn_hero_is_ally;
    public bool _spawn_hero_is_clone;

    public string _spawn_sk_type;
    public string _spawn_sk_name;
    public string _spawn_sk_hero_name;

    //general_static_inf
    public List<GameObject> _ally_team = new();
    public List<GameObject> _enemy_team = new();

    public Transform _ally_team_cont, _enemy_team_cont;

    public int _enemy_lv;
    public int _enemy_bonus;

    //setting for turn
    public GameObject _turn_hero;
    public bool _turn_lock;

    public hero_slot_sc _aim;
    public string _ch_sk_type;

    //clone setting
    public int _cl_hp;
    public int _cl_atk;
    public int _cl_def;
    public int _cl_spd;
    public int _cl_crr;
    public int _cl_crd;
    public int _cl_acc;
    public int _cl_res;

    //ef setting
    public string _spawn_ef_name;
    public int _spawn_ef_lv;
    public int _spawn_ef_time;
    public int _spawn_ef_power;
    public int _spawn_ef_atk;

    //time
    public int _take_dmg_txt;
}
