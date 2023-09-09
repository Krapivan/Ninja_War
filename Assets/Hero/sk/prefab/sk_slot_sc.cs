using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sk_slot_sc : MonoBehaviour
{
    [SerializeField] user_hero_db_sc _user_hero_db;
    [SerializeField] hero_db_sc _hero_db;
    [SerializeField] fight_db_sc _fight_db;


    [SerializeField]  hero_slot_sc _user_sc;
    int _uh_num, _h_num;
    [SerializeField] string _sk_type, _sk_name, _hero_name;
    [SerializeField] GameObject _hero;


    public void Spawn_Setting(string sk_type, string sk_name, GameObject hero)
    {
        _sk_type = sk_type;
        _sk_name = sk_name;
        _hero = hero;

        _user_sc = hero.GetComponent<hero_slot_sc>();
        _hero_name = _user_sc._hero_name;
        _uh_num = _user_hero_db._name.IndexOf(_hero_name) + 1;
        _h_num = _hero_db._name.IndexOf(_hero_name) + 1;
        Visual_Load();
    }


    public Image _art;
    public TextMeshProUGUI _cd_txt;
    void Visual_Load()
    {
        int cd = 0;
        if (_sk_type == "aa")
        {
            _art.sprite = _hero_db._aa_art[_h_num - 1];
        }
        else if (_sk_type == "sk")
        {
            _art.sprite = _hero_db._sk_art[_h_num - 1];
            cd = _user_sc._sk_cd;
        }
        else if (_sk_type == "ul")
        {
            _art.sprite = _hero_db._ul_art[_h_num - 1];
            cd = _user_sc._ul_cd;        
        }
        else if (_sk_type == "ps")
        {
            _art.sprite = _hero_db._ps_art[_h_num - 1];
            cd = _user_sc._ps_cd;
        }


        if (cd == 0)
        {
            _cd_txt.gameObject.SetActive(false);
        }
        else if (cd > 0)
        {
            _cd_txt.text = cd + "";
            gameObject.GetComponent<Button>().interactable = false;
        }
    }


    [SerializeField] GameObject _sk_inf_pn;
    public void Sk_Slot_B()
    {
        if (_fight_db._chosen_sk != _sk_name)
        {
            _fight_db._chosen_sk = _sk_name;

            GameObject sk_inf_pn = GameObject.Find("sk_inf_pn");
            if (sk_inf_pn != null)
            {
                Destroy(sk_inf_pn);
            }

            GameObject new_sk_inf_pn = Instantiate(_sk_inf_pn, _fight_db._chosen_sk_pn_place);
            new_sk_inf_pn.GetComponent<sk_inf_pn_sc>().Spawn_Setting(_sk_name);
        }
        else if (_fight_db._chosen_sk == _sk_name && _fight_db._aim == null)
        {
            _fight_db._chosen_sk = null;
            GameObject sk_inf_pn = GameObject.Find("sk_inf_pn");
            if (sk_inf_pn != null)
            {
                Destroy(sk_inf_pn);
            }
        }
    }
}
