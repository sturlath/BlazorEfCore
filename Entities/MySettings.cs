namespace Entities
{
    public class MySettings
    {
        public int MySettingsId { get; set; }
        public string CompanyName { get; set; }

        public int PostalSystemId { get; set; }
        public PostalSystem PostalSystem { get; set; }
    }
}
