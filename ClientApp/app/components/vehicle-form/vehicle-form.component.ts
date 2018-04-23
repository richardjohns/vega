import { FeatureService } from './../app/services/feature.service';
import { MakeService } from './../app/services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})

export class VehicleFormComponent implements OnInit {
  makes: any[] = [];
  models: any[] = [];
  features: any[] = [];
  vehicle: any = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      email: '',
      phone: '',
    }
  };

  constructor(private makeService: MakeService,
              private featureService: FeatureService) { }

  // initial GET requests from services for makes and models.
  ngOnInit() {
    this.makeService.getMakes().subscribe(makes => {
      this.makes = makes 
      console.log("MAKES", this.makes);
    });
    this.featureService.getFeatures().subscribe(features => {
      this.features = features
      console.log("FEATURES", this.features);
    });
  }

  // select model and find related makes.
  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
    console.log("VEHICLE", this.vehicle);
  }

}
