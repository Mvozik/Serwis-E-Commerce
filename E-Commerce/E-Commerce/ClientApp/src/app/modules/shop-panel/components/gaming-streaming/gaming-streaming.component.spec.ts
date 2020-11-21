import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingStreamingComponent } from './gaming-streaming.component';

describe('GamingStreamingComponent', () => {
  let component: GamingStreamingComponent;
  let fixture: ComponentFixture<GamingStreamingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GamingStreamingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GamingStreamingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
