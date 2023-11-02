import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-vehicle-form-component',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./']
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
//const inputValues = { Name: '', Surname: '', Age: '', DOB: '' };

onSubmit(form: NgForm) {
  console.log(form.value);
}
