namespace InsuranceCompany.App;

//public enum ContactPreference : ushort
//{
//    None,
//    Email,
//    Phone,
//    Post,
//    Sms,
//    WhatsApp,
//}

[Flags]
public enum ContactPreference : ushort
{
    None = 0,           // 0000
    Email = 1,          // 0001
    Phone = 2,          // 0010
    Post = 4,           // 0100
    Sms = 8,
    WhatsApp = 16,
}