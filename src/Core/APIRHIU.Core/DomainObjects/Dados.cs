namespace APIRHIU.Core.DomainObjects
{
    public class Data
    {
        public int Page { get; set; }
        public int MaxPage { get; set; }
        public int Count { get; set; }
        public List<Envelope> Envelopes { get; set; }
        public int Rows { get; set; }
    }
}