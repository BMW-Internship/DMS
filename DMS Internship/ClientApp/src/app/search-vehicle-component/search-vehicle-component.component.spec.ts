import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchVehicleComponentComponent } from './search-vehicle-component.component';

describe('SearchVehicleComponentComponent', () => {
  let component: SearchVehicleComponentComponent;
  let fixture: ComponentFixture<SearchVehicleComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchVehicleComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchVehicleComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
