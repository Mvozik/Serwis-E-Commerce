import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RealizedOrderListComponent } from './realized-order-list.component';

describe('RealizedOrderListComponent', () => {
  let component: RealizedOrderListComponent;
  let fixture: ComponentFixture<RealizedOrderListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RealizedOrderListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RealizedOrderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
