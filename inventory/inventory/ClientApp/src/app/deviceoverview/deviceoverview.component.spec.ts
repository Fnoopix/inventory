import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceoverviewComponent } from './deviceoverview.component';

describe('DeviceoverviewComponent', () => {
  let component: DeviceoverviewComponent;
  let fixture: ComponentFixture<DeviceoverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeviceoverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeviceoverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
