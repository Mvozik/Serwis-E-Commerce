import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RtvAgdComponent } from './rtv-agd.component';

describe('RtvAgdComponent', () => {
  let component: RtvAgdComponent;
  let fixture: ComponentFixture<RtvAgdComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RtvAgdComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RtvAgdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
