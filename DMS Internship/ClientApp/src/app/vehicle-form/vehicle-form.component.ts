import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html'
})
export class VehicleFormComponent implements OnInit{


  ngOnInit(): void {

   }

  inputValues = {Make: ' ', Model: ' ', Price: 0};

  onSubmit(form: NgForm) {
    console.log(form.value);
  }
}
