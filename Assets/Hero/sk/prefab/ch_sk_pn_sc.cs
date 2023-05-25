using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ch_sk_pn_sc : MonoBehaviour
{
    public time_game_db_sc time_game_db;
    public user_hero_db_sc user_hero_db;
    public hero_db_sc hero_db;


    public sk_inf_sc sk_inf_sc;


    public string _h_name;
    public string _sk_name;
    public string _sk_type;
    int _uh_num, _h_num;
    int _sk_lv;

    public TextMeshProUGUI _sk_name_txt, _sk_inf_txt, _sk_lv_cost_txt;


    private void Awake()
    {
        name = "ch_sk_pn";
        _sk_type = time_game_db._sk_type;
    }
    private void Start()
    {
        GetComponent<Animation>().Play("push_pn_op");

        _h_name = time_game_db._ch_hero_name;
        _uh_num = user_hero_db._name.IndexOf(_h_name) + 1;
        _h_num = hero_db._name.IndexOf(_h_name) + 1;
        switch (_sk_type)
        {
            case "aa": _sk_name = hero_db._aa_name[_h_num - 1]; break;
            case "sk": _sk_name = hero_db._sk_name[_h_num - 1]; break;
            case "ul": _sk_name = hero_db._ul_name[_h_num - 1]; break;
            case "ps": _sk_name = hero_db._ps_name[_h_num - 1]; break;
        }
        Sk_Lv_Load();
        Sk_Inf_Load();
    }

    void Sk_Lv_Load()
    {
        switch(_sk_type)
        {
            case "aa": _sk_lv = user_hero_db._aa_lv[_uh_num - 1]; break;
            case "sk": _sk_lv = user_hero_db._sk_lv[_uh_num - 1]; break;
            case "ul": _sk_lv = user_hero_db._ul_lv[_uh_num - 1]; break;
            case "ps": _sk_lv = user_hero_db._ps_lv[_uh_num - 1]; break;
        }
        _sk_name_txt.text = _sk_name + "(" + _sk_lv + ")";
    }
    void Sk_Inf_Load()
    {
        _sk_inf_txt.text = sk_inf_sc.Sk_Inf(_sk_name);
    }


    public void Cls()
    {
        Destroy(gameObject);
    }
}
