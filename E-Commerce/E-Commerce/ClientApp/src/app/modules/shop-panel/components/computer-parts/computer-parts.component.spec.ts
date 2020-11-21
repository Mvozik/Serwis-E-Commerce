import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComputerPartsComponent } from './computer-parts.component';

describe('ComputerPartsComponent', () => {
  let component: ComputerPartsComponent;
  let fixture: ComponentFixture<ComputerPartsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComputerPartsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComputerPartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
