using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ef_slot_sc : MonoBehaviour
{
    public fight_db_sc fight_db;
    public ef_ps_db_sc ef_ps_db;


    public hero_slot_sc _user_sc;


    public Image _art;
    public TextMeshProUGUI _time_txt;

    public string _ef_name;
    public int _lv, _time, _power, _atk, _ef_id;
    public bool _is_bf;


    private void Awake()
    {
        _ef_name = fight_db._spawn_ef_name;
        _lv = fight_db._spawn_ef_lv;
        _time = fight_db._spawn_ef_time;
        _power = fight_db._spawn_ef_power;
        _atk = fight_db._spawn_ef_atk;
    }
    private void Start()
    {
        gameObject.name = _ef_name;

        _ef_id = ef_ps_db._ef_name.IndexOf(_ef_name) + 1;
        _user_sc = transform.parent.parent.GetComponent<hero_slot_sc>();
        _user_sc._ef_name.Add(_ef_name);
        Art_Load();
    }
    private void FixedUpdate()
    {
        Time();
    }


    void Time()
    {
        _time_txt.text = _time + "";
    }
    void Art_Load()
    {
        _art.sprite = ef_ps_db._ef_art[_ef_id - 1];
    }


    void On_Off(bool on)
    {
        //bf
        if (_ef_name == "defense")
        {
            if (on == true)
            {
                _power = _user_sc._def * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._def += _power;
            }
            else if (on == false)
            {
                _user_sc._def -= _power;
            }
        }
        if (_ef_name == "lethality")
        {
            if (on == true)
            {
                _power = _user_sc._atk * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._atk += _power;
            }
            else if (on == false)
            {
                _user_sc._atk -= _power;
            }
        }
        if (_ef_name == "rage")
        {
            if (on == true)
            {
                _power = _user_sc._crd * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._crd += _power;
            }
            else if (on == false)
            {
                _user_sc._crd -= _power;
            }
        }
        if (_ef_name == "sharpening")
        {
            if (on == true)
            {
                _power = _user_sc._crr * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._crr += _power;
            }
            else if (on == false)
            {
                _user_sc._crr -= _power;
            }
        }
        if (_ef_name == "swift")
        {
            if (on == true)
            {
                _power = _user_sc._spd * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._spd += _power;
            }
            else if (on == false)
            {
                _user_sc._spd -= _power;
            }
        }
        //dbf
        if (_ef_name == "breaking")
        {
            if (on == true)
            {
                _power = _user_sc._def * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._def -= _power;
            }
            else if (on == false)
            {
                _user_sc._def += _power;
            }
        }
        if (_ef_name == "disarming")
        {
            if (on == true)
            {
                _power = _user_sc._atk * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._atk -= _power;
            }
            else if (on == false)
            {
                _user_sc._atk += _power;
            }
        }
        if (_ef_name == "exhaustion")
        {
            if (on == true)
            {
                _power = _user_sc._crd * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._crd -= _power;
            }
            else if (on == false)
            {
                _user_sc._crd += _power;
            }
        }
        if (_ef_name == "blunted")
        {
            if (on == true)
            {
                _power = _user_sc._crr * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._crr -= _power;
            }
            else if (on == false)
            {
                _user_sc._crr += _power;
            }
        }
        if (_ef_name == "slowing")
        {
            if (on == true)
            {
                _power = _user_sc._spd * ef_ps_db._ef_power[_ef_id - 1] / 100;
                _user_sc._spd -= _power;
            }
            else if (on == false)
            {
                _user_sc._spd += _power;
            }
        }
    }


    public void Time_Red()
    {
        Turn_Ef();
        _time--;
        if (_time <= 0)
        {
            Del();
        }
    }
    void Turn_Ef()
    {
        //dbf
        if (_ef_name == "bomb" && _time == 1)
        {
            _user_sc.Take_Damage(_atk, false, false, false, false, 100, null);
        }
        if (_ef_name == "corrosion")
        {

        }
    }


    void Del()
    {
        _user_sc._ef_name.Remove(_ef_name);
        Destroy(gameObject);
    }
}
