namespace Core.Interfaces
{
    public interface IAPISettings
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Param { get; set; }
    }
}
