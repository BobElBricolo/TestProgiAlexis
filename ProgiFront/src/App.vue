<template>
  <div id="app">
    <h1>Calculateur de frais de voiture</h1>
    
    <img alt="Vue logo" src="./assets/car.png">
    
    <p>Entrer le prix du véhicule</p>

    <input type="text"  v-model="inputData"/>
  
    <div class="sidebyside">
      <button @click="onVoitureLuxeClick">Voiture de luxe</button>
      <button @click="onVoitureOrdinaireClick">Voiture ordinaire</button>
    </div>

    <ul>
      <li><span>Prix de la voiture:</span> <span class="data">{{ formaterNombre(car.prix) }}</span></li>
      <li><span>Type de voiture:</span> <span class="data">{{ type }}</span></li>
      <li><span>Prix d'entreposage:</span> <span class="data">{{ formaterNombre(car.prixEntreposage) }}</span></li>
      <li><span>Frais d'utilisation de base:</span> <span class="data">{{ formaterNombre(car.fraisUtilisationBase) }}</span></li>
      <li><span>Frais spéciaux:</span> <span class="data">{{ formaterNombre(car.fraisSpeciaux) }}</span></li>
      <li><span>Frais supplémentaires:</span> <span class="data">{{ formaterNombre(car.fraisSupplementaires) }}</span></li>
      <li><span>Frais totaux:</span> <span class="data">{{ formaterNombre(car.fraisTotaux) }}</span></li>
      <li><span>Prix total:</span> <span class="data">{{ formaterNombre(car.prixTotal) }}</span></li>
    </ul>

  </div>
</template>

<script>

import axios from 'axios';


export default {
  name: 'App',
  
  mounted() {
    document.title = 'Calculateur de frais de voiture';
  },

  data() {
    return {
      // Prix de la voiture
      inputData: '',

      // Type de voiture (Luxe ou ordinaire)
      type: '',

      // Informations de la voiture
      car: {
        prix: 0,
        prixEntreposage: 0,
        fraisUtilisationBase: 0,
        fraisSpeciaux: 0,
        fraisSupplementaires: 0,
        fraisTotaux: 0,
        prixTotal: 0
      },
    };
  },


  methods: {
    

    // Méthode appelée lorsqu'on clique sur le bouton 'Voiture de luxe'
    async onVoitureLuxeClick() {

      // Vérification si point ou virgule est utilisé pour les décimales
      this.verifPointVirgule();

      this.type = 'Voiture de luxe';

      try {
        // Envoi d'une requête GET à l'API pour récupérer les données de la voiture de luxe
        const response = await axios.get('http://localhost:5106/Voiture/voitureLuxe', {
          params: {
            Prix: this.inputData
          }
        });

        // Récupération des données de réponse renvoyées par l'API
        this.car = response.data;
        

      } catch (error) {
        // Gestion des erreurs lors de l'envoi de la requête ou de la réception de la réponse
        window.alert("Erreur lors de la récupération des données de la voiture de luxe. Assurez-vous que les données entrées sont correctes.");
      }

    },



    // Méthode appelée lorsqu'on clique sur le bouton 'Voiture ordinaire'
    async onVoitureOrdinaireClick() {

      // Vérification si point ou virgule est utilisé pour les décimales
      this.verifPointVirgule();

      this.type = 'Voiture ordinaire';
      
      try {
        // Envoi d'une requête GET à l'API pour récupérer les données de la voiture de luxe
        const response = await axios.get('http://localhost:5106/Voiture/voitureOrdinaire', {
          params: {
            Prix: this.inputData
          }
        });
        
        // Récupération des données de réponse renvoyées par l'API
        const car = response.data;
        this.car = car;

      } catch (error) {
        window.alert('Erreur lors de la récupération des données de la voiture de luxe. Assurez-vous que les données entrées sont correctes.');
      }

    },



    // Méthode pour gérer le cas où le point est utilisé pour les décimales
    verifPointVirgule() {
      if (this.inputData.includes('.')) {
        this.inputData = this.inputData.replace('.', ',');
      }
    },



    // Méthode pour formater les nombres
    formaterNombre(nombre) {
      return nombre.toLocaleString(undefined, {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
      });
    }

  }

}
</script>

<style>

/* Importation des styles depuis le fichier 'styles.css' */
@import './styles.css';

</style>
