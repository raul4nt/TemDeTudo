using System.ComponentModel;

namespace TemDeTudo.Enums
{
        public enum SaleStatus
        {
            [Description("Pending")]
            PENDING = 0,
            [Description("Billed")]
            BILLED = 1,
            [Description("Canceled")]
            CANCELED = 2
        }
}
