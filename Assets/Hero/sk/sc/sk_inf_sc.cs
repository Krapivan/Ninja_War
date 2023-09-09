public static class sk_inf_sc
{
    public static string Sk_Inf(string name)
    {
        string inf = "";

        //Naruto [Genin]
        {
            if (name == "Naruto Combo")
            {
                inf = "<b>Element:</b> No" +
                    "\n<b>Target(enemy):</b> 1" +
                    "\nDeal damage. Damage grow for each [Naruto Clone] in battle." +
                    "\n<b>LV:</b>" +
                    "\n2. +10% damage" +
                    "\n3. grow for each [Naruto Clone] up" +
                    "\n4. +10% damage" +
                    "\n5. grow for each [Naruto Clone] up";
            }
            if (name == "Shadow Clone")
            {
                inf = "<b>CD:</b> 5" +
                    "\nSummon [Naruto Clone]; [Naruto Clone]: Have 1s % of Naruto base stats; Have Naruto AA; Live 2 turn." +
                    "\n<b>LV:</b>" +
                    "\n2. -1 CD" +
                    "\n3. * 20 % of Naruto base stats" +
                    "\n4. -1 CD" +
                    "\n5. * 30 % of Naruto base stats";
            }
            if (name == "Multiple Shadow Clones")
            {
                inf = "<b>Element:</b> No" +
                    "\n<b>Target(enemy):</b> 1" +
                    "\n<b>CD:</b> 7" +
                    "\nSummon [Naruto Clone]. Naruto and all [Naruto Clone] attack target with [Combo Naruto]." +
                    "\n<b>LV:</b>" +
                    "\n2. -1 CD" +
                    "\n3. -1 CD" +
                    "\n4. +1 more summon [Naruto Clone]" +
                    "\n5. -1 CD";
            }
            if (name == "Ero Jutsu")
            {
                inf = "<b>Target(enemy):</b> All" +
                    "\nAt start of battle: All enemy +[Disarming] for 1 turn." +
                    "\n<b>LV:</b>" +
                    "\n2. * [Disarming] for 2 turn" +
                    "\n3. ! At start of battle: Summon [Naruto Clone] with stats from [Shadow Clones]" +
                    "\n4. ! +10% of Naruto base stats for all [Naruto Clone]" +
                    "\n5. ! Every time when [Naruto Clone], Naruto heal 10% of max HP";
            }
        }

        return inf;
    }
}
