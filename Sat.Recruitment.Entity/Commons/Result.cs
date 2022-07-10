namespace Sat.Recruitment.Entity.Commons
{
    public class Result
    {
        public Result(string errors, bool isSuccess)
        {
            Errors = errors;
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
