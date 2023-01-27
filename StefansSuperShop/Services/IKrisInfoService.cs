using System.Collections.Generic;

namespace StefansSuperShop.Services
{
    public interface IKrisInfoService
    {
        List<KrisInfo> GetAllKrisInformation();
        List<KrisInfo> GetEmergencies();
        KrisInfo GetKrisInformation(string id);
    }
}
