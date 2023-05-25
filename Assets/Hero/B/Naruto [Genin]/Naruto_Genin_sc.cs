using UnityEngine;

public class Naruto_Genin_sc : MonoBehaviour
{
    public fight_db_sc fight_db;
    public hero_db_sc hero_db;


    public GameObject _hero_slot;
    public void Sk(hero_slot_sc user_sc, hero_slot_sc aim_sc)
    {
        string ch_sk_type = fight_db._ch_sk_type;
        if (user_sc._is_ally == true)
        {
            if (ch_sk_type == "aa" && aim_sc._is_ally == false)
            {
                //sk mdmg bonus = = = = =
                int count = 0;
                for (int i = 0; i < fight_db._ally_team.Count; i++)
                {
                    if (fight_db._ally_team[i].name == "Naruto [Genin]_ally")
                    {
                        hero_slot_sc hero_slot_sc = fight_db._ally_team[i].GetComponent<hero_slot_sc>();
                        if (hero_slot_sc._is_clone == true)
                        {
                            count++;
                        }
                    }
                }
                int clone_mdmg_b = 30;
                switch (user_sc._aa_lv)
                {
                    case 3: clone_mdmg_b = 45; break;
                    case 4: clone_mdmg_b = 45; break;
                    case 5: clone_mdmg_b = 60; break;
                }

                int mdmg = 185 + count * clone_mdmg_b;

                //dmg
                int atk = user_sc._atk;
                int dmg = atk * mdmg / 100;

                //crit
                int cr_ch = Random.Range(1, 101);
                int crd = user_sc._crd;
                int crr = user_sc._crr;
                if (cr_ch <= crr)
                {
                    dmg = dmg * (100 + crd) / 100;
                }

                //lv dmg grow
                switch (user_sc._aa_lv)
                {
                    case 2: dmg = dmg * 110 / 100; break;
                    case 3: dmg = dmg * 110 / 100; break;
                    case 4: dmg = dmg * 120 / 100; break;
                    case 5: dmg = dmg * 120 / 100; break;
                }

                //aim take dmg
                aim_sc.Take_Damage(dmg, false, false, false, false, 0, user_sc);
            }
            if (ch_sk_type == "sk" && aim_sc == user_sc)
            {
                if (fight_db._ally_team.Count < 9)
                {
                    //summon setting
                    fight_db._spawn_hero_is_ally = true;
                    fight_db._spawn_hero_is_clone = true;
                    fight_db._spawn_hero_name = user_sc._hero_name;

                    int hp_p = 10;
                    switch (user_sc._sk_lv)
                    {
                        case 3: hp_p += 10; break;
                        case 4: hp_p += 10; break;
                        case 5: hp_p += 20; break;
                    }
                    if (user_sc._ps_lv >= 4)
                    {
                        hp_p += 10;
                    }

                    fight_db._cl_hp = user_sc._hp_mx * hp_p / 100;
                    fight_db._cl_atk = user_sc._atk;
                    fight_db._cl_def = user_sc._def;
                    fight_db._cl_spd = user_sc._spd - 10;
                    fight_db._cl_crr = user_sc._crr;
                    fight_db._cl_crd = user_sc._crd;
                    fight_db._cl_acc = 0;
                    fight_db._cl_res = 0;

                    //summon
                    Instantiate(_hero_slot, fight_db._ally_team_cont);

                    //cd
                    int cd = hero_db._sk_cd[user_sc._uh_num - 1];
                    switch (user_sc._sk_lv)
                    {
                        case 2: cd -= 1; break;
                        case 3: cd -= 1; break;
                        case 4: cd -= 2; break;
                        case 5: cd -= 2; break;
                    }
                    user_sc._sk_cd = cd;
                }
            }
        }
    }
}
