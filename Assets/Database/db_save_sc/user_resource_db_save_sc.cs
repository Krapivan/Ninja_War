using UnityEngine;

public class user_resource_db_save_sc : MonoBehaviour
{
    public user_resource_db_sc user_resource_db;
    
    public void User_Resource_Db_Save()
    {
        PlayerPrefs.SetString("_user_name", user_resource_db._user_name);
        PlayerPrefs.SetInt("_money", user_resource_db._money);
        PlayerPrefs.SetInt("_gold", user_resource_db._gold);
        PlayerPrefs.SetInt("_coin", user_resource_db._coin);
        PlayerPrefs.SetInt("_energy", user_resource_db._energy);
        PlayerPrefs.SetInt("_energy_mx", user_resource_db._energy_mx);
    }

    public void User_Resource_Db_Load()
    {
        user_resource_db._user_name = PlayerPrefs.GetString("_user_name");
        user_resource_db._money = PlayerPrefs.GetInt("_money");
        user_resource_db._gold = PlayerPrefs.GetInt("_gold");
        user_resource_db._coin = PlayerPrefs.GetInt("_coin");
        user_resource_db._energy = PlayerPrefs.GetInt("_energy");
        user_resource_db._energy_mx = PlayerPrefs.GetInt("_energy_mx");
    }

    public void User_Resource_Db_Reset()
    {
        PlayerPrefs.DeleteKey("_user_name");
        PlayerPrefs.DeleteKey("_money");
        PlayerPrefs.DeleteKey("_gold");
        PlayerPrefs.DeleteKey("_coin");
        PlayerPrefs.DeleteKey("_energy");
        PlayerPrefs.DeleteKey("_energy_mx");
    }


    public void User_Resource_Db_Clear()
    {
        user_resource_db._user_name = "";
        user_resource_db._money = 0;
        user_resource_db._gold = 0;
        user_resource_db._coin = 0;
        user_resource_db._energy = 0;
        user_resource_db._energy_mx = 0;
    }
}
