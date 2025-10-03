// SPDX-FileCopyrightText: Copyright © 2025 sayez10
//
// SPDX-License-Identifier: MIT

using System;
using HarmonyLib;
using PavonisInteractive.TerraInvicta;



namespace TIConstantCostRepeatableResearchMod
{
    [HarmonyPatch(typeof(TITechTemplate), nameof(TITechTemplate.GetResearchCost))]
    internal static class TechnologyCostPatch
    {
        /// <summary>
        /// Removes the cost multiplicator for repeatable global technologies
        /// </summary>
        [HarmonyPrefix]
        private static bool GetResearchCostOverwrite(ref float __result, in TITechTemplate __instance)
        {
            // If mod has been disabled, abort patch and use original method
            if (!Main.enabled) { return true; }

            __result = __instance.researchCost / TIGlobalValuesState.GetResearchSpeedModifier();


            return false; // Skip original method
        }
    }
}
