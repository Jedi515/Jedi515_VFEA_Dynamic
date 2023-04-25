[HarmonyPatch(typeof(ITab_Pawn_Powers), "FillTab")]
public static class Dynamic_Powers
{

    private static MethodInfo selPawn = AccessTools.PropertyGetter(typeof(ITab_Pawn_Powers), "SelPawn");
    private static void Prefix(ITab_Pawn_Powers __instance)
    {
        var pawn = selPawn.Invoke(__instance, null) as Pawn;
        if (pawn != null)
        {
            var tracker = pawn.GetPowerTracker();
            if (tracker != null)
            {
                int setPow = tracker.AllPowers.Count(pow => pow.powerType == PowerType.Superpower);
                setPow = Mathf.Max(setPow, tracker.AllPowers.Count() - setPow, 5);
                ITab_Pawn_Powers.MaxPowers = setPow;
            }
        }
    }