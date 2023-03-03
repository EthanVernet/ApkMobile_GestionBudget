using Application_Gestion.Model;

namespace Application_Gestion.Controllers
{
    public static class CCategorie
    {
        public static Tuple<bool, string> Create(MCompte comptes, Compte compte, string name, string limite)
        {
            if (limite != null) { limite = limite.Replace(" ", ""); }

            bool res = true;
            string mess = "";
            if ((name == null) || (name == ""))
            {
                res = false;
            }
            
            if (!float.TryParse(limite, out float limiteF))
            {
                if (mess == "") { mess = "Le format de la somme saisie est incorrect."; }
                else { mess += "\nLe format de la somme saisie est incorrect"; }
                res = false;
            }
            if (limiteF < 0.0F)
            {
                if (mess == "") { mess = "La somme saisie est inférieur à 0."; }
                else { mess += "\nLa somme saisie est inférieur à 0."; }
                res = false;
            }
            if(res != false)
            {
                compte.AddCategorie(new Categorie(name, limiteF));
            }
            Observer.Sets();
            return Tuple.Create(res, mess);
        }

        public static Tuple<bool,string> Set(MCompte comptes, Categorie categorie,string name, string limite)
        {
            if (limite != null) { limite = limite.Replace(" ", ""); }

            bool res = true;
            string mess = "";
            if ((name == null) || (name == ""))
            {
                res = false;
            }
            if (!float.TryParse(limite, out float limiteF))
            {
                if (mess == "") { mess = "Le format de la somme saisie est incorrect."; }
                else { mess += "\nLe format de la somme saisie est incorrect"; }
                res = false;
            }
            if (limiteF < 0.0F)
            {
                if (mess == "") { mess = "La somme saisie est inférieur à 0."; }
                else { mess += "\nLa somme saisie est inférieur à 0."; }
                res = false;
            }
            if (res != false)
            {
                categorie.Name = name;
                categorie.Limite = limiteF;
                res = true;
            }
            Observer.Sets();
            return Tuple.Create(res, mess);
        }

        public static bool Remove(MCompte comptes, Compte compte, Categorie categorie)
        {
            bool res = false;
            if(compte.Categories.Categories.Count != 1) 
            {
                compte.RemoveCategorie(categorie);
                res = true;
            }
            Observer.Sets();
            return res;
        }
    }
}
