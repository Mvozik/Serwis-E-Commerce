import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LaptopsComputersComponent } from './laptops-computers.component';

describe('LaptopsComputersComponent', () => {
  let component: LaptopsComputersComponent;
  let fixture: ComponentFixture<LaptopsComputersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LaptopsComputersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LaptopsComputersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
