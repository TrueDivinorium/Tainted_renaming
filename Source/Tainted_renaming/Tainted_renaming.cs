using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Harmony;
using System.Reflection;

namespace Tainted_renaming
{
    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            //var harmony = HarmonyInstance.Create();
            var harmony = HarmonyInstance.Create("com.github.harmony.rimworld.mod.tainted_renaming");


            //HarmonyInstance harmony = HarmonyInstance.Create("com.github.harmony.rimworld.mod.tainted_renaming");

            //// find the FillTab method of the class RimWorld.ITab_Pawn_Character
            //MethodInfo targetmethod = AccessTools.Method(typeof(GenLabel), "NewThingLabel");

            //// find the static method to call before (i.e. Prefix) the targetmethod
            //HarmonyMethod prefixmethod = new HarmonyMethod(typeof(Main).GetMethod("NewThingLabel"));

            //// patch the targetmethod, by calling prefixmethod before it runs, with no postfixmethod (i.e. null)
            //harmony.Patch(targetmethod, null, prefixmethod,null);

            // harmony.Patch(AccessTools.Method);
            //harmony.Patch(AccessTools.Method(typeof(GenLabel).GetNestedType("LabelRequest", 
            //     BindingFlags.NonPublic | BindingFlags.Instance),
            //     "GenLabel"), 
            //     null, 
            //     new HarmonyMethod(typeof(MyClass), nameof(MyPostFix)));



            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }



        //    private static string NewThingLabel(BuildableDef entDef, ThingDef stuffDef, int stackCount)
        //    {
        //        string text;
        //        if (stuffDef == null)
        //        {
        //            text = entDef.label;
        //        }
        //        else
        //        {
        //            text = "ThingMadeOfStuffLabel".Translate(stuffDef.LabelAsStuff, entDef.label);
        //        }
        //        if (stackCount > 1)
        //        {
        //            text = text + " x" + stackCount.ToStringCached();
        //        }
        //        return text;
        //    }
        //}
        //class Foo
        //{
        //    struct Bar
        //    {
        //        static string secret = "hello";

        //        public string ModifiedSecret()
        //        {
        //            return secret.ToUpper();
        //        }
        //    }

        //    Bar myBar
        //    {
        //        get
        //        {
        //            return new Bar();
        //        }
        //    }

        //    public string GetSecret()
        //    {
        //        return myBar.ModifiedSecret();
        //    }

        //    Foo()
        //    {
        //    }

        //    static Foo MakeFoo()
        //    {
        //        return new Foo();
        //    }
        //}

        //var foo = Traverse.Create<Foo>().Method("MakeFoo").GetValue<Foo>();
        //Traverse.Create(foo).Property("myBar").Field("secret").SetValue("world");
        //Console.WriteLine(foo.GetSecret()); // outputs WORLD


        //[HarmonyPatch]
        //public static class InnerClassPatch
        //{
        //    public static Type innerClass = AccessTools.Inner(typeof(GenLabel), "LabelRequest");

        //    static MethodInfo TargetMethod()
        //    {
        //        MethodInfo methods = innerClass.GetMethod("Equals",
        //        BindingFlags.Public | BindingFlags.Instance,
        //        null,
        //        CallingConventions.Any,
        //        new Type[] { typeof(int).MakePointerType() },
        //        null);
        //        throw new Exception("Cannot find **method name**.");
        //    }



        //    public static string ThingLabel(Thing t, int stackCount, bool includeHp = true)
        //    {
        //        Type key = AccessTools.Inner(typeof(GenLabel), "LabelRequest");
        //        //GenLabel.LabelRequest key = default(GenLabel.LabelRequest);
        //        key.entDef = t.def;
        //        key.stuffDef = t.Stuff;
        //        key.stackCount = stackCount;
        //        t.TryGetQuality(out key.quality);
        //        if (t.def.useHitPoints && includeHp)
        //        {
        //            key.health = t.HitPoints;
        //            key.maxHealth = t.MaxHitPoints;
        //        }
        //        Apparel apparel = t as Apparel;
        //        if (apparel != null)
        //        {
        //            key.wornByCorpse = apparel.WornByCorpse;
        //        }
        //        string text;
        //        if (!GenLabel.labelDictionary.TryGetValue(key, out text))
        //        {
        //            if (GenLabel.labelDictionary.Count > 2000)
        //            {
        //                GenLabel.labelDictionary.Clear();
        //            }
        //            text = GenLabel.NewThingLabel(t, stackCount, includeHp);
        //            GenLabel.labelDictionary.Add(key, text);
        //        }
        //        return text;
        //    }

        //    public bool Equals(type other)
        //    {
        //        return   ___this.entDef == other.entDef && this.stuffDef == other.stuffDef && this.stackCount == other.stackCount && this.quality == other.quality && this.health == other.health && this.maxHealth == other.maxHealth && this.wornByCorpse == other.wornByCorpse;

        //    }

        //}
        //[HarmonyPatch(typeof(GenLabel))]
        ////[HarmonyPatch(typeof(LabelRequest))]
        //static class GenLabel_LabelRequest_Patch
        //{
        //    // Token: 0x0600382A RID: 14378 RVA: 0x001ABACE File Offset: 0x001A9ECE
        //    public static void ClearCache()
        //    {
        //        GenLabel_LabelRequest_Patch.labelDictionary.Clear();
        //    }

        //    // Token: 0x0600382B RID: 14379 RVA: 0x001ABADC File Offset: 0x001A9EDC
        //    public static string ThingLabel(BuildableDef entDef, ThingDef stuffDef, int stackCount = 1)
        //    {
        //        GenLabel_LabelRequest_Patch.LabelRequest key = default(GenLabel_LabelRequest_Patch.LabelRequest);
        //        key.entDef = entDef;
        //        key.stuffDef = stuffDef;
        //        key.stackCount = stackCount;
        //        string text;
        //        if (!GenLabel_LabelRequest_Patch.labelDictionary.TryGetValue(key, out text))
        //        {
        //            if (GenLabel_LabelRequest_Patch.labelDictionary.Count > 2000)
        //            {
        //                GenLabel_LabelRequest_Patch.labelDictionary.Clear();
        //            }
        //            text = GenLabel_LabelRequest_Patch.NewThingLabel(entDef, stuffDef, stackCount);
        //            GenLabel_LabelRequest_Patch.labelDictionary.Add(key, text);
        //        }
        //        return text;
        //    }

        //    // Token: 0x0600382C RID: 14380 RVA: 0x001ABB50 File Offset: 0x001A9F50
        //    private static string NewThingLabel(BuildableDef entDef, ThingDef stuffDef, int stackCount)
        //    {
        //        string text;
        //        if (stuffDef == null)
        //        {
        //            text = entDef.label;
        //        }
        //        else
        //        {
        //            text = "ThingMadeOfStuffLabel".Translate(stuffDef.LabelAsStuff, entDef.label);
        //        }
        //        if (stackCount > 1)
        //        {
        //            text = text + " x" + stackCount.ToStringCached();
        //        }
        //        return text;
        //    }

        //    // Token: 0x0600382D RID: 14381 RVA: 0x001ABBAC File Offset: 0x001A9FAC
        //    public static string ThingLabel(Thing t, int stackCount, bool includeHp = true)
        //    {
        //        GenLabel_LabelRequest_Patch.LabelRequest key = default(GenLabel_LabelRequest_Patch.LabelRequest);
        //        key.entDef = t.def;
        //        key.stuffDef = t.Stuff;
        //        key.stackCount = stackCount;
        //        t.TryGetQuality(out key.quality);
        //        if (t.def.useHitPoints && includeHp)
        //        {
        //            key.health = t.HitPoints;
        //            key.maxHealth = t.MaxHitPoints;
        //        }
        //        Apparel apparel = t as Apparel;
        //        if (apparel != null)
        //        {
        //            key.wornByCorpse = apparel.WornByCorpse;
        //        }
        //        string text;
        //        if (!GenLabel_LabelRequest_Patch.labelDictionary.TryGetValue(key, out text))
        //        {
        //            if (GenLabel_LabelRequest_Patch.labelDictionary.Count > 2000)
        //            {
        //                GenLabel_LabelRequest_Patch.labelDictionary.Clear();
        //            }
        //            text = GenLabel_LabelRequest_Patch.NewThingLabel(t, stackCount, includeHp);
        //            GenLabel_LabelRequest_Patch.labelDictionary.Add(key, text);
        //        }
        //        return text;
        //    }

        //    // Token: 0x0600382E RID: 14382 RVA: 0x001ABC84 File Offset: 0x001AA084
        //    private static string NewThingLabel(Thing t, int stackCount, bool includeHp)
        //    {
        //        string text = GenLabel_LabelRequest_Patch.ThingLabel(t.def, t.Stuff, 1);
        //        QualityCategory cat;
        //        bool flag = t.TryGetQuality(out cat);
        //        int hitPoints = t.HitPoints;
        //        int maxHitPoints = t.MaxHitPoints;
        //        bool flag2 = t.def.useHitPoints && hitPoints < maxHitPoints && t.def.stackLimit == 1 && includeHp;
        //        Apparel apparel = t as Apparel;
        //        bool flag3 = apparel != null && apparel.WornByCorpse;
        //        if (flag || flag2 || flag3)
        //        {
        //            text += " (";
        //            if (flag)
        //            {
        //                text += cat.GetLabel();
        //            }
        //            if (flag2)
        //            {
        //                if (flag)
        //                {
        //                    text += " ";
        //                }
        //                text += ((float)hitPoints / (float)maxHitPoints).ToStringPercent();
        //            }
        //            if (flag3)
        //            {
        //                if (flag || flag2)
        //                {
        //                    text += " ";
        //                }
        //                text += "WornByCorpseChar".Translate();
        //            }
        //            text += ")";
        //        }
        //        if (stackCount > 1)
        //        {
        //            text = text + " x" + stackCount.ToStringCached();
        //        }
        //        return text;
        //    }

        //    // Token: 0x0600382F RID: 14383 RVA: 0x001ABDBC File Offset: 0x001AA1BC
        //    public static string ThingsLabel(List<Thing> things, string prefix = "  - ")
        //    {
        //        GenLabel_LabelRequest_Patch.tmpThingCounts.Clear();
        //        for (int i = 0; i < things.Count; i++)
        //        {
        //            GenLabel_LabelRequest_Patch.tmpThingCounts.Add(new ThingCount(things[i], things[i].stackCount));
        //        }
        //        string result = GenLabel_LabelRequest_Patch.ThingsLabel(GenLabel_LabelRequest_Patch.tmpThingCounts, prefix);
        //        GenLabel_LabelRequest_Patch.tmpThingCounts.Clear();
        //        return result;
        //    }

        //    // Token: 0x06003830 RID: 14384 RVA: 0x001ABE24 File Offset: 0x001AA224
        //    public static string ThingsLabel(List<ThingCount> things, string prefix = "  - ")
        //    {
        //        GenLabel_LabelRequest_Patch.tmpThingsLabelElements.Clear();
        //        using (List<ThingCount>.Enumerator enumerator = things.GetEnumerator())
        //        {
        //            while (enumerator.MoveNext())
        //            {
        //                ThingCount thing = enumerator.Current;
        //                GenLabel_LabelRequest_Patch.LabelElement labelElement = (from elem in GenLabel_LabelRequest_Patch.tmpThingsLabelElements
        //                                                      where thing.Thing.def.stackLimit > 1 && elem.thingTemplate.def == thing.Thing.def && elem.thingTemplate.Stuff == thing.Thing.Stuff
        //                                                      select elem).FirstOrDefault<GenLabel_LabelRequest_Patch.LabelElement>();
        //                if (labelElement != null)
        //                {
        //                    labelElement.count += thing.Count;
        //                }
        //                else
        //                {
        //                    GenLabel_LabelRequest_Patch.tmpThingsLabelElements.Add(new GenLabel_LabelRequest_Patch.LabelElement
        //                    {
        //                        thingTemplate = thing.Thing,
        //                        count = thing.Count
        //                    });
        //                }
        //            }
        //        }
        //        GenLabel_LabelRequest_Patch.tmpThingsLabelElements.Sort(delegate (GenLabel_LabelRequest_Patch.LabelElement lhs, GenLabel_LabelRequest_Patch.LabelElement rhs)
        //        {
        //            int num = TransferableComparer_Category.Compare(lhs.thingTemplate.def, rhs.thingTemplate.def);
        //            if (num != 0)
        //            {
        //                return num;
        //            }
        //            return lhs.thingTemplate.MarketValue.CompareTo(rhs.thingTemplate.MarketValue);
        //        });
        //        StringBuilder stringBuilder = new StringBuilder();
        //        foreach (GenLabel_LabelRequest_Patch.LabelElement labelElement2 in GenLabel_LabelRequest_Patch.tmpThingsLabelElements)
        //        {
        //            string str = string.Empty;
        //            if (labelElement2.thingTemplate.ParentHolder is Pawn_ApparelTracker)
        //            {
        //                str = " (" + "WornBy".Translate(((Pawn)labelElement2.thingTemplate.ParentHolder.ParentHolder).LabelShort, (Pawn)labelElement2.thingTemplate.ParentHolder.ParentHolder) + ")";
        //            }
        //            else if (labelElement2.thingTemplate.ParentHolder is Pawn_EquipmentTracker)
        //            {
        //                str = " (" + "EquippedBy".Translate(((Pawn)labelElement2.thingTemplate.ParentHolder.ParentHolder).LabelShort, (Pawn)labelElement2.thingTemplate.ParentHolder.ParentHolder) + ")";
        //            }
        //            if (labelElement2.count == 1)
        //            {
        //                stringBuilder.AppendLine(prefix + labelElement2.thingTemplate.LabelCap + str);
        //            }
        //            else
        //            {
        //                stringBuilder.AppendLine(prefix + GenLabel_LabelRequest_Patch.ThingLabel(labelElement2.thingTemplate.def, labelElement2.thingTemplate.Stuff, labelElement2.count).CapitalizeFirst() + str);
        //            }
        //        }
        //        GenLabel_LabelRequest_Patch.tmpThingsLabelElements.Clear();
        //        return stringBuilder.ToString().TrimEndNewlines();
        //    }

        //    // Token: 0x06003831 RID: 14385 RVA: 0x001AC0E8 File Offset: 0x001AA4E8
        //    public static string BestKindLabel(Pawn pawn, bool mustNoteGender = false, bool mustNoteLifeStage = false, bool plural = false, int pluralCount = -1)
        //    {
        //        if (plural && pluralCount == 1)
        //        {
        //            plural = false;
        //        }
        //        bool flag = false;
        //        bool flag2 = false;
        //        string text = null;
        //        Gender gender = pawn.gender;
        //        if (gender != Gender.None)
        //        {
        //            if (gender != Gender.Male)
        //            {
        //                if (gender == Gender.Female)
        //                {
        //                    if (plural && !pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.labelFemalePlural != null)
        //                    {
        //                        text = pawn.ageTracker.CurKindLifeStage.labelFemalePlural;
        //                        flag2 = true;
        //                        flag = true;
        //                    }
        //                    else if (!pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.labelFemale != null)
        //                    {
        //                        text = pawn.ageTracker.CurKindLifeStage.labelFemale;
        //                        flag2 = true;
        //                        flag = true;
        //                        if (plural)
        //                        {
        //                            text = Find.ActiveLanguageWorker.Pluralize(text, pawn.gender, pluralCount);
        //                        }
        //                    }
        //                    else if (plural && !pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.labelPlural != null)
        //                    {
        //                        text = pawn.ageTracker.CurKindLifeStage.labelPlural;
        //                        flag2 = true;
        //                    }
        //                    else if (!pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.label != null)
        //                    {
        //                        text = pawn.ageTracker.CurKindLifeStage.label;
        //                        flag2 = true;
        //                        if (plural)
        //                        {
        //                            text = Find.ActiveLanguageWorker.Pluralize(text, pawn.gender, pluralCount);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        text = GenLabel_LabelRequest_Patch.BestKindLabel(pawn.kindDef, Gender.Female, out flag, plural, pluralCount);
        //                    }
        //                }
        //            }
        //            else if (plural && !pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.labelMalePlural != null)
        //            {
        //                text = pawn.ageTracker.CurKindLifeStage.labelMalePlural;
        //                flag2 = true;
        //                flag = true;
        //            }
        //            else if (!pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.labelMale != null)
        //            {
        //                text = pawn.ageTracker.CurKindLifeStage.labelMale;
        //                flag2 = true;
        //                flag = true;
        //                if (plural)
        //                {
        //                    text = Find.ActiveLanguageWorker.Pluralize(text, pawn.gender, pluralCount);
        //                }
        //            }
        //            else if (plural && !pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.labelPlural != null)
        //            {
        //                text = pawn.ageTracker.CurKindLifeStage.labelPlural;
        //                flag2 = true;
        //            }
        //            else if (!pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.label != null)
        //            {
        //                text = pawn.ageTracker.CurKindLifeStage.label;
        //                flag2 = true;
        //                if (plural)
        //                {
        //                    text = Find.ActiveLanguageWorker.Pluralize(text, pawn.gender, pluralCount);
        //                }
        //            }
        //            else
        //            {
        //                text = GenLabel_LabelRequest_Patch.BestKindLabel(pawn.kindDef, Gender.Male, out flag, plural, pluralCount);
        //            }
        //        }
        //        else if (plural && !pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.labelPlural != null)
        //        {
        //            text = pawn.ageTracker.CurKindLifeStage.labelPlural;
        //            flag2 = true;
        //        }
        //        else if (!pawn.RaceProps.Humanlike && pawn.ageTracker.CurKindLifeStage.label != null)
        //        {
        //            text = pawn.ageTracker.CurKindLifeStage.label;
        //            flag2 = true;
        //            if (plural)
        //            {
        //                text = Find.ActiveLanguageWorker.Pluralize(text, pawn.gender, pluralCount);
        //            }
        //        }
        //        else
        //        {
        //            text = GenLabel_LabelRequest_Patch.BestKindLabel(pawn.kindDef, Gender.None, out flag, plural, pluralCount);
        //        }
        //        if (mustNoteGender && !flag && pawn.gender != Gender.None)
        //        {
        //            text = "PawnMainDescGendered".Translate(pawn.GetGenderLabel(), text, pawn.Named("PAWN"));
        //        }
        //        if (mustNoteLifeStage && !flag2 && pawn.ageTracker != null && pawn.ageTracker.CurLifeStage.visible)
        //        {
        //            text = "PawnMainDescLifestageWrap".Translate(text, pawn.ageTracker.CurLifeStage.Adjective, pawn);
        //        }
        //        return text;
        //    }

        //    // Token: 0x06003832 RID: 14386 RVA: 0x001AC514 File Offset: 0x001AA914
        //    public static string BestKindLabel(PawnKindDef kindDef, Gender gender, bool plural = false, int pluralCount = -1)
        //    {
        //        bool flag;
        //        return GenLabel_LabelRequest_Patch.BestKindLabel(kindDef, gender, out flag, plural, pluralCount);
        //    }

        //    // Token: 0x06003833 RID: 14387 RVA: 0x001AC52C File Offset: 0x001AA92C
        //    public static string BestKindLabel(PawnKindDef kindDef, Gender gender, out bool genderNoted, bool plural = false, int pluralCount = -1)
        //    {
        //        if (plural && pluralCount == 1)
        //        {
        //            plural = false;
        //        }
        //        string text = null;
        //        genderNoted = false;
        //        if (gender != Gender.None)
        //        {
        //            if (gender != Gender.Male)
        //            {
        //                if (gender == Gender.Female)
        //                {
        //                    if (plural && kindDef.labelFemalePlural != null)
        //                    {
        //                        text = kindDef.labelFemalePlural;
        //                        genderNoted = true;
        //                    }
        //                    else if (kindDef.labelFemale != null)
        //                    {
        //                        text = kindDef.labelFemale;
        //                        genderNoted = true;
        //                        if (plural)
        //                        {
        //                            text = Find.ActiveLanguageWorker.Pluralize(text, gender, pluralCount);
        //                        }
        //                    }
        //                    else if (plural && kindDef.labelPlural != null)
        //                    {
        //                        text = kindDef.labelPlural;
        //                    }
        //                    else
        //                    {
        //                        text = kindDef.label;
        //                        if (plural)
        //                        {
        //                            text = Find.ActiveLanguageWorker.Pluralize(text, gender, pluralCount);
        //                        }
        //                    }
        //                }
        //            }
        //            else if (plural && kindDef.labelMalePlural != null)
        //            {
        //                text = kindDef.labelMalePlural;
        //                genderNoted = true;
        //            }
        //            else if (kindDef.labelMale != null)
        //            {
        //                text = kindDef.labelMale;
        //                genderNoted = true;
        //                if (plural)
        //                {
        //                    text = Find.ActiveLanguageWorker.Pluralize(text, gender, pluralCount);
        //                }
        //            }
        //            else if (plural && kindDef.labelPlural != null)
        //            {
        //                text = kindDef.labelPlural;
        //            }
        //            else
        //            {
        //                text = kindDef.label;
        //                if (plural)
        //                {
        //                    text = Find.ActiveLanguageWorker.Pluralize(text, gender, pluralCount);
        //                }
        //            }
        //        }
        //        else if (plural && kindDef.labelPlural != null)
        //        {
        //            text = kindDef.labelPlural;
        //        }
        //        else
        //        {
        //            text = kindDef.label;
        //            if (plural)
        //            {
        //                text = Find.ActiveLanguageWorker.Pluralize(text, gender, pluralCount);
        //            }
        //        }
        //        return text;
        //    }

        //    // Token: 0x04002482 RID: 9346
        //    private static Dictionary<GenLabel_LabelRequest_Patch.LabelRequest, string> labelDictionary = new Dictionary<GenLabel_LabelRequest_Patch.LabelRequest, string>();

        //    // Token: 0x04002483 RID: 9347
        //    private const int LabelDictionaryMaxCount = 2000;

        //    // Token: 0x04002484 RID: 9348
        //    private static List<ThingCount> tmpThingCounts = new List<ThingCount>();

        //    // Token: 0x04002485 RID: 9349
        //    private static List<GenLabel_LabelRequest_Patch.LabelElement> tmpThingsLabelElements = new List<GenLabel_LabelRequest_Patch.LabelElement>();

        //    // Token: 0x020009B8 RID: 2488
        //    private class LabelElement
        //    {
        //        // Token: 0x04002487 RID: 9351
        //        public Thing thingTemplate;

        //        // Token: 0x04002488 RID: 9352
        //        public int count;
        //    }

        //    // Token: 0x020009B9 RID: 2489
        //    private struct LabelRequest : IEquatable<GenLabel_LabelRequest_Patch.LabelRequest>
        //    {
        //        // Token: 0x06003837 RID: 14391 RVA: 0x001AC73B File Offset: 0x001AAB3B
        //        public static bool operator ==(GenLabel_LabelRequest_Patch.LabelRequest lhs, GenLabel_LabelRequest_Patch.LabelRequest rhs)
        //        {
        //            return lhs.Equals(rhs);
        //        }

        //        // Token: 0x06003838 RID: 14392 RVA: 0x001AC745 File Offset: 0x001AAB45
        //        public static bool operator !=(GenLabel_LabelRequest_Patch.LabelRequest lhs, GenLabel_LabelRequest_Patch.LabelRequest rhs)
        //        {
        //            return !(lhs == rhs);
        //        }

        //        // Token: 0x06003839 RID: 14393 RVA: 0x001AC751 File Offset: 0x001AAB51
        //        public override bool Equals(object obj)
        //        {
        //            return obj is GenLabel_LabelRequest_Patch.LabelRequest && this.Equals((GenLabel_LabelRequest_Patch.LabelRequest)obj);
        //        }

        //        // Token: 0x0600383A RID: 14394 RVA: 0x001AC76C File Offset: 0x001AAB6C
        //        public bool Equals(GenLabel_LabelRequest_Patch.LabelRequest other)
        //        {
        //            return this.entDef == other.entDef && this.stuffDef == other.stuffDef && this.stackCount == other.stackCount && this.quality == other.quality && this.health == other.health && this.maxHealth == other.maxHealth && this.wornByCorpse == other.wornByCorpse;
        //        }

        //        // Token: 0x0600383B RID: 14395 RVA: 0x001AC7F8 File Offset: 0x001AABF8
        //        public override int GetHashCode()
        //        {
        //            int num = 0;
        //            num = Gen.HashCombine<BuildableDef>(num, this.entDef);
        //            num = Gen.HashCombine<ThingDef>(num, this.stuffDef);
        //            ThingDef thingDef = this.entDef as ThingDef;
        //            if (thingDef != null)
        //            {
        //                num = Gen.HashCombineInt(num, this.stackCount);
        //                num = Gen.HashCombineStruct<QualityCategory>(num, this.quality);
        //                if (thingDef.useHitPoints)
        //                {
        //                    num = Gen.HashCombineInt(num, this.health);
        //                    num = Gen.HashCombineInt(num, this.maxHealth);
        //                }
        //                num = Gen.HashCombineInt(num, (!this.wornByCorpse) ? 0 : 1);
        //            }
        //            return num;
        //        }

        //        // Token: 0x04002489 RID: 9353
        //        public BuildableDef entDef;

        //        // Token: 0x0400248A RID: 9354
        //        public ThingDef stuffDef;

        //        // Token: 0x0400248B RID: 9355
        //        public int stackCount;

        //        // Token: 0x0400248C RID: 9356
        //        public QualityCategory quality;

        //        // Token: 0x0400248D RID: 9357
        //        public int health;

        //        // Token: 0x0400248E RID: 9358
        //        public int maxHealth;

        //        // Token: 0x0400248F RID: 9359
        //        public bool wornByCorpse;
        //    }
    }
    [HarmonyPatch(typeof(GenLabel), "NewThingLabel", new Type[] { typeof(Thing), typeof(int), typeof(bool) })]
    class teste
    {
        [HarmonyPostfix]
        private static bool NewThingLabel(Thing t, int stackCount, bool includeHp)
        {
            Apparel apparel = t as Apparel;
            if (apparel != null && !apparel.WornByCorpse)
                return false;
            string text = GenLabel.ThingLabel(t.def, t.Stuff, 1);
            QualityCategory cat;
            bool flag = t.TryGetQuality(out cat);
            int hitPoints = t.HitPoints;
            int maxHitPoints = t.MaxHitPoints;
            bool flag2 = t.def.useHitPoints && hitPoints < maxHitPoints && t.def.stackLimit == 1 && includeHp;
            bool flag3 = apparel != null && apparel.WornByCorpse;
            if (flag || flag2 || flag3)
            {
                text += " (31231";
                if (flag3)
                {
                    if (flag || flag2)
                    {
                        text += " ";
                    }
                    text += "WornByCorpseChar".Translate();
                }
                if (flag)
                {
                    text += cat.GetLabel();
                }
                if (flag2)
                {
                    if (flag)
                    {
                        text += " ";
                    }
                    text += ((float)hitPoints / (float)maxHitPoints).ToStringPercent();
                }
                text += ")";
            }
            if (stackCount > 1)
            {
                text = text + " x" + stackCount.ToStringCached();
            }
            string ___result = text;
            return true;
        }
    }
}
