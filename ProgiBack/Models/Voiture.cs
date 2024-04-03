public abstract class Voiture
{

    // Propriétés
    public decimal Prix { get; set; }
    public decimal PrixEntreposage { get; set; } = 100;
    public decimal FraisUtilisationBase => CalculateFraisUtilisationBase();
    public decimal FraisSpeciaux => CalculateFraisSpeciaux();
    public decimal FraisSupplementaires => CalculateFraisSupplementaires();
    public decimal FraisTotaux=> CalculerFraisTotaux();
    public decimal PrixTotal => CalculerPrixTotal();
    
    
    /// <summary>
    /// Calcule les frais d'utilisation de base
    /// </summary>
    /// <returns>Les frais d'utilisation de base</returns>
    public abstract decimal CalculateFraisUtilisationBase();


    /// <summary>
    /// Calcule les frais spéciaux selon un pourcentage
    /// </summary>
    /// <returns>Les frais spéciaux</returns>
    public abstract decimal CalculateFraisSpeciaux();
    
    
    /// <summary>
    /// Calcule les frais supplémentaires selon le prix
    /// </summary>
    /// <returns>Le montant des frais supplémentaires</returns>
    public decimal CalculateFraisSupplementaires()
    {
        if (Prix <= 500)
            return 5;
        if (Prix <= 1000)
            return 10;
        if (Prix <= 3000)
            return 15;
        
        return 20;
    }
    
    
    /// <summary>
    /// Calcule les frais totaux
    /// </summary>
    /// <returns>Les frais totaux</returns>
    public decimal CalculerFraisTotaux()
    {
        return FraisUtilisationBase + FraisSupplementaires + FraisSpeciaux + PrixEntreposage;
    }
    
    /// <summary>
    /// Calcule le prix total
    /// </summary>
    /// <returns>Prix total</returns>
    public decimal CalculerPrixTotal()
    {
        return CalculerFraisTotaux() + Prix;
    }
    
}