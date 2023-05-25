using UnityEngine;

public class summon_pn_sc : MonoBehaviour
{
    public user_hero_db_sc user_hero_db;
    public hero_db_sc hero_db;


    public void Add_Hero(string hero_name)
    {
        user_hero_db._name.Add(hero_name);

        user_hero_db._dubl.Add(0);
        user_hero_db._star.Add(1);
        user_hero_db._ev_star.Add(0);
        user_hero_db._lv.Add(1);
        user_hero_db._xp.Add(0);
        user_hero_db._xp_nd.Add(300);

        user_hero_db._rune_1_id.Add(0);
        user_hero_db._rune_2_id.Add(0);
        user_hero_db._rune_3_id.Add(0);
        user_hero_db._rune_4_id.Add(0);
        user_hero_db._rune_5_id.Add(0);
        user_hero_db._rune_6_id.Add(0);

        user_hero_db._aa_lv.Add(1);
        user_hero_db._sk_lv.Add(1);
        user_hero_db._ul_lv.Add(1);
        user_hero_db._ps_lv.Add(1);
    }
}
