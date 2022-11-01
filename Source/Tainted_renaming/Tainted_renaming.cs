using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace Tainted_renaming
{
    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.github.harmony.rimworld.mod.tainted_renaming");

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }


    }


    [HarmonyPatch(typeof(GenLabel), "NewThingLabel", new Type[] { typeof(Thing), typeof(int), typeof(bool), typeof(bool) })]
    class NewThingLabelClass
    {

        [HarmonyPostfix]
        private static void NewThingLabel(Thing t, int stackCount, bool includeHp, bool includeQuality, ref string __result)
        {
            ThingStyleDef styleDef = t.StyleDef;
            string text;
            if (styleDef != null && !styleDef.overrideLabel.NullOrEmpty())
            {
                text = styleDef.overrideLabel;
            }
            else
            {
                text = GenLabel.ThingLabel(t.def, t.Stuff, 1);
            }

            text = LabelTainted(t) + text + LabelQuality(t, stackCount, includeHp, includeQuality);

            if (stackCount > 1)
            {
                text = text + " x" + stackCount.ToStringCached();
            }
            __result = text;
            return;
        }

        private static string LabelTainted(Thing t)
        {
            Apparel apparel = t as Apparel;

            string text = "";

            bool isTainted = apparel != null && apparel.WornByCorpse;

            if (isTainted)
            {
                text += "WornByCorpseChar".Translate();
                text += " ";
            }

            return text;
        }
        private static string LabelQuality(Thing t, int stackCount, bool includeHp, bool includeQuality)
        {
            Apparel apparel = t as Apparel;

            string text = "";
            QualityCategory cat;
            bool hasQuality = t.TryGetQuality(out cat);
            int hitPoints = t.HitPoints;
            int maxHitPoints = t.MaxHitPoints;
            bool isDamaged = t.def.useHitPoints && hitPoints < maxHitPoints && t.def.stackLimit == 1 && includeHp;

            if (hasQuality || isDamaged)
            {
                text += " (";

                if (hasQuality)
                {
                    text += cat.GetLabel();
                }
                if (isDamaged)
                {
                    if (hasQuality)
                    {
                        text += " ";
                    }
                    text += ((float)hitPoints / (float)maxHitPoints).ToStringPercent();
                }
                text += ")";
            }
            return text;
        }
    }

    //[HarmonyPatch(typeof(GenLabel), "LabelExtras", new Type[] { typeof(Thing), typeof(int), typeof(bool), typeof(bool) })]
    //class LabelExtrasClass
    //{

    //    [HarmonyPostfix]
    //    private static void LabelExtras(Thing t, int stackCount, bool includeHp, bool includeQuality, ref string __result)
    //    {
    //        Apparel apparel = t as Apparel;
    //        bool earlyOut = apparel == null;
    //        //if(earlyOut == true || apparel.WornByCorpse == false)
    //        //{
    //        //    return;
    //        //}

    //        string text = ""; 
    //        QualityCategory cat;
    //        bool hasQuality = t.TryGetQuality(out cat);
    //        int hitPoints = t.HitPoints;
    //        int maxHitPoints = t.MaxHitPoints;
    //        bool isDamaged = t.def.useHitPoints && hitPoints < maxHitPoints && t.def.stackLimit == 1 && includeHp;
    //        bool isTainted = apparel != null && apparel.WornByCorpse;

    //        if (isTainted)
    //        {
    //            text += "WornByCorpseChar".Translate();
    //            text += " ";
    //        }

    //        //text += GenLabel.ThingLabel(t.def, t.Stuff, 1);

    //        if (hasQuality || isDamaged || isTainted)
    //        {
    //            text += "(";

    //            if (hasQuality)
    //            {
    //                text += cat.GetLabel();
    //            }
    //            if (isDamaged)
    //            {
    //                if (hasQuality)
    //                {
    //                    text += " ";
    //                }
    //                text += ((float)hitPoints / (float)maxHitPoints).ToStringPercent();
    //            }
    //            text += ") ";
    //        }
    //        __result = text;
    //        return;
    //    }
    //}
}
