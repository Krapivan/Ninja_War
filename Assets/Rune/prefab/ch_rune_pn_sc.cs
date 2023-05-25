using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ch_rune_pn_sc : MonoBehaviour
{
    public user_resource_db_sc user_resource_db;
    public time_game_db_sc time_game_db;
    public user_hero_db_sc user_hero_db;
    public user_rune_db_sc user_rune_db;
    public rune_db_sc rune_db;


    public character_pn_sc character_pn_sc;
    public rune_sc rune_sc;


    public TextMeshProUGUI _slot_txt, _lv_txt, _m_stat_txt, _set_txt, _d_stat_txt, _cost_txt, _equip_remove_txt;
    public Transform _star_cont;
    public Image _rune_art;
    public GameObject _lv_up_b, _equip_remove_b;


    public int _rune_id;
    public int _slot, _star;
    public string _rare, _set;


    private void Awake()
    {
        name = "ch_rune_pn";
        _rune_id = time_game_db._ch_rune_id;
    }
    private void Start()
    {
        character_pn_sc = GameObject.Find("character_pn_sc").GetComponent<character_pn_sc>();
        rune_sc = GameObject.Find("rune_sc").GetComponent<rune_sc>();

        GetComponent<Animation>().Play("push_pn_op");

        _slot = user_rune_db._slot[_rune_id - 1];
        _star = user_rune_db._star[_rune_id - 1];

        _rare = user_rune_db._rare[_rune_id - 1];
        _set = user_rune_db._set[_rune_id - 1];


        Visual_Load();
    }


    void Visual_Load()
    {
        Art_Load();
        Star_Load(_star, _star_cont);
        Lv_Load();
        Stat_Load();
        Lv_Cost_Load();
        Equip_B_Load();
        _slot_txt.text = _slot.ToString();
    }
    void Star_Load(int star, Transform rune_stars)
    {
        for (int i = 0; i < rune_stars.childCount; i++)
        {
            rune_stars.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < star; i++)
        {
            rune_stars.GetChild(i).gameObject.SetActive(true);
        }
    }
    void Art_Load()
    {
        int set_rare_num = rune_db._set_rare_name.IndexOf(_set + "_" + _rare) + 1;
        _rune_art.sprite = rune_db._set_rare_art[set_rare_num - 1];
    }
    void Equip_B_Load()
    {
        if (user_rune_db._hero[_rune_id - 1] == "No")
        {
            _equip_remove_txt.text = "equip";
        }
        else if (user_rune_db._hero[_rune_id - 1] != "No")
        {
            _equip_remove_txt.text = "remove";
        }
    }
    void Lv_Load()
    {
        _lv_txt.text = "+" + user_rune_db._lv[_rune_id - 1];
    }
    void Lv_Cost_Load()
    {
        if (user_rune_db._lv[_rune_id - 1] != 15)
        {
            _cost_txt.text = "cost: " + Lv_Cost_Value();
        }
        else if (user_rune_db._lv[_rune_id - 1] == 15)
        {
            _cost_txt.text = "cost: -";
        }
    }
    int Lv_Cost_Value()
    {
        int cost = rune_db._start_cost[_star - 1];
        for (int i = 1; i <= user_rune_db._lv[_rune_id - 1]; i++)
        {
            cost = (cost * (100 + rune_db._lv_cost_mod)) / 100;
        }
        return cost;
    }


    void Stat_Load()
    {
        Main_Stat_Load();
        Dop_Stat_Load();
    }
    void Main_Stat_Load()
    {
        string m_stat_name = user_rune_db._m_stat[_rune_id - 1];

        switch (m_stat_name)
        {
            case "hp": _m_stat_txt.text = "+" + user_rune_db._hp_m[_rune_id - 1] + " HP"; break;
            case "hp_p": _m_stat_txt.text = "+" + user_rune_db._hp_p_m[_rune_id - 1] + " HP%"; break;
            case "atk": _m_stat_txt.text = "+" + user_rune_db._atk_m[_rune_id - 1] + " ATK"; break;
            case "atk_p": _m_stat_txt.text = "+" + user_rune_db._atk_p_m[_rune_id - 1] + " ATK%"; break;
            case "def": _m_stat_txt.text = "+" + user_rune_db._def_m[_rune_id - 1] + " DEF"; break;
            case "def_p": _m_stat_txt.text = "+" + user_rune_db._def_p_m[_rune_id - 1] + " DEF%"; break;
            case "spd": _m_stat_txt.text = "+" + user_rune_db._spd_m[_rune_id - 1] + " SPD"; break;
            case "crr": _m_stat_txt.text = "+" + user_rune_db._crr_m[_rune_id - 1] + " CRR"; break;
            case "crd": _m_stat_txt.text = "+" + user_rune_db._crd_m[_rune_id - 1] + " CRD"; break;
            case "acc": _m_stat_txt.text = "+" + user_rune_db._acc_m[_rune_id - 1] + " ACC"; break;
            case "res": _m_stat_txt.text = "+" + user_rune_db._res_m[_rune_id - 1] + " RES"; break;
        }
    }
    void Dop_Stat_Load()
    {
        List<string> d_stat_name = new();
        d_stat_name.Add(user_rune_db._1_d_stat[_rune_id - 1]);
        d_stat_name.Add(user_rune_db._2_d_stat[_rune_id - 1]);
        d_stat_name.Add(user_rune_db._3_d_stat[_rune_id - 1]);
        d_stat_name.Add(user_rune_db._4_d_stat[_rune_id - 1]);

        _d_stat_txt.text = "";

        for (int i = 0; i < 4; i++)
        {
            if (d_stat_name[i] != "No")
            {
                if (i != 0)
                {
                    _d_stat_txt.text += "\n";
                }
                string stat_name = d_stat_name[i];
                switch (stat_name)
                {
                    case "hp": _d_stat_txt.text += "+" + user_rune_db._hp_d[_rune_id - 1] + " HP"; break;
                    case "hp_p": _d_stat_txt.text += "+" + user_rune_db._hp_p_d[_rune_id - 1] + " HP%"; break;
                    case "atk": _d_stat_txt.text += "+" + user_rune_db._atk_d[_rune_id - 1] + " ATK"; break;
                    case "atk_p": _d_stat_txt.text += "+" + user_rune_db._atk_p_d[_rune_id - 1] + " ATK%"; break;
                    case "def": _d_stat_txt.text += "+" + user_rune_db._def_d[_rune_id - 1] + " DEF"; break;
                    case "def_p": _d_stat_txt.text += "+" + user_rune_db._def_p_d[_rune_id - 1] + " DEF%"; break;
                    case "spd": _d_stat_txt.text += "+" + user_rune_db._spd_d[_rune_id - 1] + " SPD"; break;
                    case "crr": _d_stat_txt.text += "+" + user_rune_db._crr_d[_rune_id - 1] + " CRR"; break;
                    case "crd": _d_stat_txt.text += "+" + user_rune_db._crd_d[_rune_id - 1] + " CRD"; break;
                    case "acc": _d_stat_txt.text += "+" + user_rune_db._acc_d[_rune_id - 1] + " ACC"; break;
                    case "res": _d_stat_txt.text += "+" + user_rune_db._res_d[_rune_id - 1] + " RES"; break;
                }
            }

        }
    }


    public void Cls()
    {
        Destroy(gameObject);
    }


    public void Lv_Up_B()
    {
        if (user_rune_db._lv[_rune_id - 1] < 15)
        {
            if (Lv_Cost_Value() <= user_resource_db._coin)
            {
                _lv_up_b.GetComponent<Animation>().Play("click");

                user_resource_db._coin -= Lv_Cost_Value();

                user_rune_db._lv[_rune_id - 1]++;
                rune_sc.Rune_Lv_Up(_rune_id);

                if (user_rune_db._hero[_rune_id - 1] == time_game_db._ch_hero_name)
                {
                    int uh_num = user_hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
                    character_pn_sc.Hero_Rune_Load(uh_num);
                    character_pn_sc.Hero_Rune_Stat_Load(uh_num);
                }
                if (user_rune_db._hero[_rune_id - 1] == "No")
                {
                    character_pn_sc._all_rune_cont.GetChild(_rune_id - 1).gameObject.GetComponent<rune_slot_sc>().Slot_Lv_Load();
                }

                Lv_Load();
                Stat_Load();
                Lv_Cost_Load();
            }
            else 
            {
                _cost_txt.gameObject.GetComponent<Animation>().Play("warning");
            }
        }
        else if (user_rune_db._lv[_rune_id - 1] == 15)
        {
            _lv_txt.gameObject.GetComponent<Animation>().Play("warning");
        }
    }
    public void Equip_Remove_B()
    {
        _equip_remove_b.GetComponent<Animation>().Play("click");

        if (user_rune_db._hero[_rune_id - 1] == "No")
        {
            rune_sc.Hero_Rune_Equip(time_game_db._ch_hero_name, _rune_id);
            int uh_num = user_hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
            character_pn_sc.Hero_Inf_Rune_Pn_Load(uh_num);
        }
        else if (user_rune_db._hero[_rune_id - 1] != "No")
        {
            rune_sc.Hero_Rune_Remove(user_rune_db._hero[_rune_id - 1], _rune_id);
            int uh_num = user_hero_db._name.IndexOf(time_game_db._ch_hero_name) + 1;
            character_pn_sc.Hero_Inf_Rune_Pn_Load(uh_num);
        }
        Equip_B_Load();
    }
}
