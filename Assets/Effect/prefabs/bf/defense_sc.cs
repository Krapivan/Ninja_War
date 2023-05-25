using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class defense_sc : MonoBehaviour
{
    public fight_db_sc fight_db;


    public Sprite _art_1, _art_2;
    public Image _art;
    public hero_slot_sc _hero_sc;
    public TextMeshProUGUI _time_txt;

    public string _name;
    public int _lv, _time;

    [SerializeField]int _power;

    public int _def_p_per_lv;

    public bool _is_ef, _is_bf, _is_dbf;


    private void Awake()
    {
        _name = fight_db._spawn_ef_name;
        _lv = fight_db._spawn_ef_lv;
        _time = fight_db._spawn_ef_time;
    }
    private void Start()
    {
        gameObject.name = _name;
        _hero_sc = transform.parent.parent.GetComponent<hero_slot_sc>();
        _hero_sc._ef_name.Add(_name);
        Art_Load();
        Ef_On_Off("on");
    }
    private void FixedUpdate()
    {
        _time_txt.text = _time + "";
    }

    void Art_Load()
    {
        if (_lv == 1)
        {
            _art.sprite = _art_1;
        }
        else if (_lv == 2)
        {
            _art.sprite = _art_2;
        }
    }

    void Ef_On_Off(string v)
    {
        if (v == "on")
        {
            _power = _hero_sc._def * _def_p_per_lv * _lv / 100;
            _hero_sc._def += _power;
        }

        if (v == "off")
        {
            _hero_sc._def -= _power;
        }
    }

    public void Consume_Time()
    {
        _time--;
        if (_time == 0)
        {
            Destroy_Ef();
        }
    }

    public void Destroy_Ef()
    {
        _hero_sc._ef_name.Remove(_name);
        Ef_On_Off("off");
        Destroy(gameObject);
    }

}
