// SPDX-FileCopyrightText: Copyright © 2025 sayez10
//
// SPDX-License-Identifier: MIT

using System;
using HarmonyLib;
using PavonisInteractive.TerraInvicta;



namespace TIConstantCostRepeatableResearchMod
{
    [HarmonyPatch(typeof(TIProjectTemplate), nameof(TIProjectTemplate.GetResearchCost))]
    internal static class ProjectCostPatch
    {
        /// <summary>
        /// Removes the cost multiplicator for repeatable projects
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
