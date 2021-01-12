import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DropMenuIconComponent } from './drop-menu-icon.component';

describe('DropMenuComponent', () => {
  let component: DropMenuIconComponent;
  let fixture: ComponentFixture<DropMenuIconComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DropMenuIconComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DropMenuIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
