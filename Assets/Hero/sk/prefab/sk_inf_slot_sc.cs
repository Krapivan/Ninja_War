using UnityEngine;
using UnityEngine.UI;

public class sk_inf_slot_sc : MonoBehaviour
{
    public time_game_db_sc time_game_db;
    public hero_db_sc hero_db;


    string _h_name;
    public string _sk_type;
    int _h_num;
    public GameObject _ch_sk_pn;
    Transform _character_pn;


    private void Awake()
    {
        _sk_type = time_game_db._sk_type;
    }
    private void Start()
    {
        _character_pn = GameObject.Find("character_pn").transform;
        _h_name = time_game_db._ch_hero_name;
        _h_num = hero_db._name.IndexOf(_h_name) + 1;

        Art_Load();
    }
    void Art_Load()
    {
        if (_sk_type == "aa")
        {
            gameObject.GetComponent<Image>().sprite = hero_db._aa_art[_h_num - 1];
        }
        else if (_sk_type == "sk")
        {
            gameObject.GetComponent<Image>().sprite = hero_db._sk_art[_h_num - 1];
        }
        else if (_sk_type == "ul")
        {
            gameObject.GetComponent<Image>().sprite = hero_db._ul_art[_h_num - 1];
        }
        else if (_sk_type == "ps")
        {
            gameObject.GetComponent<Image>().sprite = hero_db._ps_art[_h_num - 1];
        }
    }


    public void Sk_Slot_B()
    {
        gameObject.GetComponent<Animation>().Play("click");

        GameObject pn = GameObject.Find("ch_sk_pn");

        if (pn != null && pn.GetComponent<ch_sk_pn_sc>()._sk_type != _sk_type)
        {
            pn.GetComponent<ch_sk_pn_sc>().Cls();
            time_game_db._sk_type = _sk_type;
            Instantiate(_ch_sk_pn, _character_pn);
        }
        else if (pn == null)
        {
            time_game_db._sk_type = _sk_type;
            Instantiate(_ch_sk_pn, _character_pn.transform);
        }
        else if (pn != null && pn.GetComponent<ch_sk_pn_sc>()._sk_type == _sk_type)
        {
            pn.GetComponent<ch_sk_pn_sc>().Cls();
        }
    }
}
