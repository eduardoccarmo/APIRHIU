namespace APIRHIU.Core.DomainObjects
{
    public class Subscriber
    {
        public string SubscriberName { get; set; }
        public string SubscriberCPF { get; set; }
        public string SubscriberEmail { get; set; }
        public string SubscriberPhone { get; set; }
        public int ID_SubscriberStatus { get; set; }
        public int SubscriberOrder { get; set; }
        public int SubscriberRole { get; set; }
        public string URLFrameFull { get; set; }
        public bool IsUser { get; set; }
    }
}