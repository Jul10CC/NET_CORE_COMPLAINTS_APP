using System;

namespace M04_SLN_APP_04_NET_CORE_LOGIN.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
