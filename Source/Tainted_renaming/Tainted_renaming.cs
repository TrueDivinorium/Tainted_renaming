using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using HarmonyLib;
using System.Reflection;

namespace Tainted_renaming
{
    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            //var harmony = HarmonyInstance.Create();
            //var harmony = HarmonyInstance.Create("com.github.harmony.rimworld.mod.tainted_renaming");
            var harmony = new Harmony("com.github.harmony.rimworld.mod.tainted_renaming");

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }


    }
    [HarmonyPatch(typeof(GenLabel), "NewThingLabel", new Type[] { typeof(Thing), typeof(int), typeof(bool) })]
    class teste
    {
        [HarmonyPostfix]
        private static void NewThingLabel(Thing t, int stackCount, bool includeHp ,ref string __result)
        {
            Apparel apparel = t as Apparel;
            bool earlyOut = apparel == null;
            if(earlyOut == true || apparel.WornByCorpse == false)
            {
                //Log.Message("Hello World!"); //Outputs "Hello World!" to the dev console.
                return;
            }
            //Log.Message("Bye World!"); //Outputs "Hello World!2" to the dev console.

            string text = ""; // GenLabel.ThingLabel(t.def, t.Stuff, 1);
            QualityCategory cat;
            bool hasQuality = t.TryGetQuality(out cat);
            int hitPoints = t.HitPoints;
            int maxHitPoints = t.MaxHitPoints;
            bool isDamaged = t.def.useHitPoints && hitPoints < maxHitPoints && t.def.stackLimit == 1 && includeHp;
            //Apparel apparel = t as Apparel;
            bool isTainted = apparel != null && apparel.WornByCorpse;


            if (isTainted)
            {
                text += "WornByCorpseChar".Translate();
                text += " ";
            }

            text += GenLabel.ThingLabel(t.def, t.Stuff, 1);

            if (hasQuality || isDamaged || isTainted)
            {
                text += " (";

                if (hasQuality)
                {
                    text += cat.GetLabel();
                    //Log.Message("1 flag"); //Outputs "Hello World!2" to the dev console.
                }
                if (isDamaged)
                {
                    if (hasQuality)
                    {
                        text += " ";
                    }
                    text += ((float)hitPoints / (float)maxHitPoints).ToStringPercent();
                    //Log.Message("2 flags"); //Outputs "Hello World!2" to the dev console.
                }
                text += ")";
            }
            if (stackCount > 1)
            {
                text = text + " x" + stackCount.ToStringCached();
                //Log.Message("number"); //Outputs "Hello World!2" to the dev console.
            }
            //Log.Message(text); //Outputs "Hello World!2" to the dev console.
            __result = text;


            //string text = GenLabel.ThingLabel(t.def, t.Stuff, 1);
            //QualityCategory cat;
            //bool flag = t.TryGetQuality(out cat);
            //int hitPoints = t.HitPoints;
            //int maxHitPoints = t.MaxHitPoints;
            //bool flag2 = t.def.useHitPoints && hitPoints < maxHitPoints && t.def.stackLimit == 1 && includeHp;
            //if (flag || flag2 || earlyOut)
            //{
            //    text += " (31231";
            //    if (earlyOut)
            //    {
            //        if (flag || flag2)
            //        {
            //            text += " ";
            //        }
            //        text += "WornByCorpseChar".Translate();
            //    }
            //    if (flag)
            //    {
            //        text += cat.GetLabel();
            //    }
            //    if (flag2)
            //    {
            //        if (flag)
            //        {
            //            text += " ";
            //        }
            //        text += ((float)hitPoints / (float)maxHitPoints).ToStringPercent();
            //    }
            //    text += ")";
            //}
            //if (stackCount > 1)
            //{
            //    text = text + " x" + stackCount.ToStringCached();
            //}
            //string ___result = text;
            return;
        }
    }
}
