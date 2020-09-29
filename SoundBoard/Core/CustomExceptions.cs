using System;
using SoundBoard.Helpers;
using SoundBoard.Persistence;

namespace SoundBoard.Core
{

    public class CustomException : Exception
    {
        public string MessageToUser { get; private set; }

        public CustomException(string message, string userMessage) : base (message)
        {
            MessageToUser = userMessage;
        } 
    }

    public class AudioFileMissingOrInvalidException : CustomException
    {
        public AudioFileMissingOrInvalidException(string files) : base(string.Format("Invalid file type or removed files (former should not happen). Files : \n{0}", files), 
                                                                       string.Format(ErrorHelper.AudioFileMissingOrInvalidException, files)) { }
    }

    public class XmlFileNotFoundException : CustomException
    {
        public XmlFileNotFoundException(string xmlFilePath ) : base("File either removed or moved away, end user manipulation.", 
                                                                    string.Format(ErrorHelper.XmlLoad.XmlFileNotFoundException, xmlFilePath)) { }
    }

    public class XmlFileEmptyException : CustomException
    {
        public XmlFileEmptyException(string xmlFilePath) : base(@"Empty or half empty (only root present) XML should NEVER happen unless user cleaned it themselves. 
                                                                   Xml could have not been saved properly for some reason.", string.Format(ErrorHelper.XmlLoad.EmptyXmlFileException, xmlFilePath)) { }
    }

    public class KeyMissingException : CustomException
    {
        public KeyMissingException() : base("", string.Format(ErrorHelper.KeyMissingException)) { }
    }

    public class KeyEmptyException : CustomException
    {
        public KeyEmptyException() : base("", string.Format(ErrorHelper.KeyEmptyException)) { }
    }

    public class KeyInvalidException : CustomException
    {
        public KeyInvalidException(string key) : base(string.Format("Key string didn't translate to valid key enum. Happens if string is empty (keys.none will come out)."), 
                                                      string.Format(ErrorHelper.KeyInvalidException, key)) { }
    }

    public class KeyForbiddenException : CustomException
    {
        public KeyForbiddenException(string key) : base(string.Format("Keys used or restricted by Windows, no exhaustive list yet. Key : {0}", key), 
                                                        string.Format(ErrorHelper.KeyForbiddenException, key)) { }
    }

    public class KeyAlreadyUsedException : CustomException
    {
        public KeyAlreadyUsedException(string key) : base("Key already used, nothing going on.", string.Format(ErrorHelper.KeyAlreadyUsedException, key)) { }
    }

    public class KeyRemappingFailedException : CustomException
    {
        public KeyRemappingFailedException(string key, short originalLayoutIdentifier) : base(string.Format("Key remapping failed, equaled to Keys.None. Key : {0} | KeyboardLayoutId : {1} ", key, originalLayoutIdentifier), 
                                                                                              string.Format(ErrorHelper.XmlLoad.KeyRemappingFailedException, key)) { }
    }

    public class AudioFilesFolderMissingException : CustomException
    {
        public AudioFilesFolderMissingException(string audioFilesFolder) : base("Audio files' folder of zip imported hotkeys was missing, most probably removed/moved by user.", 
                                                                                string.Format(ErrorHelper.XmlLoad.AudioFilesFolderMissingException, audioFilesFolder)) { }
    }

    public class HotkeyRoleInvalidException : CustomException
    {
        public HotkeyRoleInvalidException(string hotkeyRole, string key) : base(string.Format("Control role retrieved from the xml could not be parsed into a member of the enum ControlRoles. Should never happen unless user manipulation but still checked just in case. Key : {0} | Role : {1} .", key, hotkeyRole), 
                                                                                string.Format(ErrorHelper.XmlLoad.HotkeyRoleInvalidException, hotkeyRole, key)) { }
    }

    public class NoFileSelectedException : CustomException
    {
        public NoFileSelectedException() : base("", string.Format(ErrorHelper.NoFileSelectedException)) { }
    }

    public class MasterHotkeyUsedException : CustomException
    {
        public MasterHotkeyUsedException(string key) : base("", string.Format(ErrorHelper.MasterHotkeyUsedException, key)) { }
    }

    public class InvalidTimeValueException : CustomException
    {
        public InvalidTimeValueException(string value) : base("", string.Format(ErrorHelper.InvalidTimeValueException, value)) { }
    }

    public class InvalidVolumeValueException : CustomException
    {
        public InvalidVolumeValueException(string value) : base("", string.Format(ErrorHelper.InvalidVolumeValueException, value)) { }
    }

    public class InvalidStartingTimeValueException : CustomException
    {
        public InvalidStartingTimeValueException(string value) : base("", string.Format(ErrorHelper.InvalidStartValueException, value)) { }
    }

    public class UnknownErrorRegisterHotkey : CustomException
    {
        public UnknownErrorRegisterHotkey() : base("", string.Format(ErrorHelper.UnknownErrorRegisterHotkey, Logger.LogsFolderPath)) { }
    }
}
