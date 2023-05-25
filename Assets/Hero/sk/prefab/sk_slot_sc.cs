using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sk_slot_sc : MonoBehaviour
{
    public user_hero_db_sc user_hero_db;
    public hero_db_sc hero_db;
    public fight_db_sc fight_db;


    public sk_inf_sc sk_inf_sc;


    public hero_slot_sc _hero_slot;
    int _uh_num, _h_num;
    [SerializeField]string _sk_type, _sk_name, _hero_name;

    private void Awake()
    {
        _sk_type = fight_db._spawn_sk_type;
        _sk_name = fight_db._spawn_sk_name;
        _hero_name = fight_db._spawn_sk_hero_name;
    }
    private void Start()
    {
        _hero_slot = GameObject.Find(_hero_name + "_ally").GetComponent<hero_slot_sc>();
        _uh_num = user_hero_db._name.IndexOf(_hero_name) + 1;
        _h_num = hero_db._name.IndexOf(_hero_name) + 1;
        Visual_Load();
    }


    public Image _art;
    public TextMeshProUGUI _cd_txt;
    void Visual_Load()
    {
        int cd = 0;
        if (_sk_type == "aa")
        {
            _art.sprite = hero_db._aa_art[_h_num - 1];
        }
        else if (_sk_type == "sk")
        {
            _art.sprite = hero_db._sk_art[_h_num - 1];
            cd = _hero_slot._sk_cd;
        }
        else if (_sk_type == "ul")
        {
            _art.sprite = hero_db._ul_art[_h_num - 1];
            cd = _hero_slot._ul_cd;        
        }
        else if (_sk_type == "ps")
        {
            _art.sprite = hero_db._ps_art[_h_num - 1];
            cd = _hero_slot._ps_cd;
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


    public void Sk_Slot_B()
    {
        if (fight_db._ch_sk_type != _sk_type)
        {
            fight_db._ch_sk_type = _sk_type;
        }
        else if (fight_db._ch_sk_type == _sk_type)
        {
        }
    }
}
