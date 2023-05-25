using UnityEngine;

public class story_fight_sc : MonoBehaviour
{
    public user_hero_db_sc user_hero_db;
    public time_game_db_sc time_game_db;
    public fight_db_sc fight_db;
    public story_db_sc story_db;


    private void Start()
    {
        Story_Fight_Load();
    }
    public void Story_Fight_Load()
    {
        Db_Load();

        Ally_Spawn();
        Enemy_Spawn();

    }
    void Db_Load()
    {
        fight_db._turn_lock = false;

        fight_db._enemy_lv = story_db._part_enemy_lv[fight_db._part_num - 1];
        fight_db._enemy_bonus = story_db._part_enemy_bonus[fight_db._part_num - 1];
    }


    public GameObject _hero_slot;
    public Transform _ally_team_cont;
    void Ally_Spawn()
    {
        Ally_Clear();
        for (int i = 0; i < 5; i++)
        {
            if (user_hero_db._team[i] != "No")
            {
                fight_db._spawn_hero_name = user_hero_db._team[i];
                fight_db._spawn_hero_is_ally = true;
                fight_db._spawn_hero_is_clone = false;
                Instantiate(_hero_slot, _ally_team_cont);
            }
        }
    }
    void Ally_Clear()
    {
        fight_db._ally_team.Clear();
        int c = _ally_team_cont.transform.childCount;
        for (int i = 0; i < c; i++)
        {
            Destroy(_ally_team_cont.GetChild(i).gameObject);
        }
    }


    public Transform _enemy_team_cont;
    void Enemy_Spawn()
    {
        Enemy_Clear();
        int part_num = fight_db._part_num;
        for (int i = 0; i < 5; i++)
        {
            if (story_db._part_enemy[(part_num - 1) * 5 + i] != "No")
            {
                fight_db._spawn_hero_name = story_db._part_enemy[(part_num - 1) * 5 + i];
                fight_db._spawn_hero_is_ally = false;
                fight_db._spawn_hero_is_clone = false;
                Instantiate(_hero_slot, _enemy_team_cont);
            }
        }
    }
    void Enemy_Clear()
    {
        fight_db._enemy_team.Clear();
        int c = _enemy_team_cont.transform.childCount;
        for (int i = 0; i < c; i++)
        {
            Destroy(_enemy_team_cont.GetChild(i).gameObject);
        }
    }


    void Reg_Ally_Enemy()
    {
        for (int i = 0; i < _ally_team_cont.childCount; i++)
        {
            fight_db._ally_team.Add(_ally_team_cont.GetChild(i).gameObject);
        }
        for (int i = 0; i < _enemy_team_cont.childCount; i++)
        {
            fight_db._enemy_team.Add(_enemy_team_cont.GetChild(i).gameObject);
        }
    }


    void Turn_Bar_Load()
    {

    }
}
