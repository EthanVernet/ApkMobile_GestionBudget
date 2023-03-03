
using Application_Gestion.Model;

namespace Application_Gestion.Controllers
{
    public static class CCompte
    {
        public static bool Add(MCompte comptes,string name)
        {
            bool res = true;
            if ((name == null) || (name == ""))
            {
                res = false;
            }
            else
            {
                comptes.AddCompte(new Compte(name));
                res = true;
            }
            Observer.Sets();
            return res;
        }

        public static void Remove(MCompte comptes, Compte compte)
        {
            comptes.RemoveCompte(compte);
            Observer.Sets();
        }

        public static bool Set(MCompte comptes, Compte compte, string name) 
        {
            bool res = true;
            if ((name == null) || (name == ""))
            {
                res = false;
            }
            else
            {
                compte.Name = name;
                res = true;
            }
            Observer.Sets();
            return res;
        } 
    }
}
