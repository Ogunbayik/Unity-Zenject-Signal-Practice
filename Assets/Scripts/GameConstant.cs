using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant 
{
    public static class Damage
    {
        public const int TEST_DAMAGE = 10;
    }

    public static class EnemyData
    {
        public const float MINIMIM_MOVEMENT_SPEED = 1f;
        public const float MAXIMUM_MOVEMENT_SPEED = 4f;
        public const float SPAWN_BORDER_X_RANGE = 5f;
        public const float SPAWN_INTERVAL_TIME = 6f;
    }

    public static class TankData
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";

        public const float MINIMUM_LIFETIME = 5f;
        public const float MAXIMUM_LIFETME = 10f;

        public const float MINIMUM_BULLET_SPEED = 5f;
        public const float MAXIMUM_BULLET_SPEED = 8f;
    }
}
