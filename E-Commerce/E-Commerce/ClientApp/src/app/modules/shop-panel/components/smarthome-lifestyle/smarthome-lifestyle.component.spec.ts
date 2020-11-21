import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmarthomeLifestyleComponent } from './smarthome-lifestyle.component';

describe('SmarthomeLifestyleComponent', () => {
  let component: SmarthomeLifestyleComponent;
  let fixture: ComponentFixture<SmarthomeLifestyleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SmarthomeLifestyleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmarthomeLifestyleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
