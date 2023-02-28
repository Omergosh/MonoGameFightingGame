using System;
using System.Collections.Generic;
using System.Text;

namespace MonoFightingGameProject.ActionStates
{
    // Standing state
    public struct StandingState : CombatStateCallbacks
    {
        public void OnStart()
        {
            Console.WriteLine("StandingState.OnStart()");
        }
        public void OnUpdate()
        {
            Console.WriteLine("StandingState.OnUpdate()");
        }
        public void OnEnd()
        {
            Console.WriteLine("StandingState.OnEnd()");
        }
    }

    // Crouching state
    public struct CrouchingState : CombatStateCallbacks
    {
        public void OnStart()
        {
            Console.WriteLine("CrouchingState.OnStart()");
        }
        public void OnUpdate()
        {
            Console.WriteLine("CrouchingState.OnUpdate()");
        }
        public void OnEnd()
        {
            Console.WriteLine("CrouchingState.OnEnd()");
        }
    }

    // TODO: Remove this legacy code from earlier prototyping
    /*public static class StandingState
    {
        public static void OnStart()
        {
            // Do stuff on starting the state
        }
        public static void OnUpdate()
        {
            // Do stuff every frame
        }
        public static void OnEnd()
        {
            // Do stuff when ending the state
        }
    }*/
}
