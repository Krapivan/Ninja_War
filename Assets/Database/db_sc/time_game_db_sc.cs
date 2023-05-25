using UnityEngine;


[CreateAssetMenu(menuName = "db/time_game_db")]
public class time_game_db_sc : ScriptableObject
{
    //characters_pn
    public string _ch_hero_name;
    public string _ico_hero_name;
    public bool _ico_hero_ally;

    public string _sk_type;

    public int _ch_rune_id;
    public bool _ch_hero_rune;

    //story_pn
    public string _ch_chapter;
    public string _ch_part;

    //team
    public int _ch_team_preset;
}
