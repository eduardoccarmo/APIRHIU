﻿namespace APIRHIU.Core.DomainObjects
{
    public class BearerToken
    {
        public string access_token { get; set; } = string.Empty;
        public int expires_in { get; set; }
        public string token_type { get; set; } = string.Empty;
    }
}
