// SPDX-FileCopyrightText: Copyright © 2025 sayez10
//
// SPDX-License-Identifier: MIT

using System;
using HarmonyLib;
using PavonisInteractive.TerraInvicta;



namespace TIConstantCostRepeatableResearchMod
{
    [HarmonyPatch(typeof(TIFactionState), "AddCompletedProject")]
    internal static class ProjectDataPatch
    {
        /// <summary>
        /// Avoids adding the completed repeatable projects to various data structures
        /// Just a small optimization to reduce late game lag a tiny little bit
        /// </summary>
        [HarmonyPrefix]
        private static bool AddCompletedProjectPrefix(TIFactionState __instance, in TIProjectTemplate project)
        {
            // If mod has been disabled, abort patch and use original method
            if (!Main.enabled) { return true; }

            if (project.repeatable)
            {
                __instance.AIReviewProjects = true;
                return false; // Skip original method
            }


            return true; // Continue with original method
        }
    }
}
