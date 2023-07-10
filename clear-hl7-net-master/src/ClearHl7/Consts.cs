﻿namespace ClearHl7
{
    /// <summary>
    /// Library constants.
    /// </summary>
    public static class Consts
    {
        /// <summary>
        /// Standard Message line terminator.
        /// </summary>
        public const char LineTerminator = (char)13;

        /// <summary>
        /// Default field separator.
        /// </summary>
        public const string DefaultFieldSeparator = "|";

        /// <summary>
        /// Default component separator.
        /// </summary>
        public const string DefaultComponentSeparator = "^";

        /// <summary>
        /// Default field repeat separator.
        /// </summary>
        public const string DefaultFieldRepeatSeparator = "~";

        /// <summary>
        /// Default escape character.
        /// </summary>
        public const string DefaultEscapeCharacter = "\\";

        /// <summary>
        /// Default subcomponent separator.
        /// </summary>
        public const string DefaultSubcomponentSeparator = "&";

        /// <summary>
        /// Standard date format string.
        /// </summary>
        public const string DateFormat = "yyyyMMdd";

        /// <summary>
        /// Standard date format string with day precision.
        /// </summary>
        public const string DateFormatPrecisionDay = "yyyyMMdd";

        /// <summary>
        /// Standard date format string with month precision.
        /// </summary>
        public const string DateFormatPrecisionMonth = "yyyyMM";

        /// <summary>
        /// Standard date format string with year precision.
        /// </summary>
        public const string DateFormatPrecisionYear = "yyyy";

        /// <summary>
        /// Standard datetime format string.
        /// </summary>
        public const string DateTimeFormat = "yyyyMMddHHmmss";

        /// <summary>
        /// Standard datetime format string with second precision.
        /// </summary>
        public const string DateTimeFormatPrecisionSecond = "yyyyMMddHHmmss";

        /// <summary>
        /// Standard datetime format string with minute precision.
        /// </summary>
        public const string DateTimeFormatPrecisionMinute = "yyyyMMddHHmm";

        /// <summary>
        /// Standard datetime format string with hour precision.
        /// </summary>
        public const string DateTimeFormatPrecisionHour = "yyyyMMddHH";

        /// <summary>
        /// Standard time format string.
        /// </summary>
        public const string TimeFormat = "HHmmss";

        /// <summary>
        /// Standard time format string with second precision.
        /// </summary>
        public const string TimeFormatPrecisionSecond = "HHmmss";

        /// <summary>
        /// Standard time format string with minute precision.
        /// </summary>
        public const string TimeFormatPrecisionMinute = "HHmm";

        /// <summary>
        /// Standard time format string with hour precision.
        /// </summary>
        public const string TimeFormatPrecisionHour = "HH";

        /// <summary>
        /// Standard numeric format string.
        /// </summary>
        public const string NumericFormat = "0.#############################";
    }
}
