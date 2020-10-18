namespace lmgtcommon.Validation
{
    public interface IValidationResult
    {
        /// <summary>
        /// The message indicates why the validation has failed
        /// This message can be exposed to end user
        /// <para>This fields should be considered only, if "ValidateAsync" returns false"
        /// </summary>
        /// <value></value>
        string ExposableErrorMessage {get;}

        /// <summary>
        /// The message indicates why the validation has failed in details
        /// This should not be shared with end user.
        /// This fields purely for prohrammer's purpose
        /// </summary>
        /// <value></value>
        string SystemErrorMessage {get;}

        void CopyResult(IValidationResult from);
    }
}