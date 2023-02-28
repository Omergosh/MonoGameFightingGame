using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonoFightingGameProject.ActionStates
{
    // Identifies common character states.
    public enum CombatStateID
    {
        Standing,
        Crouching,
        WalkingForward,
        WalkingBackwards,
        Jump,
        // When writing this in Rust, make this a non-exhaustive enum.
    }

    // Provides an interface for combat states to respond to various events
    public interface CombatStateCallbacks
    {
        public void OnStart();          // Called when starting an action
        public void OnUpdate();         // Called every frame
        public void OnEnd();            // Called when finishing an action
    }

    public static class CombatStateRegistry
    {
        const int MAX_STATES = 256;
        public static CombatStateCallbacks[] CombatStatesCommon = new CombatStateCallbacks[MAX_STATES];
        public static int StateCountCommon = 0;
        //public static int StateCountUnique = 0;

        public static Dictionary<string, CombatStateCallbacks> CombatStatesUnique = new Dictionary<string, CombatStateCallbacks>();

        public static void RegisterCommonState(CombatStateID newStateID, CombatStateCallbacks newStateCallbacks)
        {
            //Debug.Assert((int)newStateID <= Enum.GetNames(typeof(CombatStateID)).Length);

            CombatStatesCommon[StateCountCommon] = newStateCallbacks;
            StateCountCommon++;
        }

        public static void RegisterUniqueState(CombatStateID newStateID, CombatStateCallbacks newStateCallbacks)
        {
            
        }
    }

    public static class StateExecutor
    {
        // Use CombatStateRegistry
    }
}
