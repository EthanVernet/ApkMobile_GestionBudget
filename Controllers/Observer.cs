using Application_Gestion.Data;
using Application_Gestion.Interfaces.Pages;
using Application_Gestion.Model;

namespace Application_Gestion.Controllers
{
    public static class Observer
    {
        private static MCompte _comptes;
        public static MCompte Comptes{ set => _comptes = value; }

        private static List<IPages> _pages = new List<IPages>();
        public static void Register(IPages page)
        {
            _pages.Add(page);
        }

        public static void Sets()
        {
            foreach (IPages page in _pages)
            {
                page.Set();
            }
        }
    }
}
