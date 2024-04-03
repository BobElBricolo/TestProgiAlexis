public class VoitureLuxe : Voiture
{
    public VoitureLuxe(decimal prix)
    {
        Prix = prix;
    }
    
    public override decimal CalculateFraisUtilisationBase()
    {
        const decimal minimum = 25; 
        const decimal maximum = 200;
        
        var frais = 0.10m * Prix;
        
        if (frais < minimum)
            return minimum;

        if (frais > maximum)
            return maximum;
        
        return frais;
    }
    
    public override decimal CalculateFraisSpeciaux()
    {
        return 0.04m * Prix;
    }
}