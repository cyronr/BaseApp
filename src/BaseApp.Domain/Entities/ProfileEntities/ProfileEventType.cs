namespace BaseApp.Domain.Entities.ProfileEntities;

public enum ProfileEventType
{
    Created = 10,
    Updated = 20,
    Deleted = 30,

    SuccessfulLogon = 100,
    UnsuccessfulLogonAttempt = 110
}