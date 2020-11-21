import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TvAudioComponent } from './tv-audio.component';

describe('TvAudioComponent', () => {
  let component: TvAudioComponent;
  let fixture: ComponentFixture<TvAudioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TvAudioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TvAudioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
