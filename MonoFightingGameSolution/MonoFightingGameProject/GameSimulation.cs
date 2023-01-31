using System;
using System.Collections.Generic;
using System.Text;
using MonoFightingGameProject.utils;

namespace MonoFightingGameProject
{
    public struct PhysicsComponent
    {
        public IntVector2D position;
        public IntVector2D velocity;
        public IntVector2D acceleration;

        public PhysicsComponent(int defaultValue = 0)
        {
            position = new IntVector2D(defaultValue);
            velocity = new IntVector2D(defaultValue);
            acceleration = new IntVector2D(defaultValue);
        }
    }

    public struct GameState
    {
        public int frameCount;
        public int entityCount;

        public PhysicsComponent[] physicsComponents; // Limit to 10 for now?

        public GameState(int playerCount = 2)
        {
            frameCount = 0;
            entityCount = 5;

            physicsComponents = new PhysicsComponent[10];
            Array.ForEach(physicsComponents, pComponent =>
            {
                pComponent = new PhysicsComponent(0);
            });
        }
    }

    public static class GameSimulation
    {
        // Handles moving all entities which have a physics component.
        public static void PhysicsSystem(ref GameState gameState)
        {
            for(int i = 0; i < gameState.entityCount; i++)
            {
                // Update position based on velocity.
                ref PhysicsComponent component = ref gameState.physicsComponents[i];
                component.position.Add(component.velocity);
                component.velocity.Add(component.acceleration);

            }
        }

        public static void UpdateGame(ref GameState gameState)
        {
            PhysicsSystem(ref gameState);
            gameState.frameCount++;
        }
    }
}
