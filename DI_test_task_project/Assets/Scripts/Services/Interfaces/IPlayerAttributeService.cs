namespace Game.Services
{
    public interface IPlayerAttributeService
    {
        void SetHealth(int value, string source = "Unknown");
        void SetLives(int value, string source = "Unknown");
        void SetNickname(string value, string source = "Unknown");
    }
}