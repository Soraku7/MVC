namespace Mics
{
    public static class Consts
    {
        public const string E_EnterScene = "E_EnterScene";
        public const string E_ExitScene = "E_ExitScene";

        public const string Se_UI_JinBi = "Se_UI_JinBi";
        public const string Se_UI_Magnet = "Se_UI_Magnet";

        public const string V_Player = "V_Player";

        public const string GameModel = "GameModel";
    }

    public enum inputDirState
    {
        Idle,
        Up,
        Down,
        Left,
        Right,
        Collision
    }
}