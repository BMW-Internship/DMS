import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditVehichleDetailsComponent } from './edit-vehichle-details.component';

describe('EditVehichleDetailsComponent', () => {
  let component: EditVehichleDetailsComponent;
  let fixture: ComponentFixture<EditVehichleDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditVehichleDetailsComponent]
    });
    fixture = TestBed.createComponent(EditVehichleDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
