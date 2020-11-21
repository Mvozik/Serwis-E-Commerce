import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmartfonSmartwatchComponent } from './smartfon-smartwatch.component';

describe('SmartfonSmartwatchComponent', () => {
  let component: SmartfonSmartwatchComponent;
  let fixture: ComponentFixture<SmartfonSmartwatchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SmartfonSmartwatchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmartfonSmartwatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
