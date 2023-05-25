using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ef_sc : MonoBehaviour
{
    //Take & Deal Dmg Ch = = = = =
    public int Take_Dmg_Red_Ef(int dmg, hero_slot_sc hero_sc)
    {
        if (hero_sc._ef_name.Contains("durability") == true)
        {
        }

        if (hero_sc._ef_name.Contains("shield") == true)
        {
        }

        return dmg;
    }
    public int Take_Dmg_Grow_Ef(int dmg, hero_slot_sc hero_sc)
    {
        if (hero_sc._ef_name.Contains("mark") == true)
        {
        }

        return dmg;
    }


    public int Deal_Dmg_Red_Ef(int dmg, hero_slot_sc hero_sc)
    {


        return dmg;
    }
    public int Deal_Dmg_Grow_Ef(int dmg, hero_slot_sc hero_sc)
    {


        return dmg;
    }
}
