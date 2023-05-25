using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ps_sc : MonoBehaviour
{
    public Transform _ally_pn, _enemy_pn;


    //Take & Deal Dmg Ch = = = = =
    public int Take_Dmg_Red_Ps(int dmg, hero_slot_sc hero_sc)
    {


        return dmg;
    }
    public int Take_Dmg_Grow_Ps(int dmg, hero_slot_sc hero_sc)
    {


        return dmg;
    }


    public int Deal_Dmg_Red_Ps(int dmg, hero_slot_sc hero_sc)
    {


        return dmg;
    }
    public int Deal_Dmg_Grow_Ps(int dmg, hero_slot_sc hero_sc)
    {


        return dmg;
    }


    //Start Fight = = = = =
    public void Start_Ps(hero_slot_sc hero_sc)
    {
        //B
        {
            if (hero_sc._hero_name == "Naruto [Genin]" && hero_sc._is_clone == false)
            {
                for (int i = 0; i < _enemy_pn.childCount; i++)
                {
                    //_enemy_pn.GetChild(0).GetComponent<hero_slot_sc>().Take_Ef("");
                }
            }
        }
    }
}
