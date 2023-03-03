using System;
using System.Runtime.InteropServices;

public class Compte {
	private string _name;
	private MCategorie _categories;

	public Compte([Optional, DefaultParameterValueAttribute()]ref string name) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Categorie GetCategorie([Optional, DefaultParameterValueAttribute()]ref Categorie categorie) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AddCategorie([Optional, DefaultParameterValueAttribute()]ref Categorie categorie) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void RemoveCategorie([Optional, DefaultParameterValueAttribute()]ref Categorie categorie) {
		throw new System.NotImplementedException("Not implemented");
	}

	private MCategorie mCategorie;

	private MCompte mCompte;

}
