namespace Illarion.Common.System
{
    public enum LogoutReason
    {
        NormalLogout,
        OldClient,
        AlreadyOnline,
        WrongPassword,
        ServerShutdown,
        ByGamemaster,
        ForCreate,
        NoPlace,
        NoCharacterFound,
        PlayerCreated,
        UnstableConnection,
        NoAccount,
        NoSkills,
        CorruptData,
        Unknown
    }
}