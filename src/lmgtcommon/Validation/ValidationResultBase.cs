namespace lmgtcommon.Validation
{
    public class ValidationResultBase : IValidationResult
    {
        public string ExposableErrorMessage {get;protected set;}   

        public string SystemErrorMessage {get;protected set;}

        public void CopyResult(IValidationResult from)
        {
            ExposableErrorMessage = from.ExposableErrorMessage;
            SystemErrorMessage = from.SystemErrorMessage;
        }
    }
}