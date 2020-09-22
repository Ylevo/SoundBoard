namespace SoundBoard.Helpers
{
    public static class ErrorHelper
    {
        public const string UnexpectedErrorPlayback = "An unexpected error has occurred while trying to play the track(s) :\n{0}. File could be corrupted.";
        public const string UnexpectedErrorAddHotkey = "An unexpected error has occurred while trying to add a new hotkey.\nA logfile has been created at {0}.";
        public const string UnexpectedErrorDataGridEdit = "An unexpected error has occurred and the hotkey had to be removed.\nA logfile has been created at {0}.";
        public const string UnexpectedErrorExportZip = "An unexpected error has occurred and the export as zip was cancelled.\nA logfile has been created at {0}.";
        public const string UnknownErrorRegisterHotkey = "The hotkey could not be registered and/or unregistered for an unknown reason.\nA logfile has been created at {0}.";
        public const string AudioFileMissingOrInvalidException = "Audio file(s) not found or of invalid type.\n{0}";
        public const string KeyAlreadyUsedException = "The key {0} is already used.";
        public const string KeyForbiddenException = "The key {0} is forbidden or used by another software.";
        public const string KeyInvalidException = "The key {0} is invalid.";
        public const string KeyMissingException = "Please enter a key.";
        public const string KeyEmptyException = "Hotkey could not be registered : key is empty.";
        public const string NoFileSelectedException = "No audio file(s) selected.";
        public const string MasterHotkeyUsedException = "You can have only one hotkey of that kind.\nCurrent hotkey's key used: {0}";
        public const string InvalidTimeValueException = "The time value \"{0}\" is invalid.";
        public const string InvalidVolumeValueException = "The volume value \"{0}\" is invalid.";
        public const string InvalidStartValueException = "The starting time value \"{0}\" is invalid.";
        public const string ConfigFileCorrupted = "Config file appeared corrupted and has been reinitialized.";
        public const string ConfigFileFailure = "Could not load or create config files. Application will close.\nA logfile has been created at {0}.";
        public const string UnhandledProgramFailure = "An unexpected problem occurred and the application will close.\nA logfile has been created at {0}.\n\nError message :\n{1}";


        public static class XmlLoad
        {
            public const string UnexpectedErrorException = "An unexpected error has occurred while trying to load the hotkeys. The hotkeys may not have been loaded properly.\nA logfile has been created at {0}.";
            public const string XmlFileNotFoundException = "The XML file ({0}) could not be found.";
            public const string EmptyXmlFileException = "The XML file ({0}) was found empty.";
            public const string AudioFilesFolderMissingException = "The audio files' folder ({0}) of the imported hotkeys is missing. The audio hotkeys were not imported.";
            public const string UnexpectedHotkeyErrorException = "An unexpected error has occurred while trying to load the hotkey using {0}. Task was aborted. \nA logfile has been created at {1}";
            public const string HotkeyRoleInvalidException = "The hotkey's role '{0}' of {1} is not valid.";
            public const string KeyRemappingFailedException = "The key '{0}' could not be remapped to the current keyboard layout.";
        }

        public static class XmlSave
        {
            public const string UnexpectedErrorException = "An unexpected error has occurred while trying to save the hotkeys. The hotkeys may not have been saved properly.\nA logfile has been created at {0}.";
        }
    }
}
