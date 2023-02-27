using Application_Gestion.Data;
using Application_Gestion.Model;

namespace Application_Gestion.Controllers
{
    public static class CTransaction
    {
        public static Tuple<bool, string> Create(MCompte comptes,Categorie categorie, string name, string value)
        {
            if (value != null) { value = value.Replace(" ", ""); }

            bool res = true;
            string mess = "";
            if ((name == null) || (name == ""))
            {
                mess = "Vous n'avez pas entrer le nom de la trasaction.";
                res = false;
            }
            if ((value == null) || (value == ""))
            {

                if (mess == "") { mess = "Vous n'avez pas entrer la somme."; }
                else { mess += "\nVous n'avez pas entrer la somme."; }
                res = false;
            }
            if (!float.TryParse(value, out float valueF))
            {
                if (mess == "") { mess = "Le format de la somme saisie est incorrect."; }
                else { mess += "\nLe format de la somme saisie est incorrect"; }
                res = false;
            }
            if (valueF == 0)
            {
                if (mess == "") { mess = "La somme saisie est égal à 0."; }
                else { mess += "\nLa somme saisie est égals à 0."; }
                res = false;
            }
            if (res != false)
            {
                categorie.AddTransaction(new Transaction(name, valueF));
            }
            Serializer.SaveComptes(comptes);
            Observer.Sets();
            return Tuple.Create(res, mess);
        }

        public static void Remove(MCompte comptes, Categorie categorie, Transaction transaction)
        {
            Serializer.SaveComptes(comptes);
            categorie.RemoveTransaction(transaction);
            Observer.Sets();
        }
    }
}
