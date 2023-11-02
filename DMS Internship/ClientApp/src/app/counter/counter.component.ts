import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
const inputValues = { Name: '', Surname: '', Age: '', DOB: '' };

   onSubmit(form: ngform) {
  console.log(form.value);
}
