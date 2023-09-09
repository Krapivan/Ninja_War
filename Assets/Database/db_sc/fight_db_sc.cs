using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/fight_db")]
public class fight_db_sc : ScriptableObject
{
    //story_fight
    public int _part_num;

    //general_static_inf
    public List<GameObject> _ally_team = new();
    public List<GameObject> _enemy_team = new();

    public Transform _ally_team_cont, _enemy_team_cont, _world_pn, _sk_pn, _chosen_sk_pn_place;

    public int _enemy_lv;
    public int _enemy_bonus;

    //setting for turn
    public GameObject _turn_hero;
    public bool _turn_lock;

    public GameObject _aim;
    public string _chosen_sk;

    //ef setting
    public string _spawn_ef_name;
    public int _spawn_ef_lv;
    public int _spawn_ef_time;
    public int _spawn_ef_power;
    public int _spawn_ef_atk;
}
