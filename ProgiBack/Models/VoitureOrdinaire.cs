public class VoitureOrdinaire : Voiture
{
    public VoitureOrdinaire(decimal prix)
    {
        Prix = prix;
    }
    
    public override decimal CalculateFraisUtilisationBase()
    {
        const decimal minimum = 10; 
        const decimal maximum = 50;
        
        var frais = 0.10m * Prix;
        if (frais < minimum)
            return minimum;

        if (frais > maximum)
            return maximum;
        
        return frais;
    }
    
    public override decimal CalculateFraisSpeciaux()
    {
        return 0.02m * Prix;
    }
    
    
}