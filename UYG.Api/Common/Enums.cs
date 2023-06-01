namespace UYG.Api.Common
{
    public enum TaskStatus : byte
    {
        None = 1,
        Low = 2,
        High = 3,
    }
    public enum Response : byte
    {
        Success = 0,
        Fail = 1,
        InProgress = 2
    }
}
