namespace Services.Enums
{
    public enum ApplicationDataValidationResult : byte
    {
        NameIsEmpty = 1,
        NameIsTooShort,
        NameIsTooLong,
        NameContainsInvalidCharacters,
        NamePassedValidationCheck,

        EmailIsEmpty,
        EmailIsTooShort,
        EmailIsTooLong,
        EmailInvalidFirstCharacter,
        EmailPassedValidationCheck,

        MessageIsEmpty,
        MessageIsTooShort,
        MessageIsTooLong,
        MessagePassedValidationCheck
    }
}
